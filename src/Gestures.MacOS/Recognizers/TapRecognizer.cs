// <copyright file="TapRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using AppKit;

namespace Velocity.Gestures.MacOS
{
    /// <summary>
    /// A multi-touch tap gesture recognizer.
    /// </summary>
    public class TapRecognizer : TapRecognizerBase<NSView>
    {
        private readonly NSClickGestureRecognizer _recognizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TapRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        /// <param name="numberOfTouchesRequired">Optional number of touches required.</param>
        /// <param name="numberOfTapsRequired">Optional number of taps required.</param>
        public TapRecognizer(NSView view, int numberOfTouchesRequired = 1, int numberOfTapsRequired = 1) : base(view, numberOfTouchesRequired, numberOfTapsRequired)
        {
            _recognizer = new NativeTapGestureRecognizer(this);
            view.AddGestureRecognizer(_recognizer);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.RemoveGestureRecognizer(_recognizer);
        }

        private class NativeTapGestureRecognizer : NSClickGestureRecognizer
        {
            public NativeTapGestureRecognizer(TapRecognizer recognizer) : base(() => recognizer.OnTapped())
            {
                NumberOfTouchesRequired = recognizer.NumberOfTouchesRequired;
                NumberOfClicksRequired = recognizer.NumberOfTapsRequired;
            }
        }
    }
}