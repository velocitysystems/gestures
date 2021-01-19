// <copyright file="PinchRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Velocity.Gestures.UWP
{
    /// <summary>
    /// A multi-touch pinch gesture recognizer.
    /// </summary>
    public class PinchRecognizer : PlatformPinchRecognizer<FrameworkElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PinchRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        public PinchRecognizer(FrameworkElement view) : base(view)
        {
            View.ManipulationMode = ManipulationModes.Scale;
            View.ManipulationStarted += OnManipulationStarted;
            View.ManipulationDelta += OnManipulationDelta;
            View.ManipulationCompleted += OnManipulationCompleted;
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.ManipulationMode = ManipulationModes.None;
            View.ManipulationStarted -= OnManipulationStarted;
            View.ManipulationDelta -= OnManipulationDelta;
            View.ManipulationCompleted -= OnManipulationCompleted;
        }

        private void OnManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            OnTouchesBegan(e.Position.X, e.Position.Y);
            OnPinchingBegan(e.Position.X, e.Position.Y);
        }

        private void OnManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e) => OnPinchingScaleChanged(e.Cumulative.Scale);

        private void OnManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            OnPinchingStateChanged(GestureState.Ended);
            OnTouchesEnded(e.Position.X, e.Position.Y);
        }
    }
}