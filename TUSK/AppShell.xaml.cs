namespace TUSK
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CompassPage), typeof(CompassPage));
        }
    }
}
