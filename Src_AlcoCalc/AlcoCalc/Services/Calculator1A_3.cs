using AlcoCalc.Values;

namespace AlcoCalc.Services;

public class Calculator1A_3 : CalculatorBase<CalculatorValues1A_3>
{
    public const string CalculatorName = "1A-3";

    public static double VolumeConcentrationMin => 0;
    public static double VolumeConcentrationMax => 100;

    protected override void DoCalc(CalculatorValues1A_3 values)
    {
        if (IsEmpty(values.VolumeConcentration)) return;

        ValidateRange(values.VolumeConcentration, nameof(values.VolumeConcentration), "Volume concentration percent", VolumeConcentrationMin, VolumeConcentrationMax, CalculatorName);

        DoCalcWithoutPreCheck(values);
    }
    public static void DoCalcWithoutPreCheck(CalculatorValues1A_3 values)
    {
        var _1A_1Values = new CalculatorValues1A_1()
        {
            AlcoholTemperature = 20
        };
        var previous = 1000.0;
        values.Result = values.VolumeConcentration;

        while (Math.Abs(values.Result!.Value - previous) >= 0.001)
        {
            previous = values.Result.Value;
            _1A_1Values.EthanolMassFraction = previous;
            Calculator1A_1.DoCalcWithoutPreCheck(_1A_1Values);

            if (_1A_1Values.Result is null)
                throw new InvalidOperationException($"{CalculatorName}: cannot calculate further");

            values.Result = values.VolumeConcentration!.Value * Constants.EthanolDensity / _1A_1Values.Result.Value;
        }
    }
}