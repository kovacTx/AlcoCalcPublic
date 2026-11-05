using AlcoCalc.Services;
using AlcoCalc.Utils;
using AlcoCalc.Values;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AlcoCalc.Pages.Calculations;

public partial class _2_1
{
    public const string ErrMessage = "nieje možné vypočítať objem etanolu zo zdanlivej hmotnosti liehu a objemovej koncentrácie pri 20°C";
    [Inject] Calculator2_1 Calculator { get; set; } = null!;
    [Inject] CalculatorValues AllValues { get; set; } = null!;

    private CalculatorValues2_1 Values => AllValues._2_1;
    override protected CalculatorValuesBase ValuesBase => Values;
    override protected ICalculatorBase CalculatorBase => Calculator;

    private string? VolumeOfEtanolStr => Values.VolumeOfEtanol.Stringify0();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SetApparentMassStr(Values.ApparentMass);
        SetVolumeConcentrationStr(Values.VolumeConcentration);
    }

    #region apparentMass
    private MudTextField<string> apparentMassInput = null!;
    private string? apparentMass;
    private void SetApparentMassStr(double? value)
        => apparentMass = value.Stringify();
    private void SetApparentMass(double? value)
        => SetValue(value,
            d => Values.ApparentMass = d,
            d => ClampValue(d, Calculator2_1.ApparentMassMin, Calculator2_1.ApparentMassMax));
    private async Task OnApparentMassChanged(string? value)
    {
        apparentMass = value?.FilterNumericInput();
        await apparentMassInput.SetTextAsync(apparentMass);
        OnInputChanged();
    }
    private void OnApparentMassBlur(FocusEventArgs _)
    {
        SetValue(ref apparentMass,
            d => Values.ApparentMass = d,
            d => ClampValue(d, Calculator2_1.ApparentMassMin, Calculator2_1.ApparentMassMax));
        OnInputChanged();
    }
    private async Task OnApparentMassKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await apparentMassInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await volumeConcentrationInput.FocusAsync();
    }
    #endregion
    #region volumeConcentration
    private MudTextField<string> volumeConcentrationInput = null!;
    private string? volumeConcentration;
    private void SetVolumeConcentrationStr(double? value)
        => volumeConcentration = value.Stringify();
    private void SetVolumeConcentration(double? value)
        => SetValue(value,
            d => Values.VolumeConcentration = d,
            d => ClampValue(d, Calculator2_1.VolumeConcentrationMin, Calculator2_1.VolumeConcentrationMax));
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
            d => ClampValue(d, Calculator2_1.VolumeConcentrationMin, Calculator2_1.VolumeConcentrationMax));
        OnInputChanged();
    }
    private async Task OnVolumeConcentrationKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await apparentMassInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result.FocusAsync();
    }
    #endregion

    private MudTextField<string?> result = null!;
    private async Task OnResultKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await volumeConcentrationInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result2.FocusAsync();
    }

    private MudTextField<string?> result2 = null!;
    private async Task OnResult2KeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await result.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result2.FocusAsync();
    }

}
