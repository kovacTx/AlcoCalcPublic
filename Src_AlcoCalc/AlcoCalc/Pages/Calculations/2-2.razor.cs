using AlcoCalc.Services;
using AlcoCalc.Utils;
using AlcoCalc.Values;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AlcoCalc.Pages.Calculations;

public partial class _2_2 : CalcPage
{
    public const string ErrMessage = "nieje možné vypočítať objem etanolu z objemu liehu, objemovej koncentrácie a teploty";
    [Inject] Calculator2_2 Calculator { get; set; } = null!;
    [Inject] CalculatorValues AllValues { get; set; } = null!;

    private CalculatorValues2_2 Values => AllValues._2_2;
    override protected CalculatorValuesBase ValuesBase => Values;
    override protected ICalculatorBase CalculatorBase => Calculator;

    private string? VolumeOfEthanolStr => Values.VolumeOfEthanol.Stringify0();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SetVolumeOfLoadStr(Values.VolumeOfLoad);
        SetVolumeConcentrationStr(Values.VolumeConcentration);
        SetAlcoholTemperatureStr(Values.AlcoholTemperature);
        SetThermalExpansionCorrectionFactorStr(Values.ThermalExpansionCorrectionFactor);
    }

    #region volumeOfLoad
    private MudTextField<string> volumeOfLoadInput = null!;
    private string? volumeOfLoad;
    private void SetVolumeOfLoadStr(double? value)
        => volumeOfLoad = value.Stringify();
    private void SetVolumeOfLoad(double? value)
        => SetValue(value,
            d => Values.VolumeOfLoad = d,
            d => ClampValue(d, Calculator2_2.VolumeOfLoadMin, Calculator2_2.VolumeOfLoadMax));
    private async Task OnVolumeOfLoadChanged(string? value)
    {
        volumeOfLoad = value?.FilterNumericInput();
        await volumeOfLoadInput.SetTextAsync(volumeOfLoad);
        OnInputChanged();
    }
    private void OnVolumeOfLoadBlur(FocusEventArgs _)
    {
        SetValue(ref volumeOfLoad,
            d => Values.VolumeOfLoad = d,
            d => ClampValue(d, Calculator2_2.VolumeOfLoadMin, Calculator2_2.VolumeOfLoadMax));
        OnInputChanged();
    }
    private async Task OnVolumeOfLoadKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await volumeOfLoadInput.FocusAsync();
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
            d => ClampValue(d, Calculator2_2.VolumeConcentrationMin, Calculator2_2.VolumeConcentrationMax));
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
            d => ClampValue(d, Calculator2_2.VolumeConcentrationMin, Calculator2_2.VolumeConcentrationMax));
        OnInputChanged();
    }
    private async Task OnVolumeConcentrationKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await volumeOfLoadInput.FocusAsync();
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
            d => ClampValue(d, Calculator2_2.AlcoholTemperatureMin, Calculator2_2.AlcoholTemperatureMax));
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
            d => ClampValue(d, Calculator2_2.AlcoholTemperatureMin, Calculator2_2.AlcoholTemperatureMax));
        OnInputChanged();
    }
    private async Task OnAlcoholTemperatureKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await volumeConcentrationInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await thermalExpansionCorrectionFactorInput.FocusAsync();
    }
    #endregion
    #region thermalExpansionCorrectionFactor
    private MudTextField<string> thermalExpansionCorrectionFactorInput = null!;
    private string? thermalExpansionCorrectionFactor;
    private void SetThermalExpansionCorrectionFactorStr(double? value)
        => thermalExpansionCorrectionFactor = value.Stringify();
    private void SetThermalExpansionCorrectionFactor(double? value)
        => SetValue(value,
            d => Values.ThermalExpansionCorrectionFactor = d,
            d => ClampValue(d, Calculator2_2.ThermalExpansionCorrectionFactorMin, Calculator2_2.ThermalExpansionCorrectionFactorMax));
    private async Task OnThermalExpansionCorrectionFactorChanged(string? value)
    {
        thermalExpansionCorrectionFactor = value?.FilterNumericInput();
        await thermalExpansionCorrectionFactorInput.SetTextAsync(thermalExpansionCorrectionFactor);
        OnInputChanged();
    }
    private void OnThermalExpansionCorrectionFactorBlur(FocusEventArgs _)
    {
        SetValue(ref thermalExpansionCorrectionFactor,
            d => Values.ThermalExpansionCorrectionFactor = d,
            d => ClampValue(d, Calculator2_2.ThermalExpansionCorrectionFactorMin, Calculator2_2.ThermalExpansionCorrectionFactorMax));
        OnInputChanged();
    }
    private async Task OnThermalExpansionCorrectionFactorKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await alcoholTemperatureInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result.FocusAsync();
    }
    #endregion

    private MudTextField<string?> result = null!;
    private async Task OnResultKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await thermalExpansionCorrectionFactorInput.FocusAsync();
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
