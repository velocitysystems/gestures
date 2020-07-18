// <copyright file="TapRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using AppKit;

namespace Velocity.Gestures.MacOS
{
    /// <summary>
    /// A multi-touch tap gesture recognizer.
    /// </summary>
    public class TapRecognizer : PlatformTapRecognizer<NSView>
    {
        private readonly NSClickGestureRecognizer _recognizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TapRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        /// <param name="numberOfTapsRequired">Optional number of taps required.</param>
        /// <param name="numberOfTouchesRequired">Optional number of touches required.</param>
        public TapRecognizer(NSView view, int numberOfTapsRequired = Defaults.NumberOfTapsRequired, int numberOfTouchesRequired = Defaults.NumberofTouchesRequired) : base(view, numberOfTapsRequired, numberOfTouchesRequired)
        {
            _recognizer = new NativeTapGestureRecognizer(this, OnClicking);
            view.AddGestureRecognizer(_recognizer);

            void OnClicking(NSClickGestureRecognizer recognizer)
            {
                var point = recognizer.LocationInView(View);

                OnTouchesBegan(point.X, point.Y);
                OnTapped();
                OnTouchesEnded(point.X, point.Y);                
            }
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.RemoveGestureRecognizer(_recognizer);
        }

        private class NativeTapGestureRecognizer : NSClickGestureRecognizer
        {
            public NativeTapGestureRecognizer(TapRecognizer recognizer, Action<NSClickGestureRecognizer> action) : base(action)
            {
                NumberOfClicksRequired = recognizer.NumberOfTapsRequired;
                NumberOfTouchesRequired = recognizer.NumberOfTouchesRequired;                
            }
        }
    }
}