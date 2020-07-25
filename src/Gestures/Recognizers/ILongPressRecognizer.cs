// <copyright file="ILongPressRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.Reactive;

namespace Velocity.Gestures
{
    /// <summary>
    /// A multi-touch long-press gesture recognizer.
    /// </summary>
    /// <typeparam name="TView">The native view.</typeparam>
    public interface ILongPressRecognizer<TView> : IPlatformRecognizer<TView> where TView : class
    {
        /// <summary>
        /// Gets the long-pressed observable.
        /// </summary>
        IObservable<Unit> LongPressed { get; }
    }
}