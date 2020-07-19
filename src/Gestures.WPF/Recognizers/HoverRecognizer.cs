// <copyright file="HoverRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System.Windows;
using System.Windows.Input;

namespace Velocity.Gestures.WPF
{
    /// <summary>
    /// A multi-touch hover gesture recognizer.
    /// </summary>
    public class HoverRecognizer : PlatformHoverRecognizer<FrameworkElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HoverRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        public HoverRecognizer(FrameworkElement view) : base(view)
        {
            View.MouseEnter += OnMouseEnter;
            View.MouseLeave += OnMouseLeave;
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.MouseEnter -= OnMouseEnter;
            View.MouseLeave -= OnMouseLeave;
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            var point = e.GetPosition(View);

            OnTouchesBegan(point.X, point.Y);
            OnHoveringStateChanged(GestureState.Began);
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            var point = e.GetPosition(View);

            OnHoveringStateChanged(GestureState.Ended);
            OnTouchesEnded(point.X, point.Y);
        }
    }
}