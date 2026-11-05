using AlcoCalc.Services;
using AlcoCalc.Utils;
using AlcoCalc.Values;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AlcoCalc.Pages.Calculations;

public partial class _1B_1 : CalcPage
{
    public const string ErrMessage = "nieje možné vypočítať objemovú koncentráciu etanolu pri 20°C z údaja hustomera a teploty merania";

    [Inject] Calculator1B_1 Calculator { get; set; } = null!;
    [Inject] CalculatorValues AllValues { get; set; } = null!;

    private CalculatorValues1B_1 Values => AllValues._1B_1;
    override protected CalculatorValuesBase ValuesBase => Values;
    override protected ICalculatorBase CalculatorBase => Calculator;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SetDensityStr(Values.Density);
        SetTemperatureOfMeasurementStr(Values.TemperatureOfMeasurement);
    }

    #region density
    private MudTextField<string> densityInput = null!;
    private string? density;
    private void SetDensityStr(double? value)
        => density = value.Stringify();
    private void SetDensity(double? value)
        => SetValue(value,
            d => Values.Density = d,
            d => ClampValue(d, Calculator1B_1.DensityMin, Calculator1B_1.DensityMax));
    private async Task OnDensityChanged(string? value)
    {
        density = value?.FilterNumericInput();
        await densityInput.SetTextAsync(density);
        OnInputChanged();
    }
    private void OnDensityBlur(FocusEventArgs _)
    {
        SetValue(ref density,
            d => Values.Density = d,
            d => ClampValue(d, Calculator1B_1.DensityMin, Calculator1B_1.DensityMax));
        OnInputChanged();
    }
    private async Task OnDensityKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await densityInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await temperatureOfMeasurementInput.FocusAsync();
    }
    #endregion
    #region temperatureOfMeasurement
    private MudTextField<string> temperatureOfMeasurementInput = null!;
    private string? temperatureOfMeasurement;
    private void SetTemperatureOfMeasurementStr(double? value)
        => temperatureOfMeasurement = value.Stringify();
    private void SetTemperatureOfMeasurement(double? value)
        => SetValue(value,
            d => Values.TemperatureOfMeasurement = d,
            d => ClampValue(d, Calculator1B_1.TemperatureOfMeasurementMin, Calculator1B_1.TemperatureOfMeasurementMax));
    private async Task OnTemperatureOfMeasurementChanged(string? value)
    {
        temperatureOfMeasurement = value?.FilterNumericInput();
        await temperatureOfMeasurementInput.SetTextAsync(temperatureOfMeasurement);
        OnInputChanged();
    }
    private void OnTemperatureOfMeasurementBlur(FocusEventArgs _)
    {
        SetValue(ref temperatureOfMeasurement,
            d => Values.TemperatureOfMeasurement = d,
            d => ClampValue(d, Calculator1B_1.TemperatureOfMeasurementMin, Calculator1B_1.TemperatureOfMeasurementMax));
        OnInputChanged();
    }
    private async Task OnTemperatureOfMeasurementKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await densityInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result.FocusAsync();
    }
    #endregion

    private MudTextField<string?> result = null!;
    private async Task OnResultKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await temperatureOfMeasurementInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result.FocusAsync();
    }

}
