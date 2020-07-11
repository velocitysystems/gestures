// <copyright file="LongPressRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using AppKit;

namespace Velocity.Gestures.MacOS
{
    /// <summary>
    /// A multi-touch long-press gesture recognizer.
    /// </summary>
    public class LongPressRecognizer : PlatformLongPressRecognizer<NSView>
    {
        private readonly NSPressGestureRecognizer _recognizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="LongPressRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        /// <param name="numberOfTouchesRequired">Optional number of touches required.</param>
        public LongPressRecognizer(NSView view, int numberOfTouchesRequired = 1) : base(view, numberOfTouchesRequired)
        {
            _recognizer = new NativeLongPressGestureRecognizer(this, OnLongPressing);
            view.AddGestureRecognizer(_recognizer);

            void OnLongPressing(NSPressGestureRecognizer recognizer)
            {
                var point = recognizer.LocationInView(View);
                switch (recognizer.State)
                {
                    case NSGestureRecognizerState.Began:
                        OnTouchesBegan(point.X, point.Y);
                        OnLongPressed();
                        break;

                    case NSGestureRecognizerState.Cancelled:
                    case NSGestureRecognizerState.Failed:
                    case NSGestureRecognizerState.Ended:
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

        private class NativeLongPressGestureRecognizer : NSPressGestureRecognizer
        {
            public NativeLongPressGestureRecognizer(LongPressRecognizer recognizer, Action<NSPressGestureRecognizer> action) : base(action)
            {
                NumberOfTouchesRequired = recognizer.NumberOfTouchesRequired;
            }
        }
    }
}