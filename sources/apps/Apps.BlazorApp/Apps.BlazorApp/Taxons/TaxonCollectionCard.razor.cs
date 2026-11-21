using Microsoft.AspNetCore.Components;

using System.Collections.ObjectModel;

namespace LifeWeave.Apps.BlazorApp.Taxons;

public partial class TaxonCollectionCard
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
