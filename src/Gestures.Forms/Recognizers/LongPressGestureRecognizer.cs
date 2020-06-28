// <copyright file="LongPressGestureRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms
{
    /// <summary>
    /// A multi-touch long-press gesture recognizer.
    /// </summary>
    public class LongPressGestureRecognizer : GestureRecognizer
    {
        /// <summary>
        /// The long-pressed event handler.
        /// </summary>
        public event EventHandler LongPressed;

        /// <summary>
        /// Invoke the long-pressed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        internal void InvokeLongPressed(View sender)
        {
            LongPressed?.Invoke(sender, null);
            if (Command is ICommand cmd && cmd.CanExecute(CommandParameter))
            {
                cmd.Execute(CommandParameter);
            }
        }
    }
}