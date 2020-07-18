// <copyright file="TapRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using Foundation;
using UIKit;

namespace Velocity.Gestures.iOS
{
    /// <summary>
    /// A multi-touch tap gesture recognizer.
    /// </summary>
    public class TapRecognizer : PlatformTapRecognizer<UIView>
    {
        private readonly UITapGestureRecognizer _recognizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TapRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        /// <param name="numberOfTapsRequired">Optional number of taps required.</param>
        /// <param name="numberOfTouchesRequired">Optional number of touches required.</param>
        public TapRecognizer(UIView view, int numberOfTapsRequired = Defaults.NumberOfTapsRequired, int numberOfTouchesRequired = Defaults.NumberofTouchesRequired) : base(view, numberOfTapsRequired, numberOfTouchesRequired)
        {
            _recognizer = new NativeTapGestureRecognizer(this);
            view.AddGestureRecognizer(_recognizer);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.RemoveGestureRecognizer(_recognizer);
        }

        private class NativeTapGestureRecognizer : UITapGestureRecognizer
        {
            private readonly TapRecognizer _recognizer;

            public NativeTapGestureRecognizer(TapRecognizer recognizer)
            {
                _recognizer = recognizer;

                CancelsTouchesInView = false;
                NumberOfTapsRequired = (nuint)recognizer.NumberOfTapsRequired;
                NumberOfTouchesRequired = (nuint)recognizer.NumberOfTouchesRequired;                
                ShouldReceiveTouch += (UIGestureRecognizer r, UITouch touch) => touch.View == recognizer.View;                

                AddTarget(() => recognizer.OnTapped());
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