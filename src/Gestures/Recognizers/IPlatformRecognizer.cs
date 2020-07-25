// <copyright file="IPlatformRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;

namespace Velocity.Gestures
{
    /// <summary>
    /// A multi-touch gesture recognizer.
    /// </summary>
    /// <typeparam name="TView">The native view.</typeparam>
    public interface IPlatformRecognizer<TView> : IViewAttachment<TView> where TView : class
    {
        /// <summary>
        /// Gets the number of touches required.
        /// </summary>
        int NumberOfTouchesRequired { get; }

        /// <summary>
        /// Gets the touches began observable.
        /// </summary>
        IObservable<Point> TouchesBegan { get; }

        /// <summary>
        /// Gets the touches ended observable.
        /// </summary>
        IObservable<Point> TouchesEnded { get; }
    }
}