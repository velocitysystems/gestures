// <copyright file="KeyListener.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using Windows.UI.Core;
using Windows.UI.Xaml;

namespace Velocity.Gestures.UWP
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
            Window.Current.CoreWindow.KeyDown += OnKeyDown;
            Window.Current.CoreWindow.KeyUp += OnKeyUp;
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            Window.Current.CoreWindow.KeyDown -= OnKeyDown;
            Window.Current.CoreWindow.KeyUp -= OnKeyUp;
        }

        private void OnKeyDown(object sender, KeyEventArgs e) => OnKeyDown(e.VirtualKey.ToKey());

        private void OnKeyUp(object sender, KeyEventArgs e) => OnKeyUp(e.VirtualKey.ToKey());
    }
}