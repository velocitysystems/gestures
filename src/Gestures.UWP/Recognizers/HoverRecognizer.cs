// <copyright file="HoverRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Velocity.Gestures.UWP
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
            View.PointerEntered += OnPointerEntered;
            View.PointerExited += OnPointerExited;
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.PointerEntered -= OnPointerEntered;
            View.PointerExited -= OnPointerExited;
        }

        private void OnPointerEntered(object sender, PointerRoutedEventArgs e)
        {
            var point = e.GetCurrentPoint(View);
            OnTouchesBegan(point.Position.X, point.Position.Y);
            OnHoveringStateChanged(GestureState.Began);
        }

        private void OnPointerExited(object sender, PointerRoutedEventArgs e)
        {
            var point = e.GetCurrentPoint(View);
            OnHoveringStateChanged(GestureState.Ended);
            OnTouchesEnded(point.Position.X, point.Position.Y);
        }
    }
}