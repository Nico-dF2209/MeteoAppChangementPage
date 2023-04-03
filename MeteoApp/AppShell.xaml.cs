namespace MeteoApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.MeteoPage), typeof(Views.MeteoPage));
    }
}
