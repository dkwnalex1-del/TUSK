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

    //Videos
    private async void OnWatchFireVideoClicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://www.youtube.com/watch?v=0O3Bj8JFcTc");
    }

    private async void OnFireVideo2Clicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://www.youtube.com/watch?v=X3-Tpf1KPSs");
    }

    private async void OnFireVideo3Clicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://www.youtube.com/watch?v=ZPr-a8kht2E");
    }

    private async void OnFireVideo4Clicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://www.youtube.com/watch?v=ZPr-a8kht2E");
    }


}