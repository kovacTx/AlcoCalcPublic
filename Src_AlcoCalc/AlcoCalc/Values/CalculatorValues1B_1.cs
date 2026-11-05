namespace AlcoCalc.Values;

public class CalculatorValues1B_1 : CalculatorValuesBase
{
    private double? _density = null;
    public double? Density { get => _density; set => SetProperty(ref _density, value); }

    private double? _temperatureOfMeasurement = null;
    public double? TemperatureOfMeasurement { get => _temperatureOfMeasurement; set => SetProperty(ref _temperatureOfMeasurement, value); }

    public override void Reset()
    {
        base.Reset();
        Density = null;
        TemperatureOfMeasurement = null;
    }
}
