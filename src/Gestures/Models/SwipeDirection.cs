// <copyright file="SwipeDirection.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;

namespace Velocity.Gestures
{
    /// <summary>
    /// The swipe direction.
    /// </summary>
    [Flags]
    public enum SwipeDirection
    {
        /// <summary>
        /// Swipe left.
        /// </summary>
        Left = 1,

        /// <summary>
        /// Swipe right.
        /// </summary>
        Right = 2,

        /// <summary>
        /// Swipe up.
        /// </summary>
        Up = 4,

        /// <summary>
        /// Swipe down.
        /// </summary>
        Down = 8,

        /// <summary>
        /// Swipe in any direction.
        /// </summary>
        Any = Left | Right | Up | Down
    }
}