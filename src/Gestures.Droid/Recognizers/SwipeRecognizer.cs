// <copyright file="SwipeRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using Android.Content;
using Android.Views;

namespace Velocity.Gestures.Droid
{
    /// <summary>
    /// A multi-touch swipe gesture recognizer.
    /// </summary>
    public class SwipeRecognizer : PlatformSwipeRecognizer<View>
    {
        private readonly NativeSwipeGestureRecognizer _recognizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwipeRecognizer"/> class.
        /// </summary>
        /// <param name="context">The application context.</param>
        /// <param name="view">The native view.</param>
        /// <param name="directionMask">Optional swipe direction mask.</param>
        /// <param name="numberOfTouchesRequired">Optional number of touches required.</param>
        public SwipeRecognizer(Context context, View view, SwipeDirection directionMask = Defaults.DirectionMask, int numberOfTouchesRequired = Defaults.NumberofTouchesRequired) : base(view, directionMask, numberOfTouchesRequired)
        {
            _recognizer = new NativeSwipeGestureRecognizer(context, this);
            view.SetOnTouchListener(_recognizer);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            _recognizer.Dispose();
            View.SetOnTouchListener(null);
        }

        private class NativeSwipeGestureRecognizer : GestureDetector.SimpleOnGestureListener, View.IOnTouchListener
        {
            private readonly GestureDetector _detector;
            private readonly SwipeRecognizer _recognizer;            

            public NativeSwipeGestureRecognizer(Context context, SwipeRecognizer recognizer)
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
            public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
            {
                _recognizer.OnSwipeBegan(e1.GetX(), e1.GetY());
                return _recognizer.OnSwipeEnded(e2.GetX(), e2.GetY());
            }
        }
    }
}