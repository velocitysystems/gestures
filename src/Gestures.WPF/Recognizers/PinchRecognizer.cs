// <copyright file="PinchRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System.Windows;
using System.Windows.Input;

namespace Velocity.Gestures.WPF
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
            View.IsManipulationEnabled = true;
            View.ManipulationStarted += OnManipulationStarted;
            View.ManipulationDelta += OnManipulationDelta;
            View.ManipulationCompleted += OnManipulationCompleted;
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.IsManipulationEnabled = false;
            View.ManipulationStarted -= OnManipulationStarted;
            View.ManipulationDelta -= OnManipulationDelta;
            View.ManipulationCompleted -= OnManipulationCompleted;
        }

        private void OnManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            OnTouchesBegan(e.ManipulationOrigin.X, e.ManipulationOrigin.Y);
            OnPinchingStarted(e.ManipulationOrigin.X, e.ManipulationOrigin.Y);
        }

        private void OnManipulationDelta(object sender, ManipulationDeltaEventArgs e) => OnPinchingScaleChanged(e.CumulativeManipulation.Scale.Length);

        private void OnManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            OnPinchingEnded();
            OnTouchesEnded(e.ManipulationOrigin.X, e.ManipulationOrigin.Y);
        }
    }
}