using AlcoCalc.Services;
using Microsoft.AspNetCore.Components;

namespace AlcoCalc.Components;

public partial class HelpListItem
{
    [Inject] protected Returner Returner { get; set; } = null!;
    [Inject] protected NavigationManager Nav { get; set; } = null!;

    [Parameter, EditorRequired]
    public string Href { get; set; } = string.Empty;

    [Parameter, EditorRequired]
    public string HelpHref { get; set; } = string.Empty;

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    private void GoToHref()
    {
        Returner.OneTimeIgnoreClear();
        Nav.NavigateTo(Href, replace: true);
    }
    private void GoToHelpHref()
    {
        Returner.OneTimeIgnoreClear();
        Nav.NavigateTo(HelpHref, replace: true);
    }
}
