// <copyright file="GestureState.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

namespace Velocity.Gestures
{
    /// <summary>
    /// The gesture state.
    /// </summary>
    public enum GestureState
    {
        /// <summary>
        /// Geture began.
        /// </summary>
        Began,

        /// <summary>
        /// Gesture changed.
        /// </summary>
        Changed,

        /// <summary>
        /// Gesture ended.
        /// </summary>
        Ended,

        /// <summary>
        /// Gesture cancelled.
        /// </summary>
        Cancelled,

        /// <summary>
        /// Gestured failed.
        /// </summary>
        Failed
    }
}