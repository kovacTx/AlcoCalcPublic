namespace AlcoCalc.Values;

public class CalculatorValues1A_2 : CalculatorValuesBase
{
    private double? _massFractionPercent = null;
    public double? EthanolMassFraction { get => _massFractionPercent; set => SetProperty(ref _massFractionPercent, value); }

    public override void Reset()
    {
        base.Reset();
        EthanolMassFraction = null;
    }
}
