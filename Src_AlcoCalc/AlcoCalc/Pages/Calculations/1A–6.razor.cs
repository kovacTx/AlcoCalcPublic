using AlcoCalc.Services;
using AlcoCalc.Utils;
using AlcoCalc.Values;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AlcoCalc.Pages.Calculations;

public partial class _1A_6 : CalcPage
{
    public const string ErrMessage = "nieje možné vypočítať hustotu vzduchu";

    [Inject] Calculator1A_6 Calculator { get; set; } = null!;
    [Inject] CalculatorValues AllValues { get; set; } = null!;

    private CalculatorValues1A_6 Values => AllValues._1A_6;
    override protected CalculatorValuesBase ValuesBase => Values;
    override protected ICalculatorBase CalculatorBase => Calculator;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SetAtmosphericPressureStr(Values.AtmosphericPressure);
        SetAirTemperatureStr(Values.AirTemperature);
        SetRelativeHumidityStr(Values.RelativeHumidity);
    }

    #region atmosphericPressure
    private MudTextField<string> atmosphericPressureInput = null!;
    private string? atmosphericPressure;
    private void SetAtmosphericPressureStr(double? value)
        => atmosphericPressure = value.Stringify();
    private void SetAtmosphericPressure(double? value)
        => SetValue(value,
            d => Values.AtmosphericPressure = d,
            d => ClampValue(d, Calculator1A_6.AtmosphericPressureMin, Calculator1A_6.AtmosphericPressureMax));
    private async Task OnAtmosphericPressureChanged(string? value)
    {
        atmosphericPressure = value?.FilterNumericInput();
        await atmosphericPressureInput.SetTextAsync(atmosphericPressure);
        OnInputChanged();
    }
    private void OnAtmosphericPressureBlur(FocusEventArgs _)
    {
        SetValue(ref atmosphericPressure,
            d => Values.AtmosphericPressure = d,
            d => ClampValue(d, Calculator1A_6.AtmosphericPressureMin, Calculator1A_6.AtmosphericPressureMax));
        OnInputChanged();
    }
    private async Task OnAtmosphericPressureKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await atmosphericPressureInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await airTemperatureInput.FocusAsync();
    }
    #endregion
    #region airTemperature
    private MudTextField<string> airTemperatureInput = null!;
    private string? airTemperature;
    private void SetAirTemperatureStr(double? value)
        => airTemperature = value.Stringify();
    private void SetAirTemperature(double? value)
        => SetValue(value,
            d => Values.AirTemperature = d,
            d => ClampValue(d, Calculator1A_6.AirTemperatureMin, Calculator1A_6.AirTemperatureMax));
    private async Task OnAirTemperatureChanged(string? value)
    {
        airTemperature = value?.FilterNumericInput();
        await airTemperatureInput.SetTextAsync(airTemperature);
        OnInputChanged();
    }
    private void OnAirTemperatureBlur(FocusEventArgs _)
    {
        SetValue(ref airTemperature,
            d => Values.AirTemperature = d,
            d => ClampValue(d, Calculator1A_6.AirTemperatureMin, Calculator1A_6.AirTemperatureMax));
        OnInputChanged();
    }
    private async Task OnAirTemperatureKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await atmosphericPressureInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await relativeHumidityInput.FocusAsync();
    }
    #endregion
    #region relativeHumidity
    private MudTextField<string> relativeHumidityInput = null!;
    private string? relativeHumidity;
    private void SetRelativeHumidityStr(double? value)
        => relativeHumidity = value.Stringify();
    private void SetRelativeHumidity(double? value)
        => SetValue(value,
            d => Values.RelativeHumidity = d,
            d => ClampValue(d, Calculator1A_6.RelativeHumidityMin, Calculator1A_6.RelativeHumidityMax));
    private async Task OnRelativeHumidityChanged(string? value)
    {
        relativeHumidity = value?.FilterNumericInput();
        await relativeHumidityInput.SetTextAsync(relativeHumidity);
        OnInputChanged();
    }
    private void OnRelativeHumidityBlur(FocusEventArgs _)
    {
        SetValue(ref relativeHumidity,
            d => Values.RelativeHumidity = d,
            d => ClampValue(d, Calculator1A_6.RelativeHumidityMin, Calculator1A_6.RelativeHumidityMax));
        OnInputChanged();
    }
    private async Task OnRelativeHumidityKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await airTemperatureInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result.FocusAsync();
    }
    #endregion

    private MudTextField<string?> result = null!;
    private async Task OnResultKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await relativeHumidityInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result.FocusAsync();
    }

}
