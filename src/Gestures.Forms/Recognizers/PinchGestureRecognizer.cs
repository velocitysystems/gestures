// <copyright file="PinchGestureRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms
{
    /// <summary>
    /// A multi-touch pinch gesture recognizer.
    /// </summary>
    public class PinchGestureRecognizer : GestureRecognizer
    {
        /// <summary>
        /// The pinching event handler.
        /// </summary>
        public event EventHandler<PinchEventArgs> Pinching;

        /// <summary>
        /// Invoke the pinching event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The pinch event.</param>
        internal void InvokePinching(View sender, PinchEvent e)
        {
            Pinching?.Invoke(sender, new PinchEventArgs(e));
            if (e.State == GestureState.Ended && Command is ICommand cmd && cmd.CanExecute(CommandParameter))
            {
                cmd.Execute(CommandParameter);
            }
        }
    }
}