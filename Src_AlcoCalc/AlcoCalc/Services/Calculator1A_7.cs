using AlcoCalc.Values;

namespace AlcoCalc.Services;

public class Calculator1A_7 : CalculatorBase<CalculatorValues1A_7>
{
    public const string CalculatorName = "1A-7";

    public static double AirDensityMin => 1;
    public static double AirDensityMax => 1.3001;

    public static double LoadTemperatureMin => 0;
    public static double LoadTemperatureMax => 40;

    public static double LoadWeightMin => 0;
    public static double LoadWeightMax => double.MaxValue;

    protected override void DoCalc(CalculatorValues1A_7 values)
    {
        values.Result = null;
        values.MassVolume = null;
        if (IsEmpty(values.AirDensity)) return;
        if (IsEmpty(values.LoadTemperature)) return;

        ValidateRange(values.AirDensity, nameof(values.AirDensity), "Air density", AirDensityMin, AirDensityMax, CalculatorName);
        ValidateRange(values.LoadTemperature, nameof(values.LoadTemperature), "Temperature of water", LoadTemperatureMin, LoadTemperatureMax, CalculatorName);

        // hustota roztoku pri 0 % alkoholu
        var _1A_1Values = new CalculatorValues1A_1 { EthanolMassFraction = 0, AlcoholTemperature = values.LoadTemperature };
        Calculator1A_1.DoCalcWithoutPreCheck(_1A_1Values);

        if (_1A_1Values.Result is null)
            throw new InvalidOperationException($"{CalculatorName}: cannot calculate further");

        var buoyancyCorrection = 1.0 + (values.AirDensity!.Value / _1A_1Values.Result.Value) - (values.AirDensity!.Value / Constants.ReferenceWeightDensity);

        values.Result = 1000.0 * buoyancyCorrection / _1A_1Values.Result.Value;

        if (IsEmpty(values.LoadWeight)) return;
        ValidateRange(values.LoadWeight, nameof(values.LoadWeight), "Load weight", LoadWeightMin, LoadWeightMax, CalculatorName);
        values.MassVolume = values.Result * values.LoadWeight!.Value;
    }
}