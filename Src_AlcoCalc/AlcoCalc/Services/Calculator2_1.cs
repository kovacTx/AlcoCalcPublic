using AlcoCalc.Values;

namespace AlcoCalc.Services;

public class Calculator2_1(Calculator1A_3 calculator1A_3, Calculator1A_5 calculator1A_5) : CalculatorBase<CalculatorValues2_1>
{
    public const string CalculatorName = "2-1";

    public static double ApparentMassMin => 0;
    public static double ApparentMassMax => double.MaxValue;

    public static double VolumeConcentrationMin => 0;
    public static double VolumeConcentrationMax => 100;

    protected override void DoCalc(CalculatorValues2_1 values)
    {
        values.Result = null;
        values.VolumeOfEtanol = null;
        if (IsEmpty(values.VolumeConcentration)) return;

        ValidateRange(values.VolumeConcentration, nameof(values.VolumeConcentration), "Volume concentration percent", VolumeConcentrationMin, VolumeConcentrationMax, CalculatorName);

        // 1A-3
        var _1A_3Values = new CalculatorValues1A_3 { VolumeConcentration = values.VolumeConcentration };
        calculator1A_3.Calculate(_1A_3Values);
        if (_1A_3Values.Result is null)
            throw new InvalidOperationException($"{CalculatorName}: cannot calculate further");

        // 1A-1
        var _1A_1Values = new CalculatorValues1A_1 { EthanolMassFraction = _1A_3Values.Result, AlcoholTemperature = 20 };
        Calculator1A_1.DoCalcWithoutPreCheck(_1A_1Values);
        if (_1A_1Values.Result is null)
            throw new InvalidOperationException($"{CalculatorName}: cannot calculate further");

        // 1A-5
        var _1A_5Values = new CalculatorValues1A_5 { LiquidDensity = _1A_1Values.Result, AirDensity = 1.2 };
        calculator1A_5.Calculate(_1A_5Values);
        if (_1A_5Values.Result is null)
            throw new InvalidOperationException($"{CalculatorName}: cannot calculate further");

        values.Result = 10.0 * values.VolumeConcentration / _1A_1Values.Result * _1A_5Values.Result;

        if (IsEmpty(values.ApparentMass)) return;
        values.VolumeOfEtanol = values.ApparentMass * values.Result;
    }

}