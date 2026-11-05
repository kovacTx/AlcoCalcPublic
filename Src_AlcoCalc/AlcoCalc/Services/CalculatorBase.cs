using AlcoCalc.Utils;
using AlcoCalc.Values;

namespace AlcoCalc.Services;

public abstract class CalculatorBase<T> : ICalculatorBase
    where T : CalculatorValuesBase
{
    public void Calculate(CalculatorValuesBase values)
    {
        if (values == null)
            throw new ArgumentNullException(nameof(values), "Values cannot be null.");
        if (values is not T t)
            throw new ArgumentNullException(nameof(values), $"Values cannot be different type than {typeof(T)}.");

        Calculate(t);
    }
    public void Calculate(T values)
    {
        if (values == null)
            throw new ArgumentNullException(nameof(values), "Values cannot be null.");
        try
        {
            DoCalc(values);
        }
        catch (Exception e)
        {
            e.AsError();
            values.Result = null;
        }
    }

    protected abstract void DoCalc(T values);
    protected void ValidateRange(double? value, string name, string description, double min, double max, string calculator)
    {
        if (value == null)
            throw new ArgumentNullException(name, $"{calculator}: {description} is required.");

        if (value < min || value > max)
            throw new ArgumentOutOfRangeException(name, $"{calculator}: {description} must be between {min} and {max}.");
    }
    protected bool IsEmpty(double? value)
    {
        if (value is null) return true;
        if (double.IsNaN(value.Value)) return true;
        return false;
    }
}