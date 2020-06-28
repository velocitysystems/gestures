using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Velocity.Gestures.Forms.Sample.Views
{
    public partial class SwipeSamplePage : ContentPage
    {
        public SwipeSamplePage()
        {
            InitializeComponent();
        }

        void OnFrameSwiped(object sender, SwipeEventArgs e)
        {
            DisplayAlert("Swiped", $"You swiped {e.Direction}.", "OK");
        }
    }
}