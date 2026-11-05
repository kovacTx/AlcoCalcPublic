using AlcoCalc.Values;

namespace AlcoCalc.Services;

public class Calculator1A_2 : CalculatorBase<CalculatorValues1A_2>
{
    public const string CalculatorName = "1A-2";

    public static double EthanolMassFractionMin => 0;
    public static double EthanolMassFractionMax => 100;

    protected override void DoCalc(CalculatorValues1A_2 values)
    {
        values.Result = null;
        if (IsEmpty(values.EthanolMassFraction)) return;

        ValidateRange(values.EthanolMassFraction, nameof(values.EthanolMassFraction), "Ethanol mass fraction", EthanolMassFractionMin, EthanolMassFractionMax, CalculatorName);

        var _1A_1Values = new CalculatorValues1A_1 { EthanolMassFraction = values.EthanolMassFraction, AlcoholTemperature = 20 };
        Calculator1A_1.DoCalcWithoutPreCheck(_1A_1Values);
        if (_1A_1Values.Result is null)
            throw new InvalidOperationException($"{CalculatorName}: cannot calculate further");

        values.Result = values.EthanolMassFraction!.Value * _1A_1Values.Result.Value / Constants.EthanolDensity;
    }

}