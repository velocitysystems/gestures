// <copyright file="Point.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

namespace Velocity.Gestures
{
    /// <summary>
    /// A point relative to the coordinate system of the native view.
    /// </summary>
    public sealed class Point
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        /// <param name="x">The X-coordinate.</param>
        /// <param name="y">The Y-coordinate.</param>
        internal Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets the X-coordinate.
        /// </summary>
        public double X { get; }

        /// <summary>
        /// Gets the Y-coordinate.
        /// </summary>
        public double Y { get; }
    }
}
