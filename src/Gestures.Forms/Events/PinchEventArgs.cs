// <copyright file="PinchEventArgs.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;

namespace Velocity.Gestures.Forms
{
    /// <summary>
    /// Pinch event arguments.
    /// </summary>
    public sealed class PinchEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PinchEventArgs"/> class.
        /// </summary>
        /// <param name="e">The pinch event.</param>
        internal PinchEventArgs(PinchEvent e)
        {
            State = e.State;
            Scale = e.Scale;
            Origin = e.Origin;
        }

        /// <summary>
        /// Gets the gesture state.
        /// </summary>
        public GestureState State { get; }

        /// <summary>
        /// Gets the pinch scale.
        /// </summary>
        public double Scale { get; }

        /// <summary>
        /// Gets the pinch origin.
        /// </summary>
        public Point Origin { get; }
    }
}