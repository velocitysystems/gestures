using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms.Sample.Views
{
    public partial class PanSamplePage : ContentPage
    {
        public PanSamplePage()
        {
            InitializeComponent();
        }

        void OnFramePanning(object sender, PanEventArgs e)
        {
            if (e.State == GestureState.Ended)
            {
                DisplayAlert("Panned", $"You panned.", "OK");
                PanningStatus.Text = "";
                return;
            }

            PanningStatus.Text = $"{e.TotalX},{e.TotalY}";
        }

        void OnFrameTouchesBegan(object sender, Point e) => Debug.WriteLine($"Touches Began: {e.X},{e.Y}");
        void OnFrameTouchesEnded(object sender, Point e) => Debug.WriteLine($"Touches Ended: {e.X},{e.Y}");
    }
}