namespace AlcoCalc.Values;

public class CalculatorValues1B_2 : CalculatorValuesBase
{
    private double? _alcoholometerReading = null;
    public double? AlcoholometerReading { get => _alcoholometerReading; set => SetProperty(ref _alcoholometerReading, value); }

    private double? _temperature = null;
    public double? Temperature { get => _temperature; set => SetProperty(ref _temperature, value); }

    public override void Reset()
    {
        base.Reset();
        AlcoholometerReading = null;
        Temperature = null;
    }
}
