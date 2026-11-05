namespace AlcoCalc.Values;

public class CalculatorValues1A_8 : CalculatorValuesBase
{
    private double? _waterTemperature = null;
    public double? WaterTemperature { get => _waterTemperature; set => SetProperty(ref _waterTemperature, value); }

    private double? _waterDensity = null;
    public double? WaterDensity { get => _waterDensity; set => SetProperty(ref _waterDensity, value); }

    public override void Reset()
    {
        base.Reset();
        WaterTemperature = null;
        WaterDensity = null;
    }
}
