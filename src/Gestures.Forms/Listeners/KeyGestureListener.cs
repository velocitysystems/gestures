// <copyright file="KeyGestureListener.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms
{
    /// <summary>
    /// A key interaction listener.
    /// </summary>
    public class KeyGestureListener : GestureListener
    {
        /// <summary>
        /// The key(s) pressed event handler.
        /// </summary>
        public event EventHandler<KeyEventArgs> Pressed;

        /// <summary>
        /// The key down event handler.
        /// </summary>
        public event EventHandler<Key> KeyDown;

        /// <summary>
        /// The key up event handler.
        /// </summary>
        public event EventHandler<Key> KeyUp;

        /// <summary>
        /// Invoke the key(s) pressed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="keys">The key(s) pressed.</param>
        internal void InvokePressed(View sender, Key[] keys)
        {
            Pressed?.Invoke(sender, new KeyEventArgs(keys));
            if (Command is ICommand cmd && cmd.CanExecute(CommandParameter))
            {
                cmd.Execute(CommandParameter);
            }
        }

        /// <summary>
        /// Invoke the key down event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="key">The key.</param>
        internal void InvokeKeyDown(View sender, Key key) => KeyDown?.Invoke(sender, key);

        /// <summary>
        /// Invoke the key up event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="key">The key.</param>
        internal void InvokeKeyUp(View sender, Key key) => KeyUp?.Invoke(sender, key);
    }
}