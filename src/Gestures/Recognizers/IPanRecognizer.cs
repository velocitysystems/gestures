// <copyright file="IPanRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;

namespace Velocity.Gestures
{
    /// <summary>
    /// A multi-touch pan gesture recognizer.
    /// </summary>
    /// <typeparam name="TView">The native view.</typeparam>
    public interface IPanRecognizer<TView> : IPlatformRecognizer<TView> where TView : class
    {
        /// <summary>
        /// Gets the panning observable.
        /// </summary>
        IObservable<PanEvent> Panning { get; }
    }
}