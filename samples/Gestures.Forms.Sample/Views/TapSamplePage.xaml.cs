using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms.Sample.Views
{
    public partial class TapSamplePage : ContentPage
    {
        public TapSamplePage()
        {
            InitializeComponent();
        }

        void OnFrameTapped(object sender, TapEventArgs e) => DisplayAlert("Tapped", "You tapped.", "OK");
        void OnFrameTouchesBegan(object sender, Point e) => Debug.WriteLine($"Touches Began: {e.X},{e.Y}");
        void OnFrameTouchesEnded(object sender, Point e) => Debug.WriteLine($"Touches Ended: {e.X},{e.Y}");
    }
}