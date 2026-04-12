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
    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private async void ToggleSection1(object sender, EventArgs e)
    {
        Section1Content.IsVisible = !Section1Content.IsVisible;

        if (Section1Content.IsVisible)
            await Arrow1.RotateTo(180);
        else
            await Arrow1.RotateTo(0);
    }

    private async void ToggleSection2(object sender, EventArgs e)
    {
        Section2Content.IsVisible = !Section2Content.IsVisible;

        if (Section2Content.IsVisible)
            await Arrow2.RotateTo(180);
        else
            await Arrow2.RotateTo(0);
    }

    private async void ToggleSection3(object sender, EventArgs e)
    {
        Section3Content.IsVisible = !Section3Content.IsVisible;

        if (Section3Content.IsVisible)
            await Arrow3.RotateTo(180);
        else
            await Arrow3.RotateTo(0);
    }

    private async void ToggleSection4(object sender, EventArgs e)
    {
        Section4Content.IsVisible = !Section4Content.IsVisible;

        if (Section4Content.IsVisible)
            await Arrow4.RotateTo(180);
        else
            await Arrow4.RotateTo(0);
    }

    private async void OnShelterVideo1Clicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://youtu.be/la_rP5E-avM?si=mGDsnlOb1u1HP695&t=26");
    }

    private async void OnShelterVideo2Clicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://www.youtube.com/watch?v=4eNk2FfWsNE");
    }

    private async void OnShelterVideo3Clicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://www.youtube.com/watch?v=apsHVSZsk44");
    }
    private async void OnShelterVideo4Clicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://www.youtube.com/watch?v=QslIqZAl_Ok");
    }

}
