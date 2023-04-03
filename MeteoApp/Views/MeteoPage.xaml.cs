using MeteoApp.Models;

namespace MeteoApp.Views;

[QueryProperty(nameof(Targetcity), nameof(Targetcity))]

public partial class MeteoPage : ContentPage
{
    public City Targetcity
    {
        set { LoadCity(value); }

    }
    public MeteoPage()
    {
        InitializeComponent();

        
    }

    public async void LoadCity(City city)
    {
        BindingContext = new MeteoCity(city.Latitude, city.Longitude);
        Meteo meteo = new Meteo();

        BindingContext = meteo;
    }

}