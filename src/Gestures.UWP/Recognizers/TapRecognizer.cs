// <copyright file="TapRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Velocity.Gestures.UWP
{
    /// <summary>
    /// A multi-touch tap gesture recognizer.
    /// </summary>
    public class TapRecognizer : PlatformTapRecognizer<FrameworkElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TapRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        /// <param name="numberOfTapsRequired">Optional number of taps required.</param>
        /// <param name="numberOfTouchesRequired">Optional number of touches required.</param>
        public TapRecognizer(FrameworkElement view, int numberOfTapsRequired = Defaults.NumberOfTapsRequired, int numberOfTouchesRequired = Defaults.NumberofTouchesRequired) : base(view, numberOfTapsRequired, numberOfTouchesRequired)
        {
            View.Tapped += OnTapped;
            View.PointerPressed += OnPointerPressed;
            View.PointerReleased += OnPointerReleased;
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.Tapped -= OnTapped;
            View.PointerPressed -= OnPointerPressed;
            View.PointerReleased -= OnPointerReleased;
        }

        private void OnTapped(object sender, TappedRoutedEventArgs e) => OnTapped();

        private void OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            var point = e.GetCurrentPoint(View);
            OnTouchesBegan(point.Position.X, point.Position.Y);
        }

        private void OnPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            var point = e.GetCurrentPoint(View);
            OnTouchesEnded(point.Position.X, point.Position.Y);
        }
    }
}