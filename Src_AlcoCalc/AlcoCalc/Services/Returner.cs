using Microsoft.AspNetCore.Components;

namespace AlcoCalc.Services;

public class Returner(NavigationManager nav)
{
    private bool oneTimeIgnoreClear;
    private readonly Stack<(string? path, Action<double?> onReturn)> returns = [];
    public bool WillReturn => returns.Count > 0;
    public event Func<Task>? OnChangedAsync;

    public async Task AddReturn(string path, Action<double?> action)
    {
        returns.Push((path, action));
        await NotifyChangedAsync();
    }
    public void TryReturn(double? value)
    {
        if (!returns.TryPop(out var ret))
            return;
        ret.onReturn(value);
        if (ret.path is null)
            return;
        OneTimeIgnoreClear();
        nav.NavigateTo(ret.path, replace: true);
    }
    public void TryReturn()
    {
        if (!returns.TryPop(out var ret))
            return;
        if (ret.path is null)
            return;
        OneTimeIgnoreClear();
        nav.NavigateTo(ret.path, replace: true);
    }
    public void OneTimeIgnoreClear()
        => oneTimeIgnoreClear = true;
    public async Task Clear()
    {
        if (oneTimeIgnoreClear)
        {
            oneTimeIgnoreClear = false;
            return;
        }
        returns.Clear();
        await NotifyChangedAsync();
    }
    private async Task NotifyChangedAsync()
    {
        if (OnChangedAsync is null)
            return;

        foreach (Func<Task> handler in OnChangedAsync.GetInvocationList().Cast<Func<Task>>())
        {
            await handler();
        }
    }
}
