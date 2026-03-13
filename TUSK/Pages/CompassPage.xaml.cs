//uses maui in-built api for sensors
using Microsoft.Maui.Devices.Sensors;
namespace TUSK;

public partial class CompassPage : ContentPage
{
    public CompassPage()
    {
        InitializeComponent();

        //check the platform of the device
        if (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS)
        {
            //starts the compass if its not already started
            if (!Compass.IsMonitoring)
            {
                Compass.ReadingChanged += Compass_ReadingChanged;
                Compass.Start(SensorSpeed.UI);
            }
        }
        //if the platform is not ios or android then write a message that the platform isn't supported.
        else { HeadingLabel.Text = "Compass not supported on this platform."; 
        }

    }
    //method that stops the compass when the page is not open, prevents memory leak and other errors
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
    //Display direction based on the current rotatio of the compass sensor
    private String getDirection(double heading){
        if (heading >= 337.5 || heading <= 22.5) return "North";
        if (heading >= 22.5 && heading < 67.5) return "Northeast"; if (heading >= 67.5 && heading < 112.5) return "East";
        if (heading >= 112.5 && heading < 157.5) return "Southeast"; if (heading >= 157.5 && heading < 202.5) return "South";
        if (heading >= 202.5 && heading < 247.5) return "SouthWest";
        if (heading >= 247.5 && heading < 292.5) return "West";
        return "Northwest";
        }
    //function for the back button on compasspage
    private async void OnBackClicked(object sender, EventArgs e) { 
        await Navigation.PopAsync(); 
        }

}