// <copyright file="SwipeRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Velocity.Gestures.iOS
{
    /// <summary>
    /// A multi-touch swipe gesture recognizer.
    /// </summary>
    public class SwipeRecognizer : SwipeRecognizerBase<UIView>
    {
        private readonly List<UISwipeGestureRecognizer> _recognizers;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwipeRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        /// <param name="directionMask">Optional swipe direction mask.</param>
        public SwipeRecognizer(UIView view, SwipeDirection directionMask = SwipeDirection.Any) : base(view, 1, directionMask)
        {
            _recognizers = new List<UISwipeGestureRecognizer>();

            if (directionMask.HasFlag(SwipeDirection.Any) || directionMask.HasFlag(SwipeDirection.Left))
            {
                var recognizer = new NativeSwipeGestureRecognizer(this, UISwipeGestureRecognizerDirection.Left);
                _recognizers.Add(recognizer);
                view.AddGestureRecognizer(recognizer);
            }

            if (directionMask.HasFlag(SwipeDirection.Any) || directionMask.HasFlag(SwipeDirection.Right))
            {
                var recognizer = new NativeSwipeGestureRecognizer(this, UISwipeGestureRecognizerDirection.Right);
                _recognizers.Add(recognizer);
                view.AddGestureRecognizer(recognizer);
            }

            if (directionMask.HasFlag(SwipeDirection.Any) || directionMask.HasFlag(SwipeDirection.Up))
            {
                var recognizer = new NativeSwipeGestureRecognizer(this, UISwipeGestureRecognizerDirection.Up);
                _recognizers.Add(recognizer);
                view.AddGestureRecognizer(recognizer);
            }

            if (directionMask.HasFlag(SwipeDirection.Any) || directionMask.HasFlag(SwipeDirection.Down))
            {
                var recognizer = new NativeSwipeGestureRecognizer(this, UISwipeGestureRecognizerDirection.Down);
                _recognizers.Add(recognizer);
                view.AddGestureRecognizer(recognizer);
            }           
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            foreach (var recognizer in _recognizers)
            {
                View.RemoveGestureRecognizer(recognizer);
            }
        }

        private class NativeSwipeGestureRecognizer : UISwipeGestureRecognizer
        {
            private readonly SwipeRecognizer _recognizer;

            public NativeSwipeGestureRecognizer(SwipeRecognizer recognizer, UISwipeGestureRecognizerDirection direction)
            {
                _recognizer = recognizer;

                CancelsTouchesInView = false;
                NumberOfTouchesRequired = (nuint)recognizer.NumberOfTouchesRequired;
                Direction = direction;
                ShouldReceiveTouch += (UIGestureRecognizer r, UITouch touch) => touch.View == recognizer.View;

                AddTarget(() => recognizer.OnSwiped(direction.ToSwipeDirection()));
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