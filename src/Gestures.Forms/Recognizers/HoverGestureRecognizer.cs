// <copyright file="HoverGestureRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms
{
    /// <summary>
    /// A multi-touch hover gesture recognizer.
    /// </summary>
    public class HoverGestureRecognizer : GestureRecognizer
    {
        /// <summary>
        /// The hovering event handler.
        /// </summary>
        public event EventHandler<HoverEventArgs> Hovering;

        /// <summary>
        /// Invoke the hovering event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The hover event.</param>
        internal void InvokeHovering(View sender, HoverEvent e)
        {
            Hovering?.Invoke(sender, new HoverEventArgs(e));
            if (e.State == GestureState.Ended && Command is ICommand cmd && cmd.CanExecute(CommandParameter))
            {
                cmd.Execute(CommandParameter);
            }
        }
    }
}