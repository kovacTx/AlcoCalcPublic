namespace AlcoCalc.Values;

public class CalculatorValues1A_1 : CalculatorValuesBase
{
    private double? _massFractionPercent = null;
    public double? EthanolMassFraction { get => _massFractionPercent; set => SetProperty(ref _massFractionPercent, value); }

    private double? _temperature = null;
    public double? AlcoholTemperature { get => _temperature; set => SetProperty(ref _temperature, value); }

    public override void Reset()
    {
        base.Reset();
        EthanolMassFraction = null;
        AlcoholTemperature = null;
    }
}
