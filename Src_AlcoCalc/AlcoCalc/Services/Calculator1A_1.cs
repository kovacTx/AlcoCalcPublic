using AlcoCalc.Values;

namespace AlcoCalc.Services;

public class Calculator1A_1 : CalculatorBase<CalculatorValues1A_1>
{
    public const string CalculatorName = "1A-1";

    public static double EthanolMassFractionMin => 0;
    public static double EthanolMassFractionMax => 100;

    public static double AlcoholTemperatureMin => -20;
    public static double AlcoholTemperatureMax => 40;

    protected override void DoCalc(CalculatorValues1A_1 values)
    {
        values.Result = null;
        if (IsEmpty(values.EthanolMassFraction)) return;
        if (IsEmpty(values.AlcoholTemperature)) return;

        ValidateRange(values.EthanolMassFraction, nameof(values.EthanolMassFraction), "Ethanol mass fraction", EthanolMassFractionMin, EthanolMassFractionMax, CalculatorName);
        ValidateRange(values.AlcoholTemperature, nameof(values.AlcoholTemperature), "Alcohol temperature", AlcoholTemperatureMin, AlcoholTemperatureMax, CalculatorName);

        DoCalcWithoutPreCheck(values);
    }
    public static void DoCalcWithoutPreCheck(CalculatorValues1A_1 values)
    {
        values.Result = null;

        var p = values.EthanolMassFraction!.Value / 100.0;
        var t = values.AlcoholTemperature!.Value;

        values.Result = ObjKon(p, t);
    }

    private static double ObjKon(double p, double t)
    {
        return
            Constants.OimlA[0]
            + Suma1(p)
            + Suma2(t)
            + Suma32(p, t);
    }
    private static double Suma1(double p)
    {
        double result = 0;

        for (int i = 1; i < 12; i++)
        {
            result += Constants.OimlA[i] * Math.Pow(p, i);
        }

        return result;
    }
    private static double Suma2(double t)
    {
        double result = 0;

        for (int i = 0; i < 6; i++)
        {
            result += Constants.OimlB[i] * Math.Pow(t - 20, i + 1);
        }

        return result;
    }
    private static double Suma32(double p, double t)
    {
        double result = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < Constants.OimlP[i]; j++)
            {
                double r = i switch
                {
                    0 => Constants.OimlC[j],
                    1 => Constants.OimlD[j],
                    2 => Constants.OimlE[j],
                    3 => Constants.OimlF[j],
                    4 => Constants.OimlG[j],
                    _ => 0
                };

                result += r *
                    Math.Pow(p, j + 1) *
                    Math.Pow(t - 20, i + 1);
            }
        }

        return result;
    }
}