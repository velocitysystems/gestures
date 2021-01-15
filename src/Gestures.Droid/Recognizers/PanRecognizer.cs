// <copyright file="PanRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using Android.Content;
using Android.Views;

namespace Velocity.Gestures.Droid
{
    /// <summary>
    /// A multi-touch pan gesture recognizer.
    /// </summary>
    public class PanRecognizer : PlatformPanRecognizer<View>
    {
        private readonly NativePanRecognizerRecognizer _recognizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PanRecognizer"/> class.
        /// </summary>
        /// <param name="context">The application context.</param>
        /// <param name="view">The native view.</param>
        public PanRecognizer(Context context, View view) : base(view)
        {
            _recognizer = new NativePanRecognizerRecognizer(context, this);
            view.SetOnTouchListener(_recognizer);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            _recognizer.Dispose();
            View.SetOnTouchListener(null);
        }

        private class NativePanRecognizerRecognizer : GestureDetector.SimpleOnGestureListener, View.IOnTouchListener
        {
            private readonly GestureDetector _detector;
            private readonly PanRecognizer _recognizer;            

            public NativePanRecognizerRecognizer(Context context, PanRecognizer recognizer)
            {
                _detector = new GestureDetector(context, this);
                _recognizer = recognizer;
            }

            /// <inheritdoc/>
            public bool OnTouch(View v, MotionEvent e)
            {
                _detector.OnTouchEvent(e);
                switch (e.Action)
                {
                    case MotionEventActions.Down:
                        _recognizer.OnTouchesBegan(e.GetX(), e.GetY());
                        _recognizer.OnPanningStateChanged(GestureState.Began);
                        break;
                    case MotionEventActions.Up:
                        _recognizer.OnTouchesEnded(e.GetX(), e.GetY());
                        _recognizer.OnPanningStateChanged(GestureState.Ended);
                        break;
                }

                return true;
            }

            /// <inheritdoc/>
            public override bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
            {
                _recognizer.OnPanningDeltaChanged(e2.GetX() - e1.GetX(), e2.GetY() - e1.GetY());
                return true;
            }
        }
    }
}