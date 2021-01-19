// <copyright file="PinchRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using Android.Content;
using Android.Views;
using AndroidX.Core.View;

namespace Velocity.Gestures.Droid
{
    /// <summary>
    /// A multi-touch pinch gesture recognizer.
    /// </summary>
    public class PinchRecognizer : PlatformPinchRecognizer<View>
    {
        private readonly NativePinchRecognizerRecognizer _recognizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PinchRecognizer"/> class.
        /// </summary>
        /// <param name="context">The application context.</param>
        /// <param name="view">The native view.</param>
        public PinchRecognizer(Context context, View view) : base(view)
        {
            _recognizer = new NativePinchRecognizerRecognizer(context, this);
            view.SetOnTouchListener(_recognizer);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            _recognizer.Dispose();
            View.SetOnTouchListener(null);
        }

        private class NativePinchRecognizerRecognizer : GestureDetector.SimpleOnGestureListener, ScaleGestureDetector.IOnScaleGestureListener, View.IOnTouchListener
        {
            private readonly ScaleGestureDetector _detector;
            private readonly PinchRecognizer _recognizer;            

            public NativePinchRecognizerRecognizer(Context context, PinchRecognizer recognizer)
            {
                _detector = new ScaleGestureDetector(context, this);
                _recognizer = recognizer;

                ScaleGestureDetectorCompat.SetQuickScaleEnabled(_detector, true);
            }

            /// <inheritdoc/>
            public bool OnTouch(View v, MotionEvent e)
            {
                _detector.OnTouchEvent(e);
                switch (e.Action)
                {
                    case MotionEventActions.Down:
                        _recognizer.OnTouchesBegan(e.GetX(), e.GetY());
                        break;
                    case MotionEventActions.Up:
                        _recognizer.OnTouchesEnded(e.GetX(), e.GetY());
                        break;
                }

                return true;
            }

            /// <inheritdoc/>
            public bool OnScale(ScaleGestureDetector detector)
            {
                _recognizer.OnPinchingScaleChanged(detector.ScaleFactor);
                return true;
            }

            /// <inheritdoc/>
            public bool OnScaleBegin(ScaleGestureDetector detector)
            {
                _recognizer.OnPinchingBegan(detector.FocusX, detector.FocusY);
                return true;
            }

            /// <inheritdoc/>
            public void OnScaleEnd(ScaleGestureDetector detector) => _recognizer.OnPinchingStateChanged(GestureState.Ended);
        }
    }
}