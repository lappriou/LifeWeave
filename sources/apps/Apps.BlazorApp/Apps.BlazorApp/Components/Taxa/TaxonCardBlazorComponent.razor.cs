using Microsoft.AspNetCore.Components;


namespace LifeWeave.Apps.BlazorApp.Components.Taxa;

public partial class TaxonCardBlazorComponent
{
    public const string ColLinkName = "Catalogue of Life";
    public const string ColTaxonUrlBase = "https://www.catalogueoflife.org/data/taxon/";

    [Parameter]
    public TaxonDataDto Taxon { get; set; }

    public string ColHref { get; private set; }
    public TaxonCardBlazorComponent()
    {

    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        ColHref = $"{ColTaxonUrlBase}{Taxon.ColID}";
    }
}
