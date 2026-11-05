using AlcoCalc.Services;
using AlcoCalc.Utils;
using AlcoCalc.Values;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AlcoCalc.Pages.Calculations;

public partial class _1A_5 : CalcPage
{
    public const string ErrMessage = "nieje možné vypočítať korekčný súčiniteľ Fa na vztlak vzduchu pri vážení";

    [Inject] Calculator1A_5 Calculator { get; set; } = null!;
    [Inject] CalculatorValues AllValues { get; set; } = null!;

    private CalculatorValues1A_5 Values => AllValues._1A_5;
    override protected CalculatorValuesBase ValuesBase => Values;
    override protected ICalculatorBase CalculatorBase => Calculator;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SetLiquidDensityStr(Values.LiquidDensity);
        SetAirDensityStr(Values.AirDensity);
    }

    #region liquidDensity
    private MudTextField<string> liquidDensityInput = null!;
    private string? liquidDensity;
    private void SetLiquidDensityStr(double? value)
        => liquidDensity = value.Stringify();
    private void SetLiquidDensity(double? value)
        => SetValue(value,
            d => Values.LiquidDensity = d,
            d => ClampValue(d, Calculator1A_5.LiquidDensityMin, Calculator1A_5.LiquidDensityMax));
    private async Task OnLiquidDensityChanged(string? value)
    {
        liquidDensity = value?.FilterNumericInput();
        await liquidDensityInput.SetTextAsync(liquidDensity);
        OnInputChanged();
    }
    private void OnLiquidDensityBlur(FocusEventArgs _)
    {
        SetValue(ref liquidDensity,
            d => Values.LiquidDensity = d,
            d => ClampValue(d, Calculator1A_5.LiquidDensityMin, Calculator1A_5.LiquidDensityMax));
        OnInputChanged();
    }
    private async Task OnLiquidDensityKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await liquidDensityInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await airDensityInput.FocusAsync();
    }
    #endregion
    #region airDensity
    private MudTextField<string> airDensityInput = null!;
    private string? airDensity;
    private void SetAirDensityStr(double? value)
        => airDensity = value.Stringify();
    private void SetAirDensity(double? value)
        => SetValue(value,
            d => Values.AirDensity = d,
            d => ClampValue(d, Calculator1A_5.AirDensityMin, Calculator1A_5.AirDensityMax));
    private async Task OnAirDensityChanged(string? value)
    {
        airDensity = value?.FilterNumericInput();
        await airDensityInput.SetTextAsync(airDensity);
        OnInputChanged();
    }
    private void OnAirDensityBlur(FocusEventArgs _)
    {
        SetValue(ref airDensity,
            d => Values.AirDensity = d,
            d => ClampValue(d, Calculator1A_5.AirDensityMin, Calculator1A_5.AirDensityMax));
        OnInputChanged();
    }
    private async Task OnAirDensityKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await liquidDensityInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result.FocusAsync();
    }
    #endregion

    private MudTextField<string?> result = null!;
    private async Task OnResultKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await airDensityInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result.FocusAsync();
    }

}
