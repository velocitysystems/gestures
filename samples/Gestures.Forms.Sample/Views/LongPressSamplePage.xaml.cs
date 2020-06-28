using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Velocity.Gestures.Forms.Sample.Views
{
    public partial class LongPressSamplePage : ContentPage
    {
        public LongPressSamplePage()
        {
            InitializeComponent();
        }

        void OnFrameLongPressed(object sender, EventArgs e)
        {
            DisplayAlert("Long Pressed", "You long-pressed.", "OK");
        }
    }
}
