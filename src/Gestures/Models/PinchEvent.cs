// <copyright file="PinchEvent.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

namespace Velocity.Gestures
{
    /// <summary>
    /// A pinch event raised by the <see cref="IPinchRecognizer{TView}"/>.
    /// </summary>
    public sealed class PinchEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PinchEvent"/> class.
        /// </summary>
        /// <param name="x">The X-coordinate.</param>
        /// <param name="y">The Y-coordinate.</param>
        internal PinchEvent(double x, double y)
        {
            State = GestureState.Began;
            Origin = new Point(x, y);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PinchEvent"/> class.
        /// </summary>
        /// <param name="scale">The pinch scale.</param>
        internal PinchEvent(double scale)
        {
            State = GestureState.Changed;
            Scale = scale;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PinchEvent"/> class.
        /// </summary>
        /// <param name="state">The gesture state.</param>
        internal PinchEvent(GestureState state)
        {
            State = state;
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