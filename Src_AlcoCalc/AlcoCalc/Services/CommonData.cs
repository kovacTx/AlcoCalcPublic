namespace AlcoCalc.Services;

public static class CommonData
{
    public const string CalculatorPage = "/prepocty";

    private static bool _homeButtonVisible;
    public static bool HomeButtonVisible
    {
        get => _homeButtonVisible;
        set
        {
            _homeButtonVisible = value;
            OnRefresh?.Invoke();
        }
    }

    private static bool _backButtonVisible;
    public static bool BackButtonVisible
    {
        get => _backButtonVisible;
        set
        {
            _backButtonVisible = value;
            OnRefresh?.Invoke();
        }
    }

    private static bool _resetButtonVisible;
    public static bool ResetButtonVisible
    {
        get => _resetButtonVisible;
        set
        {
            _resetButtonVisible = value;
            OnRefresh?.Invoke();
        }
    }
    public static Action? OnRefresh { get; set; }
}
