// <copyright file="LongPressRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System.Windows;
using System.Windows.Input;

namespace Velocity.Gestures.WPF
{
    /// <summary>
    /// A multi-touch long-press gesture recognizer.
    /// </summary>
    public class LongPressRecognizer : PlatformLongPressRecognizer<FrameworkElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LongPressRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        /// <param name="numberOfTouchesRequired">Optional number of touches required.</param>
        public LongPressRecognizer(FrameworkElement view, int numberOfTouchesRequired = Defaults.NumberofTouchesRequired) : base(view, numberOfTouchesRequired)
        {
            View.MouseRightButtonDown += OnMouseRightButtonDown;
            View.MouseDown += OnMouseDown;
            View.MouseUp += OnMouseUp;
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.MouseRightButtonDown -= OnMouseRightButtonDown;
            View.MouseDown -= OnMouseDown;
            View.MouseUp -= OnMouseUp;
        }

        private void OnMouseRightButtonDown(object sender, MouseButtonEventArgs e) => OnLongPressed();

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(View);
            OnTouchesBegan(point.X, point.Y);
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(View);
            OnTouchesEnded(point.X, point.Y);
        }
    }
}