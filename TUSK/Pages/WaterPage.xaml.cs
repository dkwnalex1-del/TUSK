namespace TUSK;

public partial class WaterPage : ContentPage
{
	public WaterPage()
	{
		InitializeComponent();
	}
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}