// <copyright file="TapEventArgs.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;

namespace Velocity.Gestures.Forms
{
    /// <summary>
    /// Tap event arguments.
    /// </summary>
    public sealed class TapEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TapEventArgs"/> class.
        /// </summary>
        /// <param name="numberOfTouches">The number of touches received.</param>
        /// <param name="numberOfTaps">The number of taps received.</param>
        internal TapEventArgs(int numberOfTouches, int numberOfTaps)
        {
            NumberOfTouches = numberOfTouches;
            NumberOfTaps = numberOfTaps;
        }

        /// <summary>
        /// Gets the number of touches received.
        /// </summary>
        public int NumberOfTouches { get; }

        /// <summary>
        /// Gets the number of taps received.
        /// </summary>
        public int NumberOfTaps { get; }
    }
}