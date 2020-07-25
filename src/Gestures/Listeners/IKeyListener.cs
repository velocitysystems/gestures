// <copyright file="IKeyListener.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;

namespace Velocity.Gestures
{
    /// <summary>
    /// A key interaction listener.
    /// </summary>
    /// <typeparam name="TView">The native view.</typeparam>
    public interface IKeyListener<TView> : IViewAttachment<TView> where TView : class
    {
        /// <summary>
        /// Gets the key(s) pressed observable.
        /// </summary>
        IObservable<Key[]> Pressed { get; }

        /// <summary>
        /// Gets the key down observable.
        /// </summary>
        IObservable<Key> KeyDown { get; }

        /// <summary>
        /// Gets the key up observable.
        /// </summary>
        IObservable<Key> KeyUp { get; }
    }
}