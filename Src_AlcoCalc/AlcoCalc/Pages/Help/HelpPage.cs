using AlcoCalc.Services;
using Microsoft.AspNetCore.Components;

namespace AlcoCalc.Pages.Help;

public abstract class HelpPage : ComponentBase, IDisposable
{
    protected override void OnInitialized()
    {
        Task.Run(async () =>
        {
            await Task.Delay(100);
            CommonData.HomeButtonVisible = false;
            CommonData.BackButtonVisible = true;
            CommonData.ResetButtonVisible = false;
        });
    }
    public void Dispose()
    {
        CommonData.HomeButtonVisible = false;
        CommonData.BackButtonVisible = false;
        CommonData.ResetButtonVisible = false;
    }
}
