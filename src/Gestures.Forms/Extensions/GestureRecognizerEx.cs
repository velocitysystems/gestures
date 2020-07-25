// <copyright file="GestureRecognizerEx.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.Reactive.Disposables;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms
{
    /// <summary>
    /// Extensions for <see cref="IPlatformRecognizer{TView}"/>.
    /// </summary>
    public static class GestureRecognizerEx
    {
        /// <summary>
        /// Bind the <see cref="ITapRecognizer{TView}"/> to the <see cref="TapGestureRecognizer"/>.
        /// </summary>
        /// <typeparam name="TView">The native view.</typeparam>
        /// <param name="nativeRecognizer">The native recognizer.</param>
        /// <param name="formsRecognizer">The XF recognizer.</param>
        /// <param name="sender">The XF view.</param>
        /// <param name="disposable">The disposable used to clean up subscriptions.</param>
        /// <returns>The native tap recognizer.</returns>
        public static ITapRecognizer<TView> Bind<TView>(
            this ITapRecognizer<TView> nativeRecognizer,
            TapGestureRecognizer formsRecognizer,
            View sender,
            CompositeDisposable disposable) where TView : class
        {
            nativeRecognizer.Tapped.Subscribe(e => formsRecognizer.InvokeTapped(sender)).DisposeWith(disposable);
            nativeRecognizer.TouchesBegan.Subscribe(point => formsRecognizer.InvokeTouchesBegan(sender, point)).DisposeWith(disposable);
            nativeRecognizer.TouchesEnded.Subscribe(point => formsRecognizer.InvokeTouchesEnded(sender, point)).DisposeWith(disposable);

            return nativeRecognizer;
        }

        /// <summary>
        /// Bind the <see cref="ILongPressRecognizer{TView}{TView}"/> to the <see cref="LongPressGestureRecognizer"/>.
        /// </summary>
        /// <typeparam name="TView">The native view.</typeparam>
        /// <param name="nativeRecognizer">The native recognizer.</param>
        /// <param name="formsRecognizer">The XF recognizer.</param>
        /// <param name="sender">The XF view.</param>
        /// <param name="disposable">The disposable used to clean up subscriptions.</param>
        /// <returns>The native long-press recognizer.</returns>
        public static ILongPressRecognizer<TView> Bind<TView>(
            this ILongPressRecognizer<TView> nativeRecognizer,
            LongPressGestureRecognizer formsRecognizer,
            View sender,
            CompositeDisposable disposable) where TView : class
        {
            nativeRecognizer.LongPressed.Subscribe(e => formsRecognizer.InvokeLongPressed(sender)).DisposeWith(disposable);
            nativeRecognizer.TouchesBegan.Subscribe(point => formsRecognizer.InvokeTouchesBegan(sender, point)).DisposeWith(disposable);
            nativeRecognizer.TouchesEnded.Subscribe(point => formsRecognizer.InvokeTouchesEnded(sender, point)).DisposeWith(disposable);

            return nativeRecognizer;
        }

        /// <summary>
        /// Bind the <see cref="ISwipeRecognizer{TView}{TView}"/> to the <see cref="SwipeGestureRecognizer"/>.
        /// </summary>
        /// <typeparam name="TView">The native view.</typeparam>
        /// <param name="nativeRecognizer">The native recognizer.</param>
        /// <param name="formsRecognizer">The XF recognizer.</param>
        /// <param name="sender">The XF view.</param>
        /// <param name="disposable">The disposable used to clean up subscriptions.</param>
        /// <returns>The native swipe recognizer.</returns>
        public static ISwipeRecognizer<TView> Bind<TView>(
            this ISwipeRecognizer<TView> nativeRecognizer,
            SwipeGestureRecognizer formsRecognizer,
            View sender,
            CompositeDisposable disposable) where TView : class
        {
            nativeRecognizer.Swiped.Subscribe(direction => formsRecognizer.InvokeSwiped(sender, direction)).DisposeWith(disposable);
            nativeRecognizer.TouchesBegan.Subscribe(point => formsRecognizer.InvokeTouchesBegan(sender, point)).DisposeWith(disposable);
            nativeRecognizer.TouchesEnded.Subscribe(point => formsRecognizer.InvokeTouchesEnded(sender, point)).DisposeWith(disposable);

            return nativeRecognizer;
        }

        /// <summary>
        /// Bind the <see cref="IPanRecognizer{TView}"/> to the <see cref="PanGestureRecognizer"/>.
        /// </summary>
        /// <typeparam name="TView">The native view.</typeparam>
        /// <param name="nativeRecognizer">The native recognizer.</param>
        /// <param name="formsRecognizer">The XF recognizer.</param>
        /// <param name="sender">The XF view.</param>
        /// <param name="disposable">The disposable used to clean up subscriptions.</param>
        /// <returns>The native pan recognizer.</returns>
        public static IPanRecognizer<TView> Bind<TView>(
            this IPanRecognizer<TView> nativeRecognizer,
            PanGestureRecognizer formsRecognizer,
            View sender,
            CompositeDisposable disposable) where TView : class
        {
            nativeRecognizer.Panning.Subscribe(e => formsRecognizer.InvokePanning(sender, e)).DisposeWith(disposable);
            nativeRecognizer.TouchesBegan.Subscribe(point => formsRecognizer.InvokeTouchesBegan(sender, point)).DisposeWith(disposable);
            nativeRecognizer.TouchesEnded.Subscribe(point => formsRecognizer.InvokeTouchesEnded(sender, point)).DisposeWith(disposable);

            return nativeRecognizer;
        }

        /// <summary>
        /// Bind the <see cref="IPinchRecognizer{TView}"/> to the <see cref="PinchGestureRecognizer"/>.
        /// </summary>
        /// <typeparam name="TView">The native view.</typeparam>
        /// <param name="nativeRecognizer">The native recognizer.</param>
        /// <param name="formsRecognizer">The XF recognizer.</param>
        /// <param name="sender">The XF view.</param>
        /// <param name="disposable">The disposable used to clean up subscriptions.</param>
        /// <returns>The native pinch recognizer.</returns>
        public static IPinchRecognizer<TView> Bind<TView>(
            this IPinchRecognizer<TView> nativeRecognizer,
            PinchGestureRecognizer formsRecognizer,
            View sender,
            CompositeDisposable disposable) where TView : class
        {
            nativeRecognizer.Pinching.Subscribe(e => formsRecognizer.InvokePinching(sender, e)).DisposeWith(disposable);
            nativeRecognizer.TouchesBegan.Subscribe(point => formsRecognizer.InvokeTouchesBegan(sender, point)).DisposeWith(disposable);
            nativeRecognizer.TouchesEnded.Subscribe(point => formsRecognizer.InvokeTouchesEnded(sender, point)).DisposeWith(disposable);

            return nativeRecognizer;
        }

        /// <summary>
        /// Bind the <see cref="IHoverRecognizer{TView}"/> to the <see cref="HoverGestureRecognizer"/>.
        /// </summary>
        /// <typeparam name="TView">The native view.</typeparam>
        /// <param name="nativeRecognizer">The native recognizer.</param>
        /// <param name="formsRecognizer">The XF recognizer.</param>
        /// <param name="sender">The XF view.</param>
        /// <param name="disposable">The disposable used to clean up subscriptions.</param>
        /// <returns>The native hover recognizer.</returns>
        public static IHoverRecognizer<TView> Bind<TView>(
            this IHoverRecognizer<TView> nativeRecognizer,
            HoverGestureRecognizer formsRecognizer,
            View sender,
            CompositeDisposable disposable) where TView : class
        {
            nativeRecognizer.Hovering.Subscribe(e => formsRecognizer.InvokeHovering(sender, e)).DisposeWith(disposable);
            nativeRecognizer.TouchesBegan.Subscribe(point => formsRecognizer.InvokeTouchesBegan(sender, point)).DisposeWith(disposable);
            nativeRecognizer.TouchesEnded.Subscribe(point => formsRecognizer.InvokeTouchesEnded(sender, point)).DisposeWith(disposable);

            return nativeRecognizer;
        }
    }
}