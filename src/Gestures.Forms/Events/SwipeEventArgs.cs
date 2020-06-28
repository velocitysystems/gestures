// <copyright file="SwipeEventArgs.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;

namespace Velocity.Gestures.Forms
{
    /// <summary>
    /// Swipe event arguments.
    /// </summary>
    public sealed class SwipeEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwipeEventArgs"/> class.
        /// </summary>
        /// <param name="direction">The swipe direction.</param>
        internal SwipeEventArgs(SwipeDirection direction)
        {
            Direction = direction;
        }

        /// <summary>
        /// Gets the swipe direction.
        /// </summary>
        public SwipeDirection Direction { get; }
    }
}