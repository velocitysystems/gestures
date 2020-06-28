using System;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms.Sample.Views
{
    public partial class TapSamplePage : ContentPage
    {
        public TapSamplePage()
        {
            InitializeComponent();
        }

        void OnFrameTapped(object sender, TapEventArgs e)
        {
            DisplayAlert("Tapped", "You tapped.", "OK");
        }
    }
}