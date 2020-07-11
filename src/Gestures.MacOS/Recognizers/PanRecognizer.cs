// <copyright file="PanRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using AppKit;

namespace Velocity.Gestures.MacOS
{
    /// <summary>
    /// A multi-touch pan gesture recognizer.
    /// </summary>
    public class PanRecognizer : PlatformPanRecognizer<NSView>
    {
        private readonly NSPanGestureRecognizer _recognizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PanRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        public PanRecognizer(NSView view) : base(view)
        {
            _recognizer = new NSPanGestureRecognizer(OnPanning);
            view.AddGestureRecognizer(_recognizer);

            void OnPanning(NSPanGestureRecognizer recognizer)
            {
                var point = recognizer.LocationInView(View);
                switch (recognizer.State)
                {
                    case NSGestureRecognizerState.Began:
                        OnTouchesBegan(point.X, point.Y);
                        OnPanningStateChanged(GestureState.Began);
                        break;

                    case NSGestureRecognizerState.Changed:
                        var translation = recognizer.TranslationInView(view);
                        OnPanningDeltaChanged(translation.X, translation.Y);
                        break;

                    case NSGestureRecognizerState.Cancelled:
                        OnPanningStateChanged(GestureState.Cancelled);
                        OnTouchesEnded(point.X, point.Y);
                        break;

                    case NSGestureRecognizerState.Failed:
                        OnPanningStateChanged(GestureState.Failed);
                        OnTouchesEnded(point.X, point.Y);
                        break;

                    case NSGestureRecognizerState.Ended:
                        OnPanningStateChanged(GestureState.Ended);
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