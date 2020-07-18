// <copyright file="LongPressRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using Foundation;
using UIKit;

namespace Velocity.Gestures.iOS
{
    /// <summary>
    /// A multi-touch long-press gesture recognizer.
    /// </summary>
    public class LongPressRecognizer : PlatformLongPressRecognizer<UIView>
    {
        private readonly UILongPressGestureRecognizer _recognizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="LongPressRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        /// <param name="numberOfTouchesRequired">Optional number of touches required.</param>
        public LongPressRecognizer(UIView view, int numberOfTouchesRequired = Defaults.NumberofTouchesRequired) : base(view, numberOfTouchesRequired)
        {
            _recognizer = new NativeLongPressGestureRecognizer(this);
            view.AddGestureRecognizer(_recognizer);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.RemoveGestureRecognizer(_recognizer);
        }

        private class NativeLongPressGestureRecognizer : UILongPressGestureRecognizer
        {
            private readonly LongPressRecognizer _recognizer;

            public NativeLongPressGestureRecognizer(LongPressRecognizer recognizer)
            {
                _recognizer = recognizer;

                CancelsTouchesInView = false;
                NumberOfTouchesRequired = (nuint)recognizer.NumberOfTouchesRequired;
                ShouldReceiveTouch += (UIGestureRecognizer r, UITouch touch) => touch.View == recognizer.View;

                AddTarget(() =>
                {
                    if (State == UIGestureRecognizerState.Began)
                    {
                        recognizer.OnLongPressed();
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