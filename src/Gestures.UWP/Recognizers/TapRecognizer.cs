// <copyright file="TapRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Velocity.Gestures.UWP
{
    /// <summary>
    /// A multi-touch tap gesture recognizer.
    /// </summary>
    public class TapRecognizer : TapRecognizerBase<FrameworkElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TapRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        /// <param name="numberOfTapsRequired">Optional number of taps required.</param>
        /// <param name="numberOfTouchesRequired">Optional number of touches required.</param>
        public TapRecognizer(FrameworkElement view, int numberOfTapsRequired = 1, int numberOfTouchesRequired = 1) : base(view, numberOfTapsRequired, numberOfTouchesRequired)
        {
            View.Tapped += OnViewTapped;
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.Tapped -= OnViewTapped;
        }

        private void OnViewTapped(object sender, TappedRoutedEventArgs e) => OnTapped();
    }
}