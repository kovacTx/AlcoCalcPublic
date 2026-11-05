using AlcoCalc.Values;

namespace AlcoCalc.Services;

public class Calculator1A_6 : CalculatorBase<CalculatorValues1A_6>
{
    public const string CalculatorName = "1A-6";

    public static double AtmosphericPressureMin => 850;
    public static double AtmosphericPressureMax => 1050;

    public static double AirTemperatureMin => -50;
    public static double AirTemperatureMax => 50;

    public static double RelativeHumidityMin => 0;
    public static double RelativeHumidityMax => 100;

    protected override void DoCalc(CalculatorValues1A_6 values)
    {
        values.Result = null;
        if (IsEmpty(values.AtmosphericPressure)) return;
        if (IsEmpty(values.AirTemperature)) return;
        if (IsEmpty(values.RelativeHumidity)) return;

        ValidateRange(values.AtmosphericPressure, nameof(values.AtmosphericPressure), "Atmospheric pressure", AtmosphericPressureMin, AtmosphericPressureMax, CalculatorName);
        ValidateRange(values.AirTemperature, nameof(values.AirTemperature), "Temperature", AirTemperatureMin, AirTemperatureMax, CalculatorName);
        ValidateRange(values.RelativeHumidity, nameof(values.RelativeHumidity), "Relative humidity", RelativeHumidityMin, RelativeHumidityMax, CalculatorName);

        var e = 691.12 * Math.Exp(0.0607851 * values.AirTemperature!.Value);
        values.Result = (((0.00348488 * values.AtmosphericPressure!.Value) - (0.00131689 * values.RelativeHumidity!.Value * 0.01 * (e / 100))) / (273.15 + values.AirTemperature!.Value)) * 100;
    }
}