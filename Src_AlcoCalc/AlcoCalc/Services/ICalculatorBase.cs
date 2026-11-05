using AlcoCalc.Values;

namespace AlcoCalc.Services;

public interface ICalculatorBase
{
    public void Calculate(CalculatorValuesBase values);
}