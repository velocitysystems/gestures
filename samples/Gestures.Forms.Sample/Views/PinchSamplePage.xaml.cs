using System;
using System.Collections.Generic;

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
    }
}