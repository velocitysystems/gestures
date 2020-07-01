// <copyright file="TapRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using Android.Content;
using Android.Views;

namespace Velocity.Gestures.Droid
{
    /// <summary>
    /// A multi-touch tap gesture recognizer.
    /// </summary>
    public class TapRecognizer : TapRecognizerBase<View>
    {
        private readonly NativeTapGestureRecognizer _recognizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TapRecognizer"/> class.
        /// </summary>
        /// <param name="context">The application context.</param>
        /// <param name="view">The native view.</param>
        /// <param name="numberOfTouchesRequired">Optional number of touches required.</param>
        /// <param name="numberOfTapsRequired">Optional number of taps required.</param>
        public TapRecognizer(Context context, View view, int numberOfTouchesRequired = 1, int numberOfTapsRequired = 1) : base(view, numberOfTouchesRequired, numberOfTapsRequired)
        {
            _recognizer = new NativeTapGestureRecognizer(context, this);
            view.SetOnTouchListener(_recognizer);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            _recognizer.Dispose();
            View.SetOnTouchListener(null);
        }

        private class NativeTapGestureRecognizer : GestureDetector.SimpleOnGestureListener, View.IOnTouchListener
        {
            private readonly GestureDetector _detector;
            private readonly TapRecognizer _recognizer;            

            public NativeTapGestureRecognizer(Context context, TapRecognizer recognizer)
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
                        break;
                    case MotionEventActions.Up:
                        _recognizer.OnTouchesEnded(e.GetX(), e.GetY());
                        break;
                }

                return true;
            }

            /// <inheritdoc/>
            public override bool OnSingleTapUp(MotionEvent e)
            {
                _recognizer.OnTapped();
                return true;
            }
        }
    }
}