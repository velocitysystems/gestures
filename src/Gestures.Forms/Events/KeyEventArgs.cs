// <copyright file="KeyEventArgs.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;

namespace Velocity.Gestures.Forms
{
    /// <summary>
    /// Key event arguments.
    /// </summary>
    public sealed class KeyEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyEventArgs"/> class.
        /// </summary>
        /// <param name="keys">The key(s) pressed.</param>
        internal KeyEventArgs(params Key[] keys)
        {
            Keys = keys;
        }

        /// <summary>
        /// Gets the key(s) pressed as an array of <see cref="Key"/>.
        /// </summary>
        public Key[] Keys { get; }
    }
}