using AlcoCalc.Services;
using AlcoCalc.Utils;
using AlcoCalc.Values;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AlcoCalc.Pages.Calculations;

public partial class _1A_8
{
    public const string ErrMessage = "nieje možné vypočítať hustotu a merný objem vody";

    [Inject] Calculator1A_8 Calculator { get; set; } = null!;
    [Inject] CalculatorValues AllValues { get; set; } = null!;

    private CalculatorValues1A_8 Values => AllValues._1A_8;
    override protected CalculatorValuesBase ValuesBase => Values;
    override protected ICalculatorBase CalculatorBase => Calculator;

    private string? WaterDensityStr => Values.WaterDensity.Stringify0();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SetWaterTemperatureStr(Values.WaterTemperature);
    }

    #region waterTemperature
    private MudTextField<string> waterTemperatureInput = null!;
    private string? waterTemperature;
    private void SetWaterTemperatureStr(double? value)
        => waterTemperature = value.Stringify();
    private void SetWaterTemperature(double? value)
        => SetValue(value,
            d => Values.WaterTemperature = d,
            d => ClampValue(d, Calculator1A_8.WaterTemperatureMin, Calculator1A_8.WaterTemperatureMax));
    private async Task OnWaterTemperatureChanged(string? value)
    {
        waterTemperature = value?.FilterNumericInput();
        await waterTemperatureInput.SetTextAsync(waterTemperature);
        OnInputChanged();
    }
    private void OnWaterTemperatureBlur(FocusEventArgs _)
    {
        SetValue(ref waterTemperature,
            d => Values.WaterTemperature = d,
            d => ClampValue(d, Calculator1A_8.WaterTemperatureMin, Calculator1A_8.WaterTemperatureMax));
        OnInputChanged();
    }
    private async Task OnWaterTemperatureKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await waterTemperatureInput.FocusAsync();
        if (args.Key == "Tab" && !args.ShiftKey) await result.FocusAsync();
    }
    #endregion

    private MudTextField<string?> result = null!;
    private async Task OnResultKeyDown(KeyboardEventArgs args)
    {
        await Task.Delay(50);
        if (args.Key == "Tab" && args.ShiftKey) await waterTemperatureInput.FocusAsync();
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
