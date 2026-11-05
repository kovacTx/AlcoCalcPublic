using AlcoCalc.Values;

namespace AlcoCalc.Services;

public class Calculator1A_8(Calculator1A_1 calculator1A_1) : CalculatorBase<CalculatorValues1A_8>
{
    public const string CalculatorName = "1A-8";

    public static double WaterTemperatureMin => 0;
    public static double WaterTemperatureMax => 40;

    protected override void DoCalc(CalculatorValues1A_8 values)
    {
        values.Result = null;
        values.WaterDensity = null;
        if (IsEmpty(values.WaterTemperature)) return;

        ValidateRange(values.WaterTemperature, nameof(values.WaterTemperature), "Temperature of water", WaterTemperatureMin, WaterTemperatureMax, CalculatorName);

        var _1A_1Values = new CalculatorValues1A_1 { EthanolMassFraction = 0, AlcoholTemperature = values.WaterTemperature };
        calculator1A_1.Calculate(_1A_1Values);

        if (_1A_1Values.Result is null)
            throw new InvalidOperationException($"{CalculatorName}: cannot calculate further");

        values.WaterDensity = _1A_1Values.Result;
        values.Result = 1.0 / values.WaterDensity.Value;
    }
}