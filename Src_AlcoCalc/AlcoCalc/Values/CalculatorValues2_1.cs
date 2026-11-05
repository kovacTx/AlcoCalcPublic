namespace AlcoCalc.Values;

public class CalculatorValues2_1 : CalculatorValuesBase
{
    private double? _apparentMass = null;
    public double? ApparentMass { get => _apparentMass; set => SetProperty(ref _apparentMass, value); }

    private double? _volumeConcentration = null;
    public double? VolumeConcentration { get => _volumeConcentration; set => SetProperty(ref _volumeConcentration, value); }

    private double? _volumeOfEthanol = null;
    public double? VolumeOfEtanol { get => _volumeOfEthanol; set => SetProperty(ref _volumeOfEthanol, value); }

    public override void Reset()
    {
        base.Reset();
        ApparentMass = null;
        VolumeConcentration = null;
        VolumeOfEtanol = null;
    }
}
