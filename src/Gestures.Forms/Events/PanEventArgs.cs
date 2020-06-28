// <copyright file="PanEventArgs.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;

namespace Velocity.Gestures.Forms
{
    /// <summary>
    /// Pan event arguments.
    /// </summary>
    public sealed class PanEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PanEventArgs"/> class.
        /// </summary>
        /// <param name="e">The pan event.</param>
        internal PanEventArgs(PanEvent e)
        {
            State = e.State;
            TotalX = e.TotalX;
            TotalY = e.TotalY;
        }

        /// <summary>
        /// Gets the gesture state.
        /// </summary>
        public GestureState State { get; }

        /// <summary>
        /// Gets the translation along the X-axis.
        /// </summary>
        public double TotalX { get; }

        /// <summary>
        /// Gets the translation along the Y-axis.
        /// </summary>
        public double TotalY { get; }
    }
}