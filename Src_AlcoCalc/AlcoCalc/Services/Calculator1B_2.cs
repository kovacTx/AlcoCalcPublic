using AlcoCalc.Values;

namespace AlcoCalc.Services;

public class Calculator1B_2 : CalculatorBase<CalculatorValues1B_2>
{
    public const string CalculatorName = "1B-2";

    public static double AlcoholometerReadingMin => 0;
    public static double AlcoholometerReadingMax => 100;

    public static double TemperatureMin => 0;
    public static double TemperatureMax => 30;

    protected override void DoCalc(CalculatorValues1B_2 values)
    {
        values.Result = null;
        if (IsEmpty(values.AlcoholometerReading)) return;
        if (IsEmpty(values.Temperature)) return;

        ValidateRange(values.AlcoholometerReading, nameof(values.AlcoholometerReading), "Alcoholometer reading", AlcoholometerReadingMin, AlcoholometerReadingMax, CalculatorName);
        ValidateRange(values.Temperature, nameof(values.Temperature), "Temperature", TemperatureMin, TemperatureMax, CalculatorName);

        values.Result = On66Interpolator.Interpolate(values.Temperature!.Value, values.AlcoholometerReading!.Value);
    }

}