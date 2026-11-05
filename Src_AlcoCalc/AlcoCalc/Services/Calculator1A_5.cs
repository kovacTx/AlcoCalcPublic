using AlcoCalc.Values;

namespace AlcoCalc.Services;

public class Calculator1A_5 : CalculatorBase<CalculatorValues1A_5>
{
    public const string CalculatorName = "1A-5";

    public static double LiquidDensityMin => double.Epsilon; // 0
    public static double LiquidDensityMax => double.MaxValue; // 10000

    public static double AirDensityMin => 1;
    public static double AirDensityMax => 1.3;

    protected override void DoCalc(CalculatorValues1A_5 values)
    {
        values.Result = null;
        if (IsEmpty(values.LiquidDensity)) return;
        if (IsEmpty(values.AirDensity)) return;

        ValidateRange(values.LiquidDensity, nameof(values.LiquidDensity), "Liquid density", LiquidDensityMin, LiquidDensityMax, CalculatorName);
        ValidateRange(values.AirDensity, nameof(values.AirDensity), "Air density", AirDensityMin, AirDensityMax, CalculatorName);

        values.Result = 1.0 + (values.AirDensity!.Value / values.LiquidDensity!.Value) - (values.AirDensity!.Value / Constants.ReferenceWeightDensity);
    }
}