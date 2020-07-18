// <copyright file="HoverEvent.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

namespace Velocity.Gestures
{
    /// <summary>
    /// A hover event raised by the <see cref="IHoverRecognizer{TView}"/>.
    /// </summary>
    public sealed class HoverEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HoverEvent"/> class.
        /// </summary>
        /// <param name="state">The gesture state.</param>
        internal HoverEvent(GestureState state)
        {
            State = state;
        }

        /// <summary>
        /// Gets the gesture state.
        /// </summary>
        public GestureState State { get; }
    }
}