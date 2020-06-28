// <copyright file="DisposableExtensions.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.Reactive.Disposables;

namespace Velocity.Gestures
{
    /// <summary>
    /// Extensions for <see cref="IDisposable"/>.
    /// </summary>
    public static class DisposableExtensions
    {
        /// <summary>
        /// Register the <see cref="IDisposable"/> for disposable with the <see cref="CompositeDisposable"/>.
        /// </summary>
        /// <param name="disposable">The object to dispose.</param>
        /// <param name="compositeDisposable">The <see cref="CompositeDisposable"/>.</param>
        public static void DisposeWith(this IDisposable disposable, CompositeDisposable compositeDisposable)
        {
            compositeDisposable.Add(disposable);
        }
    }
}