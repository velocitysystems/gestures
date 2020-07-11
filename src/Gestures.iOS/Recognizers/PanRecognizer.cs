// <copyright file="PanRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using Foundation;
using UIKit;

namespace Velocity.Gestures.iOS
{
    /// <summary>
    /// A multi-touch pan gesture recognizer.
    /// </summary>
    public class PanRecognizer : PlatformPanRecognizer<UIView>
    {
        private readonly UIPanGestureRecognizer _recognizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PanRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        public PanRecognizer(UIView view) : base(view)
        {
            _recognizer = new NativePanGestureRecognizer(this);
            view.AddGestureRecognizer(_recognizer);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.RemoveGestureRecognizer(_recognizer);
        }

        private class NativePanGestureRecognizer : UIPanGestureRecognizer
        {
            private readonly PanRecognizer _recognizer;

            public NativePanGestureRecognizer(PanRecognizer recognizer)
            {
                _recognizer = recognizer;

                CancelsTouchesInView = false;
                ShouldReceiveTouch += (UIGestureRecognizer r, UITouch touch) => touch.View == recognizer.View;

                AddTarget(() =>
                {
                    switch (State)
                    {
                        case UIGestureRecognizerState.Began:
                            if (NumberOfTouches != recognizer.NumberOfTouchesRequired)
                            {
                                return;
                            }

                            recognizer.OnPanningStateChanged(GestureState.Began);
                            break;

                        case UIGestureRecognizerState.Changed:
                            if (NumberOfTouches != recognizer.NumberOfTouchesRequired)
                            {
                                recognizer.OnPanningStateChanged(GestureState.Ended);
                                return;
                            }
                                
                            var translation = TranslationInView(recognizer.View);
                            recognizer.OnPanningDeltaChanged(translation.X, translation.Y);
                            break;

                        case UIGestureRecognizerState.Cancelled:
                            recognizer.OnPanningStateChanged(GestureState.Cancelled);
                            break;

                        case UIGestureRecognizerState.Failed:
                            recognizer.OnPanningStateChanged(GestureState.Failed);
                            break;

                        case UIGestureRecognizerState.Ended:
                            if (NumberOfTouches != recognizer.NumberOfTouchesRequired)
                            {
                                recognizer.OnPanningStateChanged(GestureState.Ended);
                                return;
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