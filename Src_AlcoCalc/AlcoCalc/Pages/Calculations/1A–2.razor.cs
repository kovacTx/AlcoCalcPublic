using AlcoCalc.Services;
using AlcoCalc.Utils;
using AlcoCalc.Values;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AlcoCalc.Pages.Calculations;

public partial class _1A_2 : CalcPage
{
    public const string ErrMessage = "nieje možné prepočítať hmotnostný zlomok na objemovú koncentráciu etanolu pri 20 °C";
    [Inject] Calculator1A_2 Calculator { get; set; } = null!;
    [Inject] CalculatorValues AllValues { get; set; } = null!;

    private CalculatorValues1A_2 Values => AllValues._1A_2;
    override protected CalculatorValuesBase ValuesBase => Values;
    override protected ICalculatorBase CalculatorBase => Calculator;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SetEthanolMassFractionStr(Values.EthanolMassFraction);
    }

    #region ethanolMassFraction
    private MudTextField<string> ethanolMassFractionInput = null!;
    private string? ethanolMassFraction;
    private void SetEthanolMassFractionStr(double? value)
        => ethanolMassFraction = value.Stringify();
    private void SetEthanolMassFraction(double? value)
        => SetValue(value,
            d => Values.EthanolMassFraction = d,
            d => ClampValue(d, Calculator1A_2.EthanolMassFractionMin, Calculator1A_2.EthanolMassFractionMax));
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
            d => ClampValue(d, Calculator1A_2.EthanolMassFractionMin, Calculator1A_2.EthanolMassFractionMax));
        OnInputChanged();
    }
    private async Task OnEthanolMassFractionKeyDown(KeyboardEventArgs args)
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
        if (args.Key == "Tab" && args.ShiftKey) await ethanolMassFractionInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result.FocusAsync();
    }

}
