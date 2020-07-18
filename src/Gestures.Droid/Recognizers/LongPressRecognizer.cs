// <copyright file="LongPressRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using Android.Content;
using Android.Views;

namespace Velocity.Gestures.Droid
{
    /// <summary>
    /// A multi-touch long-press gesture recognizer.
    /// </summary>
    public class LongPressRecognizer : PlatformLongPressRecognizer<View>
    {
        private readonly NativeLongPressGestureRecognizer _recognizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="LongPressRecognizer"/> class.
        /// </summary>
        /// <param name="context">The application context.</param>
        /// <param name="view">The native view.</param>
        /// <param name="numberOfTouchesRequired">Optional number of touches required.</param>
        public LongPressRecognizer(Context context, View view, int numberOfTouchesRequired = Defaults.NumberofTouchesRequired) : base(view, numberOfTouchesRequired)
        {
            _recognizer = new NativeLongPressGestureRecognizer(context, this);
            view.SetOnTouchListener(_recognizer);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            _recognizer.Dispose();
            View.SetOnTouchListener(null);
        }

        private class NativeLongPressGestureRecognizer : GestureDetector.SimpleOnGestureListener, View.IOnTouchListener
        {
            private readonly GestureDetector _detector;
            private readonly LongPressRecognizer _recognizer;            

            public NativeLongPressGestureRecognizer(Context context, LongPressRecognizer recognizer)
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
            public override void OnLongPress(MotionEvent e)
            {
                base.OnLongPress(e);
                _recognizer.OnLongPressed();
            }
        }
    }
}