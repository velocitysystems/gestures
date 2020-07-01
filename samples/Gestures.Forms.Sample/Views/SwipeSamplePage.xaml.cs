using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms.Sample.Views
{
    public partial class SwipeSamplePage : ContentPage
    {
        public SwipeSamplePage()
        {
            InitializeComponent();
        }

        void OnFrameSwiped(object sender, SwipeEventArgs e) => DisplayAlert("Swiped", $"You swiped {e.Direction}.", "OK");
        void OnFrameTouchesBegan(object sender, Point e) => Debug.WriteLine($"Touches Began: {e.X},{e.Y}");
        void OnFrameTouchesEnded(object sender, Point e) => Debug.WriteLine($"Touches Ended: {e.X},{e.Y}");
    }
}