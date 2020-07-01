using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms.Sample.Views
{
    public partial class LongPressSamplePage : ContentPage
    {
        public LongPressSamplePage()
        {
            InitializeComponent();
        }

        void OnFrameLongPressed(object sender, EventArgs e) => DisplayAlert("Long Pressed", "You long-pressed.", "OK");
        void OnFrameTouchesBegan(object sender, Point e) => Debug.WriteLine($"Touches Began: {e.X},{e.Y}");
        void OnFrameTouchesEnded(object sender, Point e) => Debug.WriteLine($"Touches Ended: {e.X},{e.Y}");
    }
}
