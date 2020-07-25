// <copyright file="IPlatformListener.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;

namespace Velocity.Gestures
{
    /// <summary>
    /// An interaction listener.
    /// </summary>
    /// <typeparam name="TView">The native view.</typeparam>
    public interface IPlatformListener<TView> : IViewAttachment<TView> where TView : class
    {
    }
}