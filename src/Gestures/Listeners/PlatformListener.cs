// <copyright file="PlatformListener.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.ComponentModel;

namespace Velocity.Gestures
{
    /// <summary>
    /// An interaction listener.
    /// </summary>
    /// <typeparam name="TView">The native view.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class PlatformListener<TView> : IPlatformListener<TView> where TView : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformListener{TView}"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        protected PlatformListener(TView view)
        {
            View = view ?? throw new ArgumentNullException(nameof(view));
        }

        /// <inheritdoc/>
        public TView View { get; }

        /// <inheritdoc/>
        public abstract void Dispose();
    }
}