using AlcoCalc.Services;
using AlcoCalc.Utils;
using AlcoCalc.Values;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AlcoCalc.Pages.Calculations;

public partial class _1A_1 : CalcPage
{
    public const string ErrMessage = "nieje možné výpočítať hustotu liehu z hmotnostného zlomku etanolu a teploty";
    [Inject] Calculator1A_1 Calculator { get; set; } = null!;
    [Inject] CalculatorValues AllValues { get; set; } = null!;

    private CalculatorValues1A_1 Values => AllValues._1A_1;
    override protected CalculatorValuesBase ValuesBase => Values;
    override protected ICalculatorBase CalculatorBase => Calculator;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SetEthanolMassFractionStr(Values.EthanolMassFraction);
        SetAlcoholTemperatureStr(Values.AlcoholTemperature);
    }

    #region ethanolMassFraction
    private MudTextField<string> ethanolMassFractionInput = null!;
    private string? ethanolMassFraction;
    private void SetEthanolMassFractionStr(double? value)
        => ethanolMassFraction = value.Stringify();
    private void SetEthanolMassFraction(double? value)
        => SetValue(value,
            d => Values.EthanolMassFraction = d,
            d => ClampValue(d, Calculator1A_1.EthanolMassFractionMin, Calculator1A_1.EthanolMassFractionMax));
    private async Task OnEthanolMassFractionChanged(string? value)
    {
        ethanolMassFraction = value?.FilterNumericInput();
        await ethanolMassFractionInput.SetTextAsync(ethanolMassFraction);
        OnInputChanged();
    }
    private void OnEthanolMassFractionBlur(FocusEventArgs _)
    {
        SetValue(ref ethanolMassFraction,
            d => Values.EthanolMassFraction = d,
            d => ClampValue(d, Calculator1A_1.EthanolMassFractionMin, Calculator1A_1.EthanolMassFractionMax));
        OnInputChanged();
    }
    private async Task OnEthanolMassFractionKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await ethanolMassFractionInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await alcoholTemperatureInput.FocusAsync();
    }
    #endregion
    #region alcoholTemperature
    private MudTextField<string> alcoholTemperatureInput = null!;
    private string? alcoholTemperature;
    private void SetAlcoholTemperatureStr(double? value)
        => alcoholTemperature = value.Stringify();
    private void SetAlcoholTemperature(double? value)
        => SetValue(value,
            d => Values.AlcoholTemperature = d,
            d => ClampValue(d, Calculator1A_1.AlcoholTemperatureMin, Calculator1A_1.AlcoholTemperatureMax));
    private async Task OnAlcoholTemperatureChanged(string? value)
    {
        alcoholTemperature = value?.FilterNumericInput();
        await alcoholTemperatureInput.SetTextAsync(alcoholTemperature);
        OnInputChanged();
    }
    private void OnAlcoholTemperatureBlur(FocusEventArgs _)
    {
        SetValue(ref alcoholTemperature,
            d => Values.AlcoholTemperature = d,
            d => ClampValue(d, Calculator1A_1.AlcoholTemperatureMin, Calculator1A_1.AlcoholTemperatureMax));
        OnInputChanged();
    }
    private async Task OnAlcoholTemperatureKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await ethanolMassFractionInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result.FocusAsync();
    }
    #endregion

    private MudTextField<string?> result = null!;
    private async Task OnResultKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await alcoholTemperatureInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result.FocusAsync();
    }

}
