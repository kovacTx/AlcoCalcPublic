namespace AlcoCalc.Values;

public class CalculatorValues2_4 : CalculatorValuesBase
{
    private double? _volumeOfEthanol = null;
    public double? VolumeOfEthanol { get => _volumeOfEthanol; set => SetProperty(ref _volumeOfEthanol, value); }

    private double? _meterReadingDifference = null;
    public double? MeterReadingDifference { get => _meterReadingDifference; set => SetProperty(ref _meterReadingDifference, value); }

    private double? _notRecordedVolume = null;
    public double? NotRecordedVolume { get => _notRecordedVolume; set => SetProperty(ref _notRecordedVolume, value); }

    private double? _thermalExpansionCorrectionFactor = null;
    public double? ThermalExpansionCorrectionFactor { get => _thermalExpansionCorrectionFactor; set => SetProperty(ref _thermalExpansionCorrectionFactor, value); }

    private double? _alcoholMeterCorrectionFactor = null;
    public double? AlcoholMeterCorrectionFactor { get => _alcoholMeterCorrectionFactor; set => SetProperty(ref _alcoholMeterCorrectionFactor, value); }

    private double? _kvCoefficient = null;
    public double? KvCoefficient { get => _kvCoefficient; set => SetProperty(ref _kvCoefficient, value); }

    public override void Reset()
    {
        base.Reset();
        VolumeOfEthanol = null;
        MeterReadingDifference = null;
        NotRecordedVolume = null;
        ThermalExpansionCorrectionFactor = null;
        AlcoholMeterCorrectionFactor = null;
        KvCoefficient = null;
    }
}
