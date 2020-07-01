using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms.Sample.Views
{
    public partial class PinchSamplePage : ContentPage
    {
        public PinchSamplePage()
        {
            InitializeComponent();
        }

        void OnFramePinching(object sender, PinchEventArgs e)
        {
            PinchingStatus.Text = $"{e.Scale},{e.Origin}";
            if (e.State == GestureState.Ended)
            {
                DisplayAlert("Pinched", $"You pinched.", "OK");
                PinchingStatus.Text = "";
            }
        }

        void OnFrameTouchesBegan(object sender, Point e) => Debug.WriteLine($"Touches Began: {e.X},{e.Y}");
        void OnFrameTouchesEnded(object sender, Point e) => Debug.WriteLine($"Touches Ended: {e.X},{e.Y}");
    }
}