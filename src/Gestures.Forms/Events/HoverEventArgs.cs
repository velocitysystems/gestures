// <copyright file="HoverEventArgs.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;

namespace Velocity.Gestures.Forms
{
    /// <summary>
    /// Hover event arguments.
    /// </summary>
    public sealed class HoverEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HoverEventArgs"/> class.
        /// </summary>
        /// <param name="e">The hover event.</param>
        internal HoverEventArgs(HoverEvent e)
        {
            State = e.State;
        }

        /// <summary>
        /// Gets the gesture state.
        /// </summary>
        public GestureState State { get; }
    }
}