using AlcoCalc.Values;

namespace AlcoCalc.Services;

public class Calculator2_2 : CalculatorBase<CalculatorValues2_2>
{
    public const string CalculatorName = "2-2";

    public static double VolumeOfLoadMin => 0;
    public static double VolumeOfLoadMax => double.MaxValue;

    public static double VolumeConcentrationMin => 0;
    public static double VolumeConcentrationMax => 100;

    public static double AlcoholTemperatureMin => -20;
    public static double AlcoholTemperatureMax => 40;

    public static double ThermalExpansionCorrectionFactorMin => 0;
    public static double ThermalExpansionCorrectionFactorMax => 2;

    protected override void DoCalc(CalculatorValues2_2 values)
    {
        values.Result = null;
        values.VolumeOfEthanol = null;
        if (IsEmpty(values.VolumeConcentration)) return;
        if (IsEmpty(values.AlcoholTemperature)) return;
        if (IsEmpty(values.ThermalExpansionCorrectionFactor)) return;

        ValidateRange(values.VolumeConcentration, nameof(values.VolumeOfLoad), "Volume of load", VolumeOfLoadMin, VolumeOfLoadMax, CalculatorName);
        ValidateRange(values.VolumeConcentration, nameof(values.VolumeConcentration), "Volume concentration percent", VolumeConcentrationMin, VolumeConcentrationMax, CalculatorName);
        ValidateRange(values.AlcoholTemperature, nameof(values.AlcoholTemperature), "Alcohol temperature", AlcoholTemperatureMin, AlcoholTemperatureMax, CalculatorName);
        ValidateRange(values.ThermalExpansionCorrectionFactor, nameof(values.ThermalExpansionCorrectionFactor), "Thermal expansion correction factor", ThermalExpansionCorrectionFactorMin, ThermalExpansionCorrectionFactorMax, CalculatorName);

        // 1A-3:
        // objk -> hmotnostný zlomok
        var _1A_3Values = new CalculatorValues1A_3
        {
            VolumeConcentration = values.VolumeConcentration
        };
        Calculator1A_3.DoCalcWithoutPreCheck(_1A_3Values);
        if (_1A_3Values.Result is null)
            throw new InvalidOperationException($"{CalculatorName}: cannot calculate further");

        // Hustota pri 20 °C
        var _1A_1Values20 = new CalculatorValues1A_1
        {
            EthanolMassFraction = _1A_3Values.Result,
            AlcoholTemperature = 20
        };
        Calculator1A_1.DoCalcWithoutPreCheck(_1A_1Values20);
        if (_1A_1Values20.Result is null)
            throw new InvalidOperationException($"{CalculatorName}: cannot calculate further");

        // Hustota pri zadanej teplote
        var _1A_1Values = new CalculatorValues1A_1
        {
            EthanolMassFraction = _1A_3Values.Result,
            AlcoholTemperature = values.AlcoholTemperature
        };
        Calculator1A_1.DoCalcWithoutPreCheck(_1A_1Values);
        if (_1A_1Values.Result is null)
            throw new InvalidOperationException($"{CalculatorName}: cannot calculate further");

        // Delphi:
        // koefkv := ((objk/100)*(hust_z/hust_z20));
        values.Result = (values.VolumeConcentration!.Value / 100.0) * (_1A_1Values.Result.Value / _1A_1Values20.Result.Value);

        if (IsEmpty(values.VolumeOfLoad)) return;
        // Delphi:
        // objm := koefkv * objr * korb;
        values.VolumeOfEthanol = values.Result * values.VolumeOfLoad!.Value * values.ThermalExpansionCorrectionFactor!.Value;
    }

}