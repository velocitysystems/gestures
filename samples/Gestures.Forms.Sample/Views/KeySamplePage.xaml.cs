using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms.Sample.Views
{
    public partial class KeySamplePage : ContentPage
    {
        public KeySamplePage()
        {
            InitializeComponent();
        }

        void OnPressed(object sender, KeyEventArgs e)
        {
            KeyStatus.Text = $"Pressed: {string.Join(",", e.Keys)}";
        }

        void OnKeyDown(object sender, Key e) => Debug.WriteLine($"Key Down: {e}");
        void OnKeyUp(object sender, Key e) => Debug.WriteLine($"Key Up: {e}");
    }
}