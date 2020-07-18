// <copyright file="IHoverRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;

namespace Velocity.Gestures
{
    /// <summary>
    /// A multi-touch hover gesture recognizer.
    /// </summary>
    /// <typeparam name="TView">The native view.</typeparam>
    public interface IHoverRecognizer<TView> : IRecognizer<TView> where TView : class
    {
        /// <summary>
        /// Gets the hovering observable.
        /// </summary>
        IObservable<HoverEvent> Hovering { get; }
    }
}