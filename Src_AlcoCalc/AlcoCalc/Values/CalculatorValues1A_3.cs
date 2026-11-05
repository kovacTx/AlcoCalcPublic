namespace AlcoCalc.Values;

public class CalculatorValues1A_3 : CalculatorValuesBase
{
    private double? _volumeFractionPercent = null;
    public double? VolumeConcentration { get => _volumeFractionPercent; set => SetProperty(ref _volumeFractionPercent, value); }

    public override void Reset()
    {
        base.Reset();
        VolumeConcentration = null;
    }
}
