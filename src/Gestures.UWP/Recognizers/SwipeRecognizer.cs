// <copyright file="SwipeRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Velocity.Gestures.UWP
{
    /// <summary>
    /// A multi-touch swipe gesture recognizer.
    /// </summary>
    public class SwipeRecognizer : PlatformSwipeRecognizer<FrameworkElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwipeRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        /// <param name="directionMask">Optional swipe direction mask.</param>
        /// <param name="numberOfTouchesRequired">Optional number of touches required.</param>
        public SwipeRecognizer(FrameworkElement view, SwipeDirection directionMask = Defaults.DirectionMask, int numberOfTouchesRequired = Defaults.NumberofTouchesRequired) : base(view, directionMask, numberOfTouchesRequired)
        {
            View.ManipulationMode = ManipulationModes.TranslateX | ManipulationModes.TranslateY;
            View.ManipulationStarted += OnManipulationStarted;
            View.ManipulationCompleted += OnManipulationCompleted;
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.ManipulationMode = ManipulationModes.None;
            View.ManipulationStarted -= OnManipulationStarted;
            View.ManipulationCompleted -= OnManipulationCompleted;
        }

        private void OnManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            OnTouchesBegan(e.Position.X, e.Position.Y);
            OnSwipeBegan(e.Position.X, e.Position.Y);
        }

        private void OnManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            OnSwipeEnded(e.Position.X, e.Position.Y);
            OnTouchesEnded(e.Position.X, e.Position.Y);
        }
    }
}