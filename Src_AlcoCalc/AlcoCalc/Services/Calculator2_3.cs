using AlcoCalc.Values;

namespace AlcoCalc.Services;

public class Calculator2_3 : CalculatorBase<CalculatorValues2_3>
{
    public const string CalculatorName = "2-3";

    public static double ThermalExpansionCoefficientMin => 0;
    public static double ThermalExpansionCoefficientMax => 1;

    public static double TemperatureOfMeasurementMin => -20;
    public static double TemperatureOfMeasurementMax => 40;

    protected override void DoCalc(CalculatorValues2_3 values)
    {
        values.Result = null;
        if (IsEmpty(values.ThermalExpansionCoefficient)) return;
        if (IsEmpty(values.TemperatureOfMeasurement)) return;

        ValidateRange(values.ThermalExpansionCoefficient, nameof(values.ThermalExpansionCoefficient), "Thermal expansion coefficient", ThermalExpansionCoefficientMin, ThermalExpansionCoefficientMax, CalculatorName);
        ValidateRange(values.TemperatureOfMeasurement, nameof(values.TemperatureOfMeasurement), "Temperature of measurement", TemperatureOfMeasurementMin, TemperatureOfMeasurementMax, CalculatorName);

        values.Result = 1.0 + values.ThermalExpansionCoefficient * (values.TemperatureOfMeasurement - 20.0);
    }

}