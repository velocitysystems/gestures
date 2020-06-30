// <copyright file="TapRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System.Windows;
using System.Windows.Input;

namespace Velocity.Gestures.WPF
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
        /// <param name="numberOfTouchesRequired">Optional number of touches required.</param>
        /// <param name="numberOfTapsRequired">Optional number of taps required.</param>
        public TapRecognizer(FrameworkElement view, int numberOfTouchesRequired = 1, int numberOfTapsRequired = 1) : base(view, numberOfTouchesRequired, numberOfTapsRequired)
        {
            View.MouseLeftButtonDown += OnViewMouseLeftButtonDown;
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            View.MouseLeftButtonDown -= OnViewMouseLeftButtonDown;
        }

        private void OnViewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) => OnTapped();
    }
}