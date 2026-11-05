using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AlcoCalc.Components;

public partial class Formula
{
    [Parameter] public string Title { get; set; } = "";
    [Parameter] public string FormulaLatex { get; set; } = "";
    [Inject] IJSRuntime JS { get; set; } = null!;

    private string RenderedFormula => $"\\[{FormulaLatex}\\]";

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await JS.InvokeVoidAsync("MathJax.typesetPromise");
    }
}
