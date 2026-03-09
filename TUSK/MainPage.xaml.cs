namespace TUSK
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnCompassClicked(object sender, EventArgs e)
        { // Shell navigation, since we are using AppShell
          await Shell.Current.GoToAsync(nameof(CompassPage)); }

        }
}
