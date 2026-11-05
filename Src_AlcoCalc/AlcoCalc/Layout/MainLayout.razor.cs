using AlcoCalc.Services;
using AlcoCalc.Utils;
using AlcoCalc.Values;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AlcoCalc.Layout;

public partial class MainLayout
{
    private const string DarkThemeTooltip = "svetlá téma";
    private const string LightThemeTooltip = "tmavá téma";
    public bool DrawerOpen { get; set; } = true;
    public bool IsDarkMode { get; set; } = true;
    public MudTheme? Theme { get; set; } = null;
    public string? ThemeChangeTooltip { get; set; } = DarkThemeTooltip;

    [Inject] NavigationManager Nav { get; set; } = default!;
    [Inject] IDialogService DialogService { get; set; } = default!;
    [Inject] ISnackbar Snackbar { get; set; } = null!;
    [Inject] Returner Returner { get; set; } = null!;
    [Inject] CalculatorValues AllValues { get; set; } = null!;


    private readonly PaletteLight _lightPalette = new()
    {
        Primary = "#006CB3",
        Secondary = "#606060",
        Black = "#110e2d",
        AppbarText = "#424242",
        AppbarBackground = "rgba(255,255,255,0.8)",
        DrawerBackground = "#ffffff",
        GrayLight = "#e8e8e8",
        GrayLighter = "#f9f9f9",
    };

    private readonly PaletteDark _darkPalette = new()
    {
        Primary = "#006CB3",
        Secondary = "#606060",
        Surface = "#1e1e2d",
        Background = "#1a1a27",
        BackgroundGray = "#151521",
        AppbarText = "#92929f",
        AppbarBackground = "rgba(26,26,39,0.8)",
        DrawerBackground = "#1a1a27",
        ActionDefault = "#74718e",
        ActionDisabled = "#9999994d",
        ActionDisabledBackground = "#605f6d4d",
        TextPrimary = "#b2b0bf",
        TextSecondary = "#92929f",
        TextDisabled = "#ffffff33",
        DrawerIcon = "#92929f",
        DrawerText = "#92929f",
        GrayLight = "#2a2833",
        GrayLighter = "#1e1e2d",
        Info = "#4a86ff",
        Success = "#3dcb6c",
        Warning = "#ffb545",
        Error = "#ff3f5f",
        LinesDefault = "#33323e",
        TableLines = "#33323e",
        Divider = "#292838",
        OverlayLight = "#1e1e2d80",
    };


    protected override void OnInitialized()
    {
        base.OnInitialized();

        Snackbar.Use();
        CommonData.OnRefresh -= StateHasChanged;
        CommonData.OnRefresh += StateHasChanged;
        Nav.LocationChanged += Nav_LocationChanged;

        Theme = new()
        {
            PaletteLight = _lightPalette,
            PaletteDark = _darkPalette,
            LayoutProperties = new LayoutProperties()
        };

    }
    private void GoHome()
    {
        Nav.NavigateTo("/");
    }
    private void GoCalculator()
    {
        if (Returner.WillReturn)
            Returner.TryReturn();
        else
            Nav.NavigateTo(CommonData.CalculatorPage, replace: true);
    }
    private void Reset()
    {
        AllValues.Reset();
        GoCalculator();
    }
    private void Nav_LocationChanged(object? sender, Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs e)
    {
        _ = Returner.Clear();
    }

    private void DarkModeToggle()
    {
        IsDarkMode = !IsDarkMode;
        ThemeChangeTooltip = IsDarkMode ? DarkThemeTooltip : LightThemeTooltip;
    }
    public string DarkLightModeButtonIcon => IsDarkMode switch
    {
        true => Icons.Material.Rounded.AutoMode,
        false => Icons.Material.Outlined.DarkMode,
    };
}
