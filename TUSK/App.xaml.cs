using Microsoft.Extensions.DependencyInjection;

namespace TUSK
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }
        //navigation 
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new MainPage()));
        }
    }
}