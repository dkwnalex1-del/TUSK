namespace TUSK.Pages;

public partial class SurvivalguidePage : ContentPage
{
	public SurvivalguidePage()
	{
		InitializeComponent();
	}
    private async void OnFirstAidClicked(object sender, EventArgs e)
    { //navigation to first aid page
        await Navigation.PushAsync(new FirstAid());
    }
    private async void OnShelterClicked(object sender, EventArgs e)
    { //navigation to shelter page
        await Navigation.PushAsync(new ShelterPage());
    }
    private async void OnWaterClicked(object sender, EventArgs e)
    { //navigation to water page
        await Navigation.PushAsync(new FoodListPage());
    }
    private async void OnFireClicked(object sender, EventArgs e)
    { //navigation to fire page
        await Navigation.PushAsync(new FirePage());
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