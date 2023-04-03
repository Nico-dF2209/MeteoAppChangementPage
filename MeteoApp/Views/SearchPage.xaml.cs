using MeteoApp.Models;

namespace MeteoApp.Views;



public partial class SearchPage : ContentPage
{
    public SearchPage()
    {
        InitializeComponent();

        BindingContext = new CitySearchResult();
    }

    private async void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as CitySearchResult).SearchCity(SearchCityBar.Text);

    }

    private async void CollectionView_SelectionChanged(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null && e.SelectedItem is City city)
        {
            Dictionary<string, object> navigationParameter = new();
            navigationParameter.Add(nameof(MeteoPage.Targetcity), city);

            await Shell.Current.GoToAsync(nameof(MeteoPage), navigationParameter);
            Choosed.SelectedItem = null;
            (BindingContext as CitySearchResult).SearchResult.Clear();
        }
    }
}