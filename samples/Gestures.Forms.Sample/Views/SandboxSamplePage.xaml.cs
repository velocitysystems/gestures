﻿using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms.Sample.Views
{
    public partial class SandboxSamplePage : ContentPage
    {
        public SandboxSamplePage()
        {
            InitializeComponent();
            RefreshRecognizers();

            TapEnabled.CheckedChanged += (sender, e) => UpdateTapRecognizer();
            TapNumberOfTaps.TextChanged += (sender, e) => UpdateTapRecognizer();
            TapNumberOfTouches.TextChanged += (sender, e) => UpdateTapRecognizer();            

            LongPressEnabled.CheckedChanged += (sender, e) => UpdateLongPressRecognizer();
            LongPressNumberOfTouches.TextChanged += (sender, e) => UpdateLongPressRecognizer();

            SwipeEnabled.CheckedChanged += (sender, e) => UpdateSwipeRecognizer();

            PanEnabled.CheckedChanged += (sender, e) => RefreshRecognizers();
            PinchEnabled.CheckedChanged += (sender, e) => RefreshRecognizers();
            HoverEnabled.CheckedChanged += (sender, e) => RefreshRecognizers();
            KeyEnabled.CheckedChanged += (sender, e) => RefreshRecognizers();
        }

        /// <summary>
        /// Update the tap recognizer.
        /// </summary>
        private void UpdateTapRecognizer()
        {
            if (string.IsNullOrEmpty(TapNumberOfTaps.Text) || string.IsNullOrEmpty(TapNumberOfTouches.Text))
            {
                return;
            }

            RefreshRecognizers();
        }

        /// <summary>
        /// Update the long-press recognizer.
        /// </summary>
        private void UpdateLongPressRecognizer()
        {
            if (string.IsNullOrEmpty(LongPressNumberOfTouches.Text))
            {
                return;
            }

            RefreshRecognizers();
        }

        /// <summary>
        /// Update the swipe recognizer.
        /// </summary>
        private void UpdateSwipeRecognizer()
        {
            if (string.IsNullOrEmpty(SwipeNumberOfTouches.Text))
            {
                return;
            }

            RefreshRecognizers();
        }

        /// <summary>
        /// Refresh the recognizers attached to the sandbox.
        /// </summary>
        private void RefreshRecognizers()
        {
            GestureView.GestureRecognizers.Clear();
            GestureView.Effects.Clear();

            if (TapEnabled.IsChecked)
            {
                var tapRecognizer = new TapGestureRecognizer()
                {
                    NumberOfTapsRequired = int.Parse(TapNumberOfTaps.Text),
                    NumberOfTouchesRequired = int.Parse(TapNumberOfTouches.Text)                    
                };

                tapRecognizer.Tapped += OnTapped;
                tapRecognizer.TouchesBegan += OnTouchesBegan;
                tapRecognizer.TouchesEnded += OnTouchesEnded;
                GestureView.GestureRecognizers.Add(tapRecognizer);
            }

            if (LongPressEnabled.IsChecked)
            {
                var longPressRecognizer = new LongPressGestureRecognizer()
                {
                    NumberOfTouchesRequired = int.Parse(LongPressNumberOfTouches.Text)
                };

                longPressRecognizer.LongPressed += OnLongPressed;
                longPressRecognizer.TouchesBegan += OnTouchesBegan;
                longPressRecognizer.TouchesEnded += OnTouchesEnded;
                GestureView.GestureRecognizers.Add(longPressRecognizer);
            }

            if (SwipeEnabled.IsChecked)
            {
                var swipeRecognizer = new SwipeGestureRecognizer()
                {
                    NumberOfTouchesRequired = int.Parse(SwipeNumberOfTouches.Text)
                };

                swipeRecognizer.Swiped += OnSwiped;
                swipeRecognizer.TouchesBegan += OnTouchesBegan;
                swipeRecognizer.TouchesEnded += OnTouchesEnded;
                GestureView.GestureRecognizers.Add(swipeRecognizer);
            }

            if (PanEnabled.IsChecked)
            {
                var panRecognizer = new PanGestureRecognizer();
                panRecognizer.Panning += OnPanning;
                panRecognizer.TouchesBegan += OnTouchesBegan;
                panRecognizer.TouchesEnded += OnTouchesEnded;
                GestureView.GestureRecognizers.Add(panRecognizer);
            }

            if (PinchEnabled.IsChecked)
            {
                var pinchRecognizer = new PinchGestureRecognizer();
                pinchRecognizer.Pinching += OnPinching;
                pinchRecognizer.TouchesBegan += OnTouchesBegan;
                pinchRecognizer.TouchesEnded += OnTouchesEnded;
                GestureView.GestureRecognizers.Add(pinchRecognizer);
            }

            if (HoverEnabled.IsChecked)
            {
                var hoverRecognizer = new HoverGestureRecognizer();
                hoverRecognizer.Hovering += OnHovering;
                hoverRecognizer.TouchesBegan += OnTouchesBegan;
                hoverRecognizer.TouchesEnded += OnTouchesEnded;
                GestureView.GestureRecognizers.Add(hoverRecognizer);
            }

            if (KeyEnabled.IsChecked)
            {
                var keyListener = new KeyGestureListener();
                keyListener.Pressed += OnPressed;
                keyListener.KeyDown += OnKeyDown;
                keyListener.KeyUp += OnKeyUp;
                GestureView.GestureRecognizers.Add(keyListener);
            }

            GestureView.Effects.Add(Effect.Resolve($"Velocity.{nameof(RecognizerEffect)}"));
            GestureView.Effects.Add(Effect.Resolve($"Velocity.{nameof(ListenerEffect)}"));
        }

        void OnTapped(object sender, TapEventArgs e) => DisplayAlert("Tapped", $"You tapped {e.NumberOfTaps} time(s) with {e.NumberOfTouches} touch(es).", "OK");
        void OnLongPressed(object sender, EventArgs e) => DisplayAlert("Long Pressed", "You long-pressed.", "OK");
        void OnSwiped(object sender, SwipeEventArgs e) => DisplayAlert("Swiped", $"You swiped {e.Direction}.", "OK");

        void OnPanning(object sender, PanEventArgs e)
        {
            if (e.State == GestureState.Ended)
            {
                DisplayAlert("Panned", $"You panned.", "OK");
                GestureStatus.Text = "";
                return;
            }

            GestureStatus.Text = $"{e.TotalX},{e.TotalY}";
        }

        void OnPinching(object sender, PinchEventArgs e)
        {
            if (e.State == GestureState.Ended)
            {
                DisplayAlert("Pinched", $"You pinched.", "OK");
                GestureStatus.Text = "";
                return;
            }

            GestureStatus.Text = $"{e.Scale},{e.Origin}";
        }

        void OnHovering(object sender, HoverEventArgs e)
        {
            GestureStatus.Text = $"Hovering: {e.State}";
        }

        void OnPressed(object sender, KeyEventArgs e)
        {
            GestureStatus.Text = $"Pressed: {string.Join(",", e.Keys)}";
        }

        void OnKeyDown(object sender, Key e) => Debug.WriteLine($"Key Down: {e}");
        void OnKeyUp(object sender, Key e) => Debug.WriteLine($"Key Up: {e}");

        void OnTouchesBegan(object sender, Point e) => Debug.WriteLine($"Touches Began: {e.X},{e.Y}");
        void OnTouchesEnded(object sender, Point e) => Debug.WriteLine($"Touches Ended: {e.X},{e.Y}");
    }
}