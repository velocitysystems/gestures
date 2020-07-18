using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms.Sample.Views
{
    public partial class HoverSamplePage : ContentPage
    {
        public HoverSamplePage()
        {
            InitializeComponent();
        }

        void OnFrameHovering(object sender, HoverEventArgs e)
        {
            HoveringStatus.Text = $"Hovering: {e.State}";
        }

        void OnFrameTouchesBegan(object sender, Point e) => Debug.WriteLine($"Touches Began: {e.X},{e.Y}");
        void OnFrameTouchesEnded(object sender, Point e) => Debug.WriteLine($"Touches Ended: {e.X},{e.Y}");
    }
}