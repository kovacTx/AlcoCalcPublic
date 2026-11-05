using AlcoCalc.Services;
using AlcoCalc.Utils;
using AlcoCalc.Values;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AlcoCalc.Pages.Calculations;

public partial class _2_3 : CalcPage
{
    public const string ErrMessage = "nieje možné vypočítať korekciu na tepelnú rozťažnosť meradla";
    [Inject] Calculator2_3 Calculator { get; set; } = null!;
    [Inject] CalculatorValues AllValues { get; set; } = null!;

    private CalculatorValues2_3 Values => AllValues._2_3;
    override protected CalculatorValuesBase ValuesBase => Values;
    override protected ICalculatorBase CalculatorBase => Calculator;

    private MeasurementDeviceMaterial? _material;
    private MeasurementDeviceMaterial? Material
    {
        get => _material;
        set
        {
            _material = value;
            if (_material is null) return;
            SetThermalExpansionCoefficientStr(_material.Coefficient);
            SetThermalExpansionCoefficient(_material.Coefficient);
        }
    }

    private readonly MeasurementDeviceMaterial[] materials =
    [
        new("Iný", null),
        new("Oceľ", 0.000036),
        new("Nerez", 0.000048),
        new("Británium", 0.000061)
    ];

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (!Values.ThermalExpansionCoefficient.IsNullOrNan())
            _material = materials.FirstOrDefault(m => m.Coefficient == Values.ThermalExpansionCoefficient);
        _material ??= materials[0];

        SetThermalExpansionCoefficientStr(Values.ThermalExpansionCoefficient);
        SetTemperatureOfMeasurementStr(Values.TemperatureOfMeasurement);
    }

    #region thermalExpansionCoefficient
    private MudTextField<string> thermalExpansionCoefficientInput = null!;
    private string? thermalExpansionCoefficient;
    private void SetThermalExpansionCoefficientStr(double? value)
        => thermalExpansionCoefficient = value.Stringify();
    private void SetThermalExpansionCoefficient(double? value)
        => SetValue(value,
            d => Values.ThermalExpansionCoefficient = d,
            d => ClampValue(d, Calculator2_3.ThermalExpansionCoefficientMin, Calculator2_3.ThermalExpansionCoefficientMax));
    private async Task OnThermalExpansionCoefficientChanged(string? value)
    {
        thermalExpansionCoefficient = value?.FilterNumericInput();
        await thermalExpansionCoefficientInput.SetTextAsync(thermalExpansionCoefficient);
        OnInputChanged();
    }
    private void OnThermalExpansionCoefficientBlur(FocusEventArgs _)
    {
        SetValue(ref thermalExpansionCoefficient,
            d => Values.ThermalExpansionCoefficient = d,
            d => ClampValue(d, Calculator2_3.ThermalExpansionCoefficientMin, Calculator2_3.ThermalExpansionCoefficientMax));
        OnInputChanged();
    }
    private async Task OnThermalExpansionCoefficientKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await thermalExpansionCoefficientInput.FocusAsync();
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
            d => ClampValue(d, Calculator2_3.TemperatureOfMeasurementMin, Calculator2_3.TemperatureOfMeasurementMax));
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
            d => ClampValue(d, Calculator2_3.TemperatureOfMeasurementMin, Calculator2_3.TemperatureOfMeasurementMax));
        OnInputChanged();
    }
    private async Task OnTemperatureOfMeasurementKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await thermalExpansionCoefficientInput.FocusAsync();
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

    private class MeasurementDeviceMaterial(string name, double? coefficient)
    {
        public string Name => name;
        public double? Coefficient => coefficient;
    }

}
