namespace LifeWeave.Apps.BlazorApp.Components.Taxa;

public partial class TaxonCardBlazorComponent
{
    [Parameter]
    public TaxonDataDto Taxon { get; set; }

    public TaxonCardBlazorComponent()
    {
        ViewModel ??= new TaxonCardViewModel();
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        ViewModel!.Taxon = Taxon;
    }
}
