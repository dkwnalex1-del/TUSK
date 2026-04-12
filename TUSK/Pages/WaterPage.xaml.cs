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

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }


    //content 
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


    //video

    private async void OnWaterVideo1Clicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://www.youtube.com/watch?v=DScDU_WgUbI");
    }

    private async void OnWaterVideo2Clicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://www.youtube.com/watch?v=zppUfthVw6o");
    }

    private async void OnWaterVideo3Clicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://www.youtube.com/watch?v=CVULQxujrAk");
    }

    private async void OnWaterVideo4Clicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://www.youtube.com/watch?v=oX7Jls_1hso");
    }
}