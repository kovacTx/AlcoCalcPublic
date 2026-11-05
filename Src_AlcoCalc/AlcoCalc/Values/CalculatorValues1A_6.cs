namespace AlcoCalc.Values;

public class CalculatorValues1A_6 : CalculatorValuesBase
{
    private double? _atmosphericPressure = null;
    public double? AtmosphericPressure { get => _atmosphericPressure; set => SetProperty(ref _atmosphericPressure, value); }

    private double? _airTemperature = null;
    public double? AirTemperature { get => _airTemperature; set => SetProperty(ref _airTemperature, value); }

    private double? _humidity = null;
    public double? RelativeHumidity { get => _humidity; set => SetProperty(ref _humidity, value); }

    public override void Reset()
    {
        base.Reset();
        AtmosphericPressure = null;
        AirTemperature = null;
        RelativeHumidity = null;
    }
}
