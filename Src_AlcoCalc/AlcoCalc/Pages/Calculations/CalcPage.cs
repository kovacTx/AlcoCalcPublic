using AlcoCalc.Services;
using AlcoCalc.Utils;
using AlcoCalc.Values;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace AlcoCalc.Pages.Calculations;

public abstract class CalcPage : ComponentBase, IDisposable
{
    [Inject] protected NavigationManager Nav { get; set; } = null!;
    [Inject] protected Returner Returner { get; set; } = null!;
    protected abstract CalculatorValuesBase ValuesBase { get; }
    protected abstract ICalculatorBase CalculatorBase { get; }
    protected string? ResultStr => ValuesBase?.Result.Stringify0();

    protected override void OnInitialized()
    {
        Returner.OnChangedAsync -= OnReturnerChanged;
        Returner.OnChangedAsync += OnReturnerChanged;
        Task.Run(async () =>
        {
            await Task.Delay(100);
            CommonData.HomeButtonVisible = false;
            CommonData.BackButtonVisible = true;
            CommonData.ResetButtonVisible = true;
        });
    }
    private Task OnReturnerChanged()
        => InvokeAsync(StateHasChanged);
    protected async Task GoTo(string where, Action<double?> onReturn)
    {
        await Returner.AddReturn("/" + Nav.ToBaseRelativePath(Nav.Uri),
             ret =>
             {
                 onReturn(ret);
                 StateHasChanged();
             });
        Returner.OneTimeIgnoreClear();
        Nav.NavigateTo(where, replace: true);
    }
    /// <summary>
    /// in case of unsuccesfull parsing, it leave the invalid string in place
    /// </summary>
    /// <param name="value"></param>
    /// <param name="resultSetter"></param>
    /// <param name="successStringSetter"></param>
    /// <param name="errorMsg"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    protected void SetValue(ref string? value, Action<double?> resultSetter, Func<double?, double?> clamper, string? errorMsg = null)
    {
        if (string.IsNullOrEmpty(value))
        {
            resultSetter(null);
            value = null;
        }
        else
        {
            value = value.Replace(',', '.');
            if (!double.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var result))
            {
                (errorMsg ?? $"Text {value} nieje možné previesť na číslo").AsError();
                resultSetter(null);
            }
            else
            {
                var clamped = clamper(result);
                resultSetter(clamped);
                if (clamped != result)
                    value = clamped.Stringify();
            }
        }
        OnInputChanged();
    }
    protected void SetValue(double? value, Action<double?> resultSetter, Func<double?, double?> clamp, string? errorMsg = null)
    {
        if (value is null)
        {
            resultSetter(null);
        }
        else
        {
            var clamped = clamp(value);
            resultSetter(clamped);
        }
        OnInputChanged();
    }
    protected virtual double? ClampValue(double? value, double min, double max)
    {
        if (value is null || double.IsNaN(value.Value))
            return null;
        if (value < min || value > max)
        {
            $"Číslo {value.Value} je mimo dovolený rozsah".AsError();
            return null;
        }
        return value.Value.Clamp(min, max);
    }

    protected void OnInputChanged()
    {
        CalculatorBase.Calculate(ValuesBase);
        StateHasChanged();
    }
    protected void TryReturn()
        => Returner.TryReturn(ValuesBase.Result);
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Returner.OnChangedAsync -= OnReturnerChanged;
        CommonData.HomeButtonVisible = false;
        CommonData.BackButtonVisible = false;
        CommonData.ResetButtonVisible = false;
    }
}
