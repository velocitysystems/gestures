// <copyright file="KeyListener.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System.Windows;
using System.Windows.Input;

namespace Velocity.Gestures.WPF
{
    /// <summary>
    /// A key interaction listener.
    /// </summary>
    public class KeyListener : PlatformKeyListener<FrameworkElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyListener"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        public KeyListener(FrameworkElement view) : base(view)
        {
            Application.Current.MainWindow.KeyDown += OnKeyDown;
            Application.Current.MainWindow.KeyUp += OnKeyUp;
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            Application.Current.MainWindow.KeyDown -= OnKeyDown;
            Application.Current.MainWindow.KeyUp -= OnKeyUp;
        }

        private void OnKeyDown(object sender, KeyEventArgs e) => OnKeyDown(e.Key.ToKey());

        private void OnKeyUp(object sender, KeyEventArgs e) => OnKeyUp(e.Key.ToKey());
    }
}