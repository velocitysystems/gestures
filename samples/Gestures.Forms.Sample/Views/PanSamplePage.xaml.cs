using System;
using System.Collections.Generic;

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
            PanningStatus.Text = $"{e.TotalX},{e.TotalY}";
            if (e.State == GestureState.Ended)
            {
                DisplayAlert("Panned", $"You panned.", "OK");
                PanningStatus.Text = "";
            }
        }
    }
}