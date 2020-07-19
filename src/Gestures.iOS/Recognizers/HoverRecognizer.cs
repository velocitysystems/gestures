// <copyright file="HoverRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using Foundation;
using UIKit;

namespace Velocity.Gestures.iOS
{
    /// <summary>
    /// A multi-touch hover gesture recognizer.
    /// </summary>
    public class HoverRecognizer : PlatformHoverRecognizer<UIView>
    {
        private readonly UIHoverGestureRecognizer _recognizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="HoverRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        public HoverRecognizer(UIView view) : base(view)
        {
            if (!UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                throw new NotSupportedException($"{nameof(HoverRecognizer)} is only supported on iOS 13 and above.");
            }

            _recognizer = new NativeHoverRecognizer(this);
            view.AddGestureRecognizer(_recognizer);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.RemoveGestureRecognizer(_recognizer);
        }

        private class NativeHoverRecognizer : UIHoverGestureRecognizer
        {
            private readonly HoverRecognizer _recognizer;

            public NativeHoverRecognizer(HoverRecognizer recognizer) : base(() => { })
            {
                _recognizer = recognizer;

                CancelsTouchesInView = false;            
                ShouldReceiveTouch += (UIGestureRecognizer r, UITouch touch) => touch.View == recognizer.View;

                AddTarget(() =>
                {
                    switch (State)
                    {
                        case UIGestureRecognizerState.Began:
                            recognizer.OnHoveringStateChanged(GestureState.Began);
                            break;

                        case UIGestureRecognizerState.Cancelled:
                            recognizer.OnHoveringStateChanged(GestureState.Cancelled);
                            break;

                        case UIGestureRecognizerState.Failed:
                            recognizer.OnHoveringStateChanged(GestureState.Failed);
                            break;

                        case UIGestureRecognizerState.Ended:
                            recognizer.OnHoveringStateChanged(GestureState.Ended);
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