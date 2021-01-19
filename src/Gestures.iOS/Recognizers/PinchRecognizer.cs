// <copyright file="PinchRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using Foundation;
using UIKit;

namespace Velocity.Gestures.iOS
{
    /// <summary>
    /// A multi-touch pinch gesture recognizer.
    /// </summary>
    public class PinchRecognizer : PlatformPinchRecognizer<UIView>
    {
        private readonly UIPinchGestureRecognizer _recognizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PinchRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        public PinchRecognizer(UIView view) : base(view)
        {
            _recognizer = new NativePinchGestureRecognizer(this);
            view.AddGestureRecognizer(_recognizer);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.RemoveGestureRecognizer(_recognizer);
        }

        private class NativePinchGestureRecognizer : UIPinchGestureRecognizer
        {
            private readonly PinchRecognizer _recognizer;

            public NativePinchGestureRecognizer(PinchRecognizer recognizer)
            {
                _recognizer = recognizer;

                CancelsTouchesInView = false;
                ShouldReceiveTouch += (UIGestureRecognizer r, UITouch touch) => touch.View == recognizer.View;

                var isPinching = false;
                AddTarget(() =>
                {
                    switch (State)
                    {
                        case UIGestureRecognizerState.Began:
                            if (NumberOfTouches < 2)
                            {
                                return;
                            }

                            var origin = LocationInView(recognizer.View);
                            recognizer.OnPinchingBegan(origin.X, origin.Y);
                            isPinching = true;
                            break;

                        case UIGestureRecognizerState.Changed:
                            if (NumberOfTouches < 2 && isPinching)
                            {
                                recognizer.OnPinchingStateChanged(GestureState.Ended);
                                isPinching = false;
                                return;
                            }

                            recognizer.OnPinchingScaleChanged(Scale);
                            break;

                        case UIGestureRecognizerState.Cancelled:
                            if (isPinching)
                            {
                                recognizer.OnPinchingStateChanged(GestureState.Cancelled);
                                isPinching = false;
                            }

                            break;

                        case UIGestureRecognizerState.Failed:
                            if (isPinching)
                            {
                                recognizer.OnPinchingStateChanged(GestureState.Cancelled);
                                isPinching = false;
                            }

                            break;

                        case UIGestureRecognizerState.Ended:
                            if (isPinching)
                            {
                                recognizer.OnPinchingStateChanged(GestureState.Ended);
                                isPinching = false;
                            }

                            break;
                    }
                });
            }

            public override void TouchesBegan(NSSet touches, UIEvent evt)
            {
                base.TouchesBegan(touches, evt);

                var touch = (UITouch)touches.AnyObject;
                var point = touch.LocationInView(View);
                _recognizer.OnTouchesBegan(point.X, point.Y);
            }

            public override void TouchesEnded(NSSet touches, UIEvent evt)
            {
                base.TouchesEnded(touches, evt);

                var touch = (UITouch)touches.AnyObject;
                var point = touch.LocationInView(View);
                _recognizer.OnTouchesEnded(point.X, point.Y);
            }
        }
    }
}