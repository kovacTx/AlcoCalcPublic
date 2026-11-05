namespace AlcoCalc.Values;

public class CalculatorValues1A_5 : CalculatorValuesBase
{
    private double? _liquidDensity = null;
    public double? LiquidDensity { get => _liquidDensity; set => SetProperty(ref _liquidDensity, value); }

    private double? _airDensity = null;
    public double? AirDensity { get => _airDensity; set => SetProperty(ref _airDensity, value); }

    public override void Reset()
    {
        base.Reset();
        LiquidDensity = null;
        AirDensity = null;
    }
}
