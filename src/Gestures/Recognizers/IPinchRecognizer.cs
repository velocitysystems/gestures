// <copyright file="IPinchRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;

namespace Velocity.Gestures
{
    /// <summary>
    /// A multi-touch pinch gesture recognizer.
    /// </summary>
    /// <typeparam name="TView">The native view.</typeparam>
    public interface IPinchRecognizer<TView> : IRecognizer<TView> where TView : class
    {
        /// <summary>
        /// Gets the pinching observable.
        /// </summary>
        IObservable<PinchEvent> Pinching { get; }
    }
}