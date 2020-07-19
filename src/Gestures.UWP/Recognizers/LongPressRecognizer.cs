// <copyright file="LongPressRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Velocity.Gestures.UWP
{
    /// <summary>
    /// A multi-touch long-press gesture recognizer.
    /// </summary>
    public class LongPressRecognizer : PlatformLongPressRecognizer<FrameworkElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LongPressRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        /// <param name="numberOfTouchesRequired">Optional number of touches required.</param>
        public LongPressRecognizer(FrameworkElement view, int numberOfTouchesRequired = Defaults.NumberofTouchesRequired) : base(view, numberOfTouchesRequired)
        {
            View.RightTapped += OnRightTapped;
            View.PointerPressed += OnPointerPressed;
            View.PointerReleased += OnPointerReleased;
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.RightTapped -= OnRightTapped;
            View.PointerPressed -= OnPointerPressed;
            View.PointerReleased -= OnPointerReleased;
        }

        private void OnRightTapped(object sender, RightTappedRoutedEventArgs e) => OnLongPressed();

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