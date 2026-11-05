namespace AlcoCalc.Values;

public class CalculatorValues1A_4 : CalculatorValuesBase
{
    private double? _thermalExpansionCoefficient = null;
    public double? ThermalExpansionCoefficient { get => _thermalExpansionCoefficient; set => SetProperty(ref _thermalExpansionCoefficient, value); }

    private double? _temperatureOfMeasurement = null;
    public double? TemperatureOfMeasurement { get => _temperatureOfMeasurement; set => SetProperty(ref _temperatureOfMeasurement, value); }

    public override void Reset()
    {
        base.Reset();
        ThermalExpansionCoefficient = null;
        TemperatureOfMeasurement = null;
    }
}
