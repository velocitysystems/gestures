// <copyright file="SwipeRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using AppKit;

namespace Velocity.Gestures.MacOS
{
    /// <summary>
    /// A multi-touch swipe gesture recognizer.
    /// </summary>
    public class SwipeRecognizer : PlatformSwipeRecognizer<NSView>
    {
        private readonly NSPanGestureRecognizer _recognizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwipeRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        /// <param name="directionMask">Optional swipe direction mask.</param>
        /// <param name="numberOfTouchesRequired">Optional number of touches required.</param>
        public SwipeRecognizer(NSView view, SwipeDirection directionMask = Defaults.DirectionMask, int numberOfTouchesRequired = Defaults.NumberofTouchesRequired) : base(view, directionMask, numberOfTouchesRequired)
        {
            _recognizer = new NSPanGestureRecognizer(OnSwiping);
            view.AddGestureRecognizer(_recognizer);

            void OnSwiping(NSPanGestureRecognizer recognizer)
            {
                var point = recognizer.LocationInView(View);
                switch (recognizer.State)
                {
                    case NSGestureRecognizerState.Began:
                        OnTouchesBegan(point.X, point.Y);
                        OnSwipeBegan(point.X, point.Y);
                        break;

                    case NSGestureRecognizerState.Cancelled:
                    case NSGestureRecognizerState.Failed:
                        OnSwipeCancelled();
                        OnTouchesEnded(point.X, point.Y);
                        break;

                    case NSGestureRecognizerState.Ended:
                        OnSwipeEnded(point.X, point.Y);
                        OnTouchesEnded(point.X, point.Y);
                        break;
                }
            }
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.RemoveGestureRecognizer(_recognizer);
        }
    }
}