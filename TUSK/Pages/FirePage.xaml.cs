namespace TUSK;

public partial class FirePage : ContentPage
{
	public FirePage()
	{
		InitializeComponent();
	}
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}