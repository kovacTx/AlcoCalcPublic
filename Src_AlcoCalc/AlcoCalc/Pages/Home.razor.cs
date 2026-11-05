using AlcoCalc.Services;

namespace AlcoCalc.Pages;

public partial class Home : IDisposable
{
    protected override void OnInitialized()
    {
        Task.Run(async () =>
        {
            await Task.Delay(100);
            CommonData.HomeButtonVisible = false;
            CommonData.BackButtonVisible = false;
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
