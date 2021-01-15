// <copyright file="SwipeRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System.Windows;
using System.Windows.Input;
using WPoint = System.Windows.Point;

namespace Velocity.Gestures.WPF
{
    /// <summary>
    /// A multi-touch swipe gesture recognizer.
    /// </summary>
    public class SwipeRecognizer : PlatformSwipeRecognizer<FrameworkElement>
    {
        private bool _started;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwipeRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        /// <param name="directionMask">Optional swipe direction mask.</param>
        /// <param name="numberOfTouchesRequired">Optional number of touches required.</param>
        public SwipeRecognizer(FrameworkElement view, SwipeDirection directionMask = Defaults.DirectionMask, int numberOfTouchesRequired = Defaults.NumberofTouchesRequired) : base(view, directionMask, numberOfTouchesRequired)
        {
            // On WPF, touch events are promoted to mouse events.
            // However, touch events like TouchDown and ManipulationDelta etc do not fire for pointer actions like on UWP.
            // So we must listen for mouse events rather than touch events.
            View.MouseDown += OnMouseDown;
            View.MouseUp += OnMouseUp;
            View.MouseLeave += OnMouseLeave;
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.MouseDown -= OnMouseDown;
            View.MouseUp -= OnMouseUp;
            View.MouseLeave -= OnMouseLeave;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(View);

            OnTouchesBegan(point.X, point.Y);
            OnSwipeBegan(point.X, point.Y);
            _started = true;
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e) => OnMouseEnded(e.GetPosition(View));

        private void OnMouseLeave(object sender, MouseEventArgs e) => OnMouseEnded(e.GetPosition(View));

        private void OnMouseEnded(WPoint point)
        {
            if (!_started)
            {
                return;
            }

            OnSwipeEnded(point.X, point.Y);
            OnTouchesEnded(point.X, point.Y);
            _started = false;
        }
    }
}