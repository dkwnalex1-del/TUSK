namespace TUSK
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnCompassClicked(object sender, EventArgs e)
        { //navigation to compass 
            await Navigation.PushAsync(new CompassPage()); }

        private async void OnFoodListClicked(object sender, EventArgs e)
        { //navigation to foodlist
            await Navigation.PushAsync(new FoodListPage());
        }
        private async void OnSurvivalGuideClicked(object sender, EventArgs e)
        { //navigation to compass 
            await Navigation.PushAsync(new Pages.SurvivalguidePage());
        }

    }
}
