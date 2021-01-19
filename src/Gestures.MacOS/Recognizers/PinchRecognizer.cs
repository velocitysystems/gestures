// <copyright file="PinchRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using AppKit;

namespace Velocity.Gestures.MacOS
{
    /// <summary>
    /// A multi-touch pinch gesture recognizer.
    /// </summary>
    public class PinchRecognizer : PlatformPinchRecognizer<NSView>
    {
        private readonly NSMagnificationGestureRecognizer _recognizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PinchRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        public PinchRecognizer(NSView view) : base(view)
        {
            _recognizer = new NSMagnificationGestureRecognizer(OnPinching);
            view.AddGestureRecognizer(_recognizer);

            void OnPinching(NSMagnificationGestureRecognizer recognizer)
            {
                var point = recognizer.LocationInView(View);
                switch (recognizer.State)
                {
                    case NSGestureRecognizerState.Began:
                        OnTouchesBegan(point.X, point.Y);
                        OnPinchingBegan(point.X, point.Y);
                        break;

                    case NSGestureRecognizerState.Changed:
                        OnPinchingScaleChanged(recognizer.Magnification);
                        break;

                    case NSGestureRecognizerState.Cancelled:
                        OnPinchingStateChanged(GestureState.Cancelled);
                        OnTouchesEnded(point.X, point.Y);
                        break;

                    case NSGestureRecognizerState.Failed:
                        OnPinchingStateChanged(GestureState.Failed);
                        OnTouchesEnded(point.X, point.Y);
                        break;

                    case NSGestureRecognizerState.Ended:
                        OnPinchingStateChanged(GestureState.Ended);
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