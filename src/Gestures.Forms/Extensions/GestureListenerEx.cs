// <copyright file="GestureListenerEx.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.Reactive.Disposables;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms
{
    /// <summary>
    /// Extensions for <see cref="IPlatformListener{TView}{TView}"/>.
    /// </summary>
    public static class GestureListenerEx
    {
        /// <summary>
        /// Bind the <see cref="IKeyListener{TView}{TView}"/> to the <see cref="KeyGestureListener"/>.
        /// </summary>
        /// <typeparam name="TView">The native view.</typeparam>
        /// <param name="nativeListener">The native listener.</param>
        /// <param name="formsListener">The XF listener.</param>
        /// <param name="sender">The XF view.</param>
        /// <param name="disposable">The disposable used to clean up subscriptions.</param>
        /// <returns>The native key listener.</returns>
        public static IKeyListener<TView> Bind<TView>(
            this IKeyListener<TView> nativeListener,
            KeyGestureListener formsListener,
            View sender,
            CompositeDisposable disposable) where TView : class
        {
            nativeListener.Pressed.Subscribe(keys => formsListener.InvokePressed(sender, keys)).DisposeWith(disposable);
            nativeListener.KeyDown.Subscribe(key => formsListener.InvokeKeyDown(sender, key)).DisposeWith(disposable);
            nativeListener.KeyUp.Subscribe(key => formsListener.InvokeKeyUp(sender, key)).DisposeWith(disposable);

            return nativeListener;
        }
    }
}