// <copyright file="LongPressRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Velocity.Gestures.UWP
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
        public LongPressRecognizer(FrameworkElement view, int numberOfTouchesRequired = 1) : base(view, numberOfTouchesRequired)
        {
            View.RightTapped += OnViewRightTapped;
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.RightTapped -= OnViewRightTapped;
        }

        private void OnViewRightTapped(object sender, RightTappedRoutedEventArgs e) => OnLongPressed();
    }
}