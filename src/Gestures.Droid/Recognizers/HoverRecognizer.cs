// <copyright file="HoverRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using Android.Content;
using Android.Views;

namespace Velocity.Gestures.Droid
{
    /// <summary>
    /// A multi-touch hover gesture recognizer.
    /// </summary>
    public class HoverRecognizer : PlatformHoverRecognizer<View>
    {
        private readonly NativeHoverGestureRecognizer _recognizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="HoverRecognizer"/> class.
        /// </summary>
        /// <param name="context">The application context.</param>
        /// <param name="view">The native view.</param>
        public HoverRecognizer(Context context, View view) : base(view)
        {
            _recognizer = new NativeHoverGestureRecognizer(this);
            view.SetOnHoverListener(_recognizer);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            _recognizer.Dispose();
            View.SetOnHoverListener(null);
        }

        private class NativeHoverGestureRecognizer : Java.Lang.Object, View.IOnHoverListener
        {
            private readonly HoverRecognizer _recognizer;            

            public NativeHoverGestureRecognizer(HoverRecognizer recognizer)
            {
                _recognizer = recognizer;
            }

            public bool OnHover(View v, MotionEvent e)
            {
                switch (e.Action)
                {
                    case MotionEventActions.HoverEnter:
                        _recognizer.OnTouchesBegan(e.GetX(), e.GetY());
                        _recognizer.OnHoveringStateChanged(GestureState.Began);
                        break;
                    case MotionEventActions.HoverExit:
                        _recognizer.OnHoveringStateChanged(GestureState.Ended);
                        _recognizer.OnTouchesEnded(e.GetX(), e.GetY());
                        break;
                }

                return true;
            }
        }
    }
}