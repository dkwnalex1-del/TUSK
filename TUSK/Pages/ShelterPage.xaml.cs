namespace TUSK;

public partial class ShelterPage : ContentPage
{
	public ShelterPage()
	{
		InitializeComponent();
	}

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private async void onHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}
