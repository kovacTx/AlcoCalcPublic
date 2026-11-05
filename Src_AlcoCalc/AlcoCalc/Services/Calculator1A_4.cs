using AlcoCalc.Values;

namespace AlcoCalc.Services;

public class Calculator1A_4 : CalculatorBase<CalculatorValues1A_4>
{
    public const string CalculatorName = "1A-4";

    public static double ThermalExpansionCoefficientMin => 0;
    public static double ThermalExpansionCoefficientMax => 1;

    public static double TemperatureOfMeasurementMin => 0;
    public static double TemperatureOfMeasurementMax => 30;

    protected override void DoCalc(CalculatorValues1A_4 values)
    {
        values.Result = null;
        if (IsEmpty(values.ThermalExpansionCoefficient)) return;
        if (IsEmpty(values.TemperatureOfMeasurement)) return;

        ValidateRange(values.ThermalExpansionCoefficient, nameof(values.ThermalExpansionCoefficient), "Thermal expansion coefficient", ThermalExpansionCoefficientMin, ThermalExpansionCoefficientMax, CalculatorName);
        ValidateRange(values.TemperatureOfMeasurement, nameof(values.TemperatureOfMeasurement), "Temperature", TemperatureOfMeasurementMin, TemperatureOfMeasurementMax, CalculatorName);

        values.Result = 1.0 - values.ThermalExpansionCoefficient * (values.TemperatureOfMeasurement - 20.0);
    }

}