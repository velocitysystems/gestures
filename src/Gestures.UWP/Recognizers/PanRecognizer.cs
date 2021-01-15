// <copyright file="PanRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Velocity.Gestures.UWP
{
    /// <summary>
    /// A multi-touch pan gesture recognizer.
    /// </summary>
    public class PanRecognizer : PlatformPanRecognizer<FrameworkElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PanRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        public PanRecognizer(FrameworkElement view) : base(view)
        {
            View.ManipulationMode = ManipulationModes.TranslateX | ManipulationModes.TranslateY;
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
            OnPanningStateChanged(GestureState.Began);
        }

        private void OnManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e) => OnPanningDeltaChanged(e.Cumulative.Translation.X, e.Cumulative.Translation.Y);

        private void OnManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            OnPanningStateChanged(GestureState.Ended);
            OnTouchesEnded(e.Position.X, e.Position.Y);
        }
    }
}