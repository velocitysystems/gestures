// <copyright file="Defaults.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

namespace Velocity.Gestures
{
    /// <summary>
    /// Defaults for platform recognizers.
    /// </summary>
    public struct Defaults
    {
        /// <summary>
        /// The default number of touches required.
        /// </summary>
        public const int NumberofTouchesRequired = 1;

        /// <summary>
        /// The default number of taps required.
        /// </summary>
        public const int NumberOfTapsRequired = 1;

        /// <summary>
        /// The default swipe direction mask.
        /// </summary>
        public const SwipeDirection DirectionMask = SwipeDirection.Any;

        /// <summary>
        /// The default swipe direction threshold.
        /// This is only used on platforms which use the swipe gesture algorithm.
        /// </summary>
        public const int Threshold = 100;
    }
}