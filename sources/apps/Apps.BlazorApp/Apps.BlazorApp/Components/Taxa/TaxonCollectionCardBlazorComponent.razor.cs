using LifeWeave.Infrastructures.Data.Taxa;

using Microsoft.AspNetCore.Components;

using System.Collections.ObjectModel;

namespace LifeWeave.Apps.BlazorApp.Components.Taxa;

public partial class TaxonCollectionCardBlazorComponent
{
    [Inject]
    private ITaxonReadDataService TaxonReadDataService { get; set; } = default!;

    public IReadOnlyCollection<TaxonDataDto> TaxonObservableCollection { get; set; } = Array.Empty<TaxonDataDto>();

    override protected async Task OnInitializedAsync()
    {
        var taxons = await TaxonReadDataService.GetAsync();

        TaxonObservableCollection = taxons;
    }
}
