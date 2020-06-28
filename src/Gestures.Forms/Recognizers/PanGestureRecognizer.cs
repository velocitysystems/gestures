// <copyright file="PanGestureRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms
{
    /// <summary>
    /// A multi-touch pan gesture recognizer.
    /// </summary>
    public class PanGestureRecognizer : GestureRecognizer
    {
        /// <summary>
        /// The panning event handler.
        /// </summary>
        public event EventHandler<PanEventArgs> Panning;

        /// <summary>
        /// Invoke the panning event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The pan event.</param>
        internal void InvokePanning(View sender, PanEvent e)
        {
            Panning?.Invoke(sender, new PanEventArgs(e));
            if (e.State == GestureState.Ended && Command is ICommand cmd && cmd.CanExecute(CommandParameter))
            {
                cmd.Execute(CommandParameter);
            }
        }
    }
}