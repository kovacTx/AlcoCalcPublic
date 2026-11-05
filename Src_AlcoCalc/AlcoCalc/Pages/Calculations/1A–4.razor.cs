using AlcoCalc.Services;
using AlcoCalc.Utils;
using AlcoCalc.Values;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AlcoCalc.Pages.Calculations;

public partial class _1A_4 : CalcPage
{
    public const string ErrMessage = "nieje možné vypočítať korekcie na tepelnú rozťažnosť pyknometra";
    [Inject] Calculator1A_4 Calculator { get; set; } = null!;
    [Inject] CalculatorValues AllValues { get; set; } = null!;

    private CalculatorValues1A_4 Values => AllValues._1A_4;
    override protected CalculatorValuesBase ValuesBase => Values;
    override protected ICalculatorBase CalculatorBase => Calculator;

    private PyknometerMaterial? _material;
    private PyknometerMaterial? Material
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

    private readonly PyknometerMaterial[] materials =
    [
        new("Iný", null),
        new("Kremenné", 0.0000016),
        new("Simax", 0.0000088),
        new("Sial", 0.000013),
        new("Neutral", 0.000017),
        new("KS", 0.000024),
        new("Unihost", 0.000027)
    ];

    protected override void OnInitialized()
    {
        base.OnInitialized();
        Material = materials[0];
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
            d => ClampValue(d, Calculator1A_4.ThermalExpansionCoefficientMin, Calculator1A_4.ThermalExpansionCoefficientMax));
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
            d => ClampValue(d, Calculator1A_4.ThermalExpansionCoefficientMin, Calculator1A_4.ThermalExpansionCoefficientMax));
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
            d => ClampValue(d, Calculator1A_4.TemperatureOfMeasurementMin, Calculator1A_4.TemperatureOfMeasurementMax));
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
            d => ClampValue(d, Calculator1A_4.TemperatureOfMeasurementMin, Calculator1A_4.TemperatureOfMeasurementMax));
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

    private class PyknometerMaterial(string name, double? coefficient)
    {
        public string Name { get; set; } = name;
        public double? Coefficient { get; set; } = coefficient;
    }
}
