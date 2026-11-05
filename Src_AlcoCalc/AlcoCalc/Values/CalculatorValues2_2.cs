namespace AlcoCalc.Values;

public class CalculatorValues2_2 : CalculatorValuesBase
{
    private double? _volumeOfLoad = null;
    public double? VolumeOfLoad { get => _volumeOfLoad; set => SetProperty(ref _volumeOfLoad, value); }

    private double? _volumeConcentrationPercent = null;
    public double? VolumeConcentration { get => _volumeConcentrationPercent; set => SetProperty(ref _volumeConcentrationPercent, value); }

    private double? _alcoholTemperature = null;
    public double? AlcoholTemperature { get => _alcoholTemperature; set => SetProperty(ref _alcoholTemperature, value); }

    private double? _thermalExpansionCorrectionFactor = null;
    public double? ThermalExpansionCorrectionFactor { get => _thermalExpansionCorrectionFactor; set => SetProperty(ref _thermalExpansionCorrectionFactor, value); }

    private double? _volumeOfEthanol = null;
    public double? VolumeOfEthanol { get => _volumeOfEthanol; set => SetProperty(ref _volumeOfEthanol, value); }

    public override void Reset()
    {
        base.Reset();
        VolumeOfLoad = null;
        VolumeConcentration = null;
        AlcoholTemperature = null;
        ThermalExpansionCorrectionFactor = null;
        VolumeOfEthanol = null;
    }
}
