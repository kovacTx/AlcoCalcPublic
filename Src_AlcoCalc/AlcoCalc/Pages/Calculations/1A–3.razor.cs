using AlcoCalc.Services;
using AlcoCalc.Utils;
using AlcoCalc.Values;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AlcoCalc.Pages.Calculations;

public partial class _1A_3 : CalcPage
{
    public const string ErrMessage = "nieje možné prepočítať objemovú koncentráciu pri 20 °C na hmotnostný zlomok etanolu";
    [Inject] Calculator1A_3 Calculator { get; set; } = null!;
    [Inject] CalculatorValues AllValues { get; set; } = null!;

    protected CalculatorValues1A_3 Values => AllValues._1A_3;
    override protected CalculatorValuesBase ValuesBase => Values;
    override protected ICalculatorBase CalculatorBase => Calculator;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SetVolumeConcentrationStr(Values.VolumeConcentration);
    }

    #region volumeConcentration
    private MudTextField<string> volumeConcentrationInput = null!;
    private string? volumeConcentration;
    private void SetVolumeConcentrationStr(double? value)
        => volumeConcentration = value.Stringify();
    private void SetVolumeConcentration(double? value)
        => SetValue(value,
            d => Values.VolumeConcentration = d,
            d => ClampValue(d, Calculator1A_3.VolumeConcentrationMin, Calculator1A_3.VolumeConcentrationMax));
    private async Task OnVolumeConcentrationChanged(string? value)
    {
        volumeConcentration = value?.FilterNumericInput();
        await volumeConcentrationInput.SetTextAsync(volumeConcentration);
        OnInputChanged();
    }
    private void OnVolumeConcentrationBlur(FocusEventArgs _)
    {
        SetValue(ref volumeConcentration,
            d => Values.VolumeConcentration = d,
            d => ClampValue(d, Calculator1A_3.VolumeConcentrationMin, Calculator1A_3.VolumeConcentrationMax));
        OnInputChanged();
    }
    private async Task OnVolumeConcentrationKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await volumeConcentrationInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result.FocusAsync();
    }
    #endregion

    private MudTextField<string?> result = null!;
    private async Task OnResultKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await volumeConcentrationInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result.FocusAsync();
    }

}
