namespace AlcoCalc.Values;

public class CalculatorValues1A_7 : CalculatorValuesBase
{
    private double? _airDensity = null;
    public double? AirDensity { get => _airDensity; set => SetProperty(ref _airDensity, value); }

    private double? _loadTemperature = null;
    public double? LoadTemperature { get => _loadTemperature; set => SetProperty(ref _loadTemperature, value); }

    private double? _loadWeight = null;
    public double? LoadWeight { get => _loadWeight; set => SetProperty(ref _loadWeight, value); }

    private double? _massVolume = null;
    public double? MassVolume { get => _massVolume; set => SetProperty(ref _massVolume, value); }

    public override void Reset()
    {
        base.Reset();
        AirDensity = null;
        LoadTemperature = null;
        LoadWeight = null;
        MassVolume = null;
    }
}
