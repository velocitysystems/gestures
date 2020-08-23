// <copyright file="IViewAttachment.cs" company="Velocity Systems">
//     Copyright (c) 2020 Vsselocity Systems
// </copyright>

using System;

namespace Velocity.Gestures
{
    /// <summary>
    /// A platform view attachment.
    /// </summary>
    /// <typeparam name="TView">The native view.</typeparam>
    public interface IViewAttachment<TView> : IDisposable where TView : class
    {
        /// <summary>
        /// Gets the view.
        /// </summary>
        TView View { get; }
    }
}