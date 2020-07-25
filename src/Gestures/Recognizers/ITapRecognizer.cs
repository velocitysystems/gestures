// <copyright file="ITapRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.Reactive;

namespace Velocity.Gestures
{
    /// <summary>
    /// A multi-touch tap gesture recognizer.
    /// </summary>
    /// <typeparam name="TView">The native view.</typeparam>
    public interface ITapRecognizer<TView> : IPlatformRecognizer<TView> where TView : class
    {
        /// <summary>
        /// Gets the number of taps required.
        /// </summary>
        int NumberOfTapsRequired { get; }

        /// <summary>
        /// Gets the tapped observable.
        /// </summary>
        IObservable<Unit> Tapped { get; }
    }
}