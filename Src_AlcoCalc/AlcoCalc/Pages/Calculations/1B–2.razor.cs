using AlcoCalc.Services;
using AlcoCalc.Utils;
using AlcoCalc.Values;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AlcoCalc.Pages.Calculations;

public partial class _1B_2 : CalcPage
{
    public const string ErrMessage = "nieje možné vypočítať objemovú koncentráciu etanolu pri 20°C z údaja liehomera a teploty merania";

    [Inject] Calculator1B_2 Calculator { get; set; } = null!;
    [Inject] CalculatorValues AllValues { get; set; } = null!;

    private CalculatorValues1B_2 Values => AllValues._1B_2;
    override protected CalculatorValuesBase ValuesBase => Values;
    override protected ICalculatorBase CalculatorBase => Calculator;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SetAlcoholometerReadingStr(Values.AlcoholometerReading);
        SetTemperatureStr(Values.Temperature);
    }

    #region alcoholometerReading
    private MudTextField<string> alcoholometerReadingInput = null!;
    private string? alcoholometerReading;
    private void SetAlcoholometerReadingStr(double? value)
        => alcoholometerReading = value.Stringify();
    private void SetAlcoholometerReading(double? value)
        => SetValue(value,
            d => Values.AlcoholometerReading = d,
            d => ClampValue(d, Calculator1B_2.AlcoholometerReadingMin, Calculator1B_2.AlcoholometerReadingMax));
    private async Task OnAlcoholometerReadingChanged(string? value)
    {
        alcoholometerReading = value?.FilterNumericInput();
        await alcoholometerReadingInput.SetTextAsync(alcoholometerReading);
        OnInputChanged();
    }
    private void OnAlcoholometerReadingBlur(FocusEventArgs _)
    {
        SetValue(ref alcoholometerReading,
            d => Values.AlcoholometerReading = d,
            d => ClampValue(d, Calculator1B_2.AlcoholometerReadingMin, Calculator1B_2.AlcoholometerReadingMax));
        OnInputChanged();
    }
    private async Task OnAlcoholometerReadingKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await alcoholometerReadingInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await temperatureInput.FocusAsync();
    }
    #endregion
    #region temperature
    private MudTextField<string> temperatureInput = null!;
    private string? temperature;
    private void SetTemperatureStr(double? value)
        => temperature = value.Stringify();
    private void SetTemperature(double? value)
        => SetValue(value,
            d => Values.Temperature = d,
            d => ClampValue(d, Calculator1B_2.TemperatureMin, Calculator1B_2.TemperatureMax));
    private async Task OnTemperatureChanged(string? value)
    {
        temperature = value?.FilterNumericInput();
        await temperatureInput.SetTextAsync(temperature);
        OnInputChanged();
    }
    private void OnTemperatureBlur(FocusEventArgs _)
    {
        SetValue(ref temperature,
            d => Values.Temperature = d,
            d => ClampValue(d, Calculator1B_2.TemperatureMin, Calculator1B_2.TemperatureMax));
        OnInputChanged();
    }
    private async Task OnTemperatureKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await alcoholometerReadingInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result.FocusAsync();
    }
    #endregion

    private MudTextField<string?> result = null!;
    private async Task OnResultKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await temperatureInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result.FocusAsync();
    }

}
