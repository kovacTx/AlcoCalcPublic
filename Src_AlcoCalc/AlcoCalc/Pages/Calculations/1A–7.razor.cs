using AlcoCalc.Services;
using AlcoCalc.Utils;
using AlcoCalc.Values;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AlcoCalc.Pages.Calculations;

public partial class _1A_7 : CalcPage
{
    public const string ErrMessage = "nieje možné vypočítať objem vody zo zdanlivej hmotnosti a teploty";

    [Inject] Calculator1A_7 Calculator { get; set; } = null!;
    [Inject] CalculatorValues AllValues { get; set; } = null!;

    private CalculatorValues1A_7 Values => AllValues._1A_7;
    override protected CalculatorValuesBase ValuesBase => Values;
    override protected ICalculatorBase CalculatorBase => Calculator;

    protected string? MassVolumeStr => Values?.MassVolume.Stringify0();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SetAirDensityStr(Values.AirDensity);
        SetLoadTemperatureStr(Values.LoadTemperature);
        SetLoadWeightStr(Values.LoadWeight);
    }

    #region airDensity
    private MudTextField<string> airDensityInput = null!;
    private string? airDensity;
    private void SetAirDensityStr(double? value)
        => airDensity = value.Stringify();
    private void SetAirDensity(double? value)
        => SetValue(value,
            d => Values.AirDensity = d,
            d => ClampValue(d, Calculator1A_7.AirDensityMin, Calculator1A_7.AirDensityMax));
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
            d => ClampValue(d, Calculator1A_7.AirDensityMin, Calculator1A_7.AirDensityMax));
        OnInputChanged();
    }
    private async Task OnAirDensityKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await airDensityInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await loadTemperatureInput.FocusAsync();
    }
    #endregion
    #region loadTemperature
    private MudTextField<string> loadTemperatureInput = null!;
    private string? loadTemperature;
    private void SetLoadTemperatureStr(double? value)
        => loadTemperature = value.Stringify();
    private void SetLoadTemperature(double? value)
        => SetValue(value,
            d => Values.LoadTemperature = d,
            d => ClampValue(d, Calculator1A_7.LoadTemperatureMin, Calculator1A_7.LoadTemperatureMax));
    private async Task OnLoadTemperatureChanged(string? value)
    {
        loadTemperature = value?.FilterNumericInput();
        await loadTemperatureInput.SetTextAsync(loadTemperature);
        OnInputChanged();
    }
    private void OnLoadTemperatureBlur(FocusEventArgs _)
    {
        SetValue(ref loadTemperature,
            d => Values.LoadTemperature = d,
            d => ClampValue(d, Calculator1A_7.LoadTemperatureMin, Calculator1A_7.LoadTemperatureMax));
        OnInputChanged();
    }
    private async Task OnLoadTemperatureKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await airDensityInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await loadWeightInput.FocusAsync();
    }
    #endregion
    #region loadWeight
    private MudTextField<string> loadWeightInput = null!;
    private string? loadWeight;
    private void SetLoadWeightStr(double? value)
        => loadWeight = value.Stringify();
    private void SetLoadWeight(double? value)
        => SetValue(value,
            d => Values.LoadWeight = d,
            d => ClampValue(d, Calculator1A_7.LoadWeightMin, Calculator1A_7.LoadWeightMax));
    private async Task OnLoadWeightChanged(string? value)
    {
        loadWeight = value?.FilterNumericInput();
        await loadWeightInput.SetTextAsync(loadWeight);
        OnInputChanged();
    }
    private void OnLoadWeightBlur(FocusEventArgs _)
    {
        SetValue(ref loadWeight,
            d => Values.LoadWeight = d,
            d => ClampValue(d, Calculator1A_7.LoadWeightMin, Calculator1A_7.LoadWeightMax));
        OnInputChanged();
    }
    private async Task OnLoadWeightKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await loadTemperatureInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result.FocusAsync();
    }
    #endregion

    private MudTextField<string?> result = null!;
    private async Task OnResultKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await loadWeightInput.FocusAsync();
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
