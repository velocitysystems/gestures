// <copyright file="ISwipeRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;

namespace Velocity.Gestures
{
    /// <summary>
    /// A multi-touch swipe gesture recognizer.
    /// </summary>
    /// <typeparam name="TView">The native view.</typeparam>
    public interface ISwipeRecognizer<TView> : IRecognizer<TView> where TView : class
    {
        /// <summary>
        /// Gets the swipe direction mask.
        /// </summary>
        SwipeDirection DirectionMask { get; }

        /// <summary>
        /// Gets the swiped observable.
        /// </summary>
        IObservable<SwipeDirection> Swiped { get; }
    }
}