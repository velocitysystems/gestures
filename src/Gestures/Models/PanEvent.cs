// <copyright file="PanEvent.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

namespace Velocity.Gestures
{
    /// <summary>
    /// A pan event raised by the <see cref="IPanRecognizer{TView}"/>.
    /// </summary>
    public sealed class PanEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PanEvent"/> class.
        /// </summary>
        /// <param name="state">The gesture state.</param>
        internal PanEvent(GestureState state)
        {
            State = state;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PanEvent"/> class.
        /// </summary>
        /// <param name="totalX">The translation along the X-axis.</param>
        /// <param name="totalY">The translation along the Y-axis.</param>
        internal PanEvent(double totalX, double totalY)
        {
            State = GestureState.Changed;
            TotalX = totalX;
            TotalY = totalY;
        }

        /// <summary>
        /// Gets the gesture state.
        /// </summary>
        public GestureState State { get; }

        /// <summary>
        /// Gets the translation along the X-axis
        /// </summary>
        public double TotalX { get; }

        /// <summary>
        /// Gets the translation along the Y-axis.
        /// </summary>
        public double TotalY { get; }
    }
}