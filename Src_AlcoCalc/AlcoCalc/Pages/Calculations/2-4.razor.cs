using AlcoCalc.Services;
using AlcoCalc.Utils;
using AlcoCalc.Values;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AlcoCalc.Pages.Calculations;

public partial class _2_4 : CalcPage
{
    public const string ErrMessage = "nieje možné vypočítať objem etanolu z objemu zmesi zisteného kontrolným liehovým meradlom";
    [Inject] Calculator2_4 Calculator { get; set; } = null!;
    [Inject] CalculatorValues AllValues { get; set; } = null!;

    private CalculatorValues2_4 Values => AllValues._2_4;
    override protected CalculatorValuesBase ValuesBase => Values;
    override protected ICalculatorBase CalculatorBase => Calculator;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SetVolumeOfEthanolStr(Values.VolumeOfEthanol);
        SetMeterReadingDifferenceStr(Values.MeterReadingDifference);
        SetNotRecordedVolumeStr(Values.NotRecordedVolume);
        SetThermalExpansionCorrectionFactorStr(Values.ThermalExpansionCorrectionFactor);
        SetAlcoholMeterCorrectionFactorStr(Values.AlcoholMeterCorrectionFactor);
        SetKvCoefficientStr(Values.KvCoefficient);
    }

    #region volumeOfEthanol
    private MudTextField<string> volumeOfEthanolInput = null!;
    private string? volumeOfEthanol;
    private void SetVolumeOfEthanolStr(double? value)
        => volumeOfEthanol = value.Stringify();
    private void SetVolumeOfEthanol(double? value)
        => SetValue(value,
            d => Values.VolumeOfEthanol = d,
            d => ClampValue(d, Calculator2_4.VolumeOfEthanolMin, Calculator2_4.VolumeOfEthanolMax));
    private async Task OnVolumeOfEthanolChanged(string? value)
    {
        volumeOfEthanol = value?.FilterNumericInput();
        await volumeOfEthanolInput.SetTextAsync(volumeOfEthanol);
        OnInputChanged();
    }
    private void OnVolumeOfEthanolBlur(FocusEventArgs _)
    {
        SetValue(ref volumeOfEthanol,
            d => Values.VolumeOfEthanol = d,
            d => ClampValue(d, Calculator2_4.VolumeOfEthanolMin, Calculator2_4.VolumeOfEthanolMax));
        OnInputChanged();
    }
    private async Task OnVolumeOfEthanolKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await volumeOfEthanolInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await meterReadingDifferenceInput.FocusAsync();
    }
    #endregion
    #region meterReadingDifference
    private MudTextField<string> meterReadingDifferenceInput = null!;
    private string? meterReadingDifference;
    private void SetMeterReadingDifferenceStr(double? value)
        => meterReadingDifference = value.Stringify();
    private void SetMeterReadingDifference(double? value)
        => SetValue(value,
            d => Values.MeterReadingDifference = d,
            d => ClampValue(d, Calculator2_4.MeterReadingDifferenceMin, Calculator2_4.MeterReadingDifferenceMax));
    private async Task OnMeterReadingDifferenceChanged(string? value)
    {
        meterReadingDifference = value?.FilterNumericInput();
        await meterReadingDifferenceInput.SetTextAsync(meterReadingDifference);
        OnInputChanged();
    }
    private void OnMeterReadingDifferenceBlur(FocusEventArgs _)
    {
        SetValue(ref meterReadingDifference,
            d => Values.MeterReadingDifference = d,
            d => ClampValue(d, Calculator2_4.MeterReadingDifferenceMin, Calculator2_4.MeterReadingDifferenceMax));
        OnInputChanged();
    }
    private async Task OnMeterReadingDifferenceKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await volumeOfEthanolInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await notRecordedVolumeInput.FocusAsync();
    }
    #endregion
    #region notRecordedVolume
    private MudTextField<string> notRecordedVolumeInput = null!;
    private string? notRecordedVolume;
    private void SetNotRecordedVolumeStr(double? value)
        => notRecordedVolume = value.Stringify();
    private void SetNotRecordedVolume(double? value)
        => SetValue(value,
            d => Values.NotRecordedVolume = d,
            d => ClampValue(d, Calculator2_4.NotRecordedVolumeMin, Calculator2_4.NotRecordedVolumeMax));
    private async Task OnNotRecordedVolumeChanged(string? value)
    {
        notRecordedVolume = value?.FilterNumericInput();
        await notRecordedVolumeInput.SetTextAsync(notRecordedVolume);
        OnInputChanged();
    }
    private void OnNotRecordedVolumeBlur(FocusEventArgs _)
    {
        SetValue(ref notRecordedVolume,
            d => Values.NotRecordedVolume = d,
            d => ClampValue(d, Calculator2_4.NotRecordedVolumeMin, Calculator2_4.NotRecordedVolumeMax));
        OnInputChanged();
    }
    private async Task OnNotRecordedVolumeKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await meterReadingDifferenceInput.FocusAsync();
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
            d => ClampValue(d, Calculator2_4.ThermalExpansionCorrectionFactorMin, Calculator2_4.ThermalExpansionCorrectionFactorMax));
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
            d => ClampValue(d, Calculator2_4.ThermalExpansionCorrectionFactorMin, Calculator2_4.ThermalExpansionCorrectionFactorMax));
        OnInputChanged();
    }
    private async Task OnThermalExpansionCorrectionFactorKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await notRecordedVolumeInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await alcoholMeterCorrectionFactorInput.FocusAsync();
    }
    #endregion
    #region alcoholMeterCorrectionFactor
    private MudTextField<string> alcoholMeterCorrectionFactorInput = null!;
    private string? alcoholMeterCorrectionFactor;
    private void SetAlcoholMeterCorrectionFactorStr(double? value)
        => alcoholMeterCorrectionFactor = value.Stringify();
    private void SetAlcoholMeterCorrectionFactor(double? value)
        => SetValue(value,
            d => Values.AlcoholMeterCorrectionFactor = d,
            d => ClampValue(d, Calculator2_4.AlcoholMeterCorrectionFactorMin, Calculator2_4.AlcoholMeterCorrectionFactorMax));
    private async Task OnAlcoholMeterCorrectionFactorChanged(string? value)
    {
        alcoholMeterCorrectionFactor = value?.FilterNumericInput();
        await alcoholMeterCorrectionFactorInput.SetTextAsync(alcoholMeterCorrectionFactor);
        OnInputChanged();
    }
    private void OnAlcoholMeterCorrectionFactorBlur(FocusEventArgs _)
    {
        SetValue(ref alcoholMeterCorrectionFactor,
            d => Values.AlcoholMeterCorrectionFactor = d,
            d => ClampValue(d, Calculator2_4.AlcoholMeterCorrectionFactorMin, Calculator2_4.AlcoholMeterCorrectionFactorMax));
        OnInputChanged();
    }
    private async Task OnAlcoholMeterCorrectionFactorKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await thermalExpansionCorrectionFactorInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await kvCoefficientInput.FocusAsync();
    }
    #endregion
    #region kvCoefficient
    private MudTextField<string> kvCoefficientInput = null!;
    private string? kvCoefficient;
    private void SetKvCoefficientStr(double? value)
        => kvCoefficient = value.Stringify();
    private void SetKvCoefficient(double? value)
        => SetValue(value,
            d => Values.KvCoefficient = d,
            d => ClampValue(d, Calculator2_4.KvCoefficientMin, Calculator2_4.KvCoefficientMax));
    private async Task OnKvCoefficientChanged(string? value)
    {
        kvCoefficient = value?.FilterNumericInput();
        await kvCoefficientInput.SetTextAsync(kvCoefficient);
        OnInputChanged();
    }
    private void OnKvCoefficientBlur(FocusEventArgs _)
    {
        SetValue(ref kvCoefficient,
            d => Values.KvCoefficient = d,
            d => ClampValue(d, Calculator2_4.KvCoefficientMin, Calculator2_4.KvCoefficientMax));
        OnInputChanged();
    }
    private async Task OnKvCoefficientKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await alcoholMeterCorrectionFactorInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result.FocusAsync();
    }
    #endregion

    private MudTextField<string?> result = null!;
    private async Task OnResultKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await kvCoefficientInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result.FocusAsync();
    }

}
