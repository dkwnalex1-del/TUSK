using Microsoft.Maui.Devices.Sensors;
namespace TUSK;

public partial class CompassPage : ContentPage
{
    public CompassPage()
    {
        InitializeComponent();

        if (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS)
        {
            if (!Compass.IsMonitoring)
            {
                Compass.ReadingChanged += Compass_ReadingChanged;
                Compass.Start(SensorSpeed.UI);
            }
        }
        else { HeadingLabel.Text = "Compass not supported on this platform."; 
        }

    }
    protected override void OnDisappearing() { 
        base.OnDisappearing(); 
        if (Compass.IsMonitoring) { 
            Compass.ReadingChanged -= Compass_ReadingChanged; 
            Compass.Stop(); 
        } 
    }
    private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
    {
        var data = e.Reading; MainThread.BeginInvokeOnMainThread(() =>
        {
            HeadingLabel.Text = $"Heading: {data.HeadingMagneticNorth:F1}°"; 
            DirectionLabel.Text = getDirection(data.HeadingMagneticNorth);
            // The dial image rotates, needle will stay static
            DialImage.Rotation = -data.HeadingMagneticNorth; 
            });
        }
    private String getDirection(double heading){
        if (heading >= 337.5 || heading <= 22.5) return "North";
        if (heading >= 22.5 && heading < 67.5) return "Northeast"; if (heading >= 67.5 && heading < 112.5) return "East";
        if (heading >= 112.5 && heading < 157.5) return "Southeast"; if (heading >= 157.5 && heading < 202.5) return "South";
        if (heading >= 202.5 && heading < 247.5) return "SouthWest";
        if (heading >= 247.5 && heading < 292.5) return "West";
        return "Northwest";
        }
    private async void OnBackClicked(object sender, EventArgs e) { 
        await Navigation.PopAsync(); 
        }

}