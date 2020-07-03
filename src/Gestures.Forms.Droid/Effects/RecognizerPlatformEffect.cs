// <copyright file="RecognizerPlatformEffect.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

[assembly: Xamarin.Forms.ResolutionGroupName("Velocity")]
[assembly: Xamarin.Forms.ExportEffect(
    typeof(Velocity.Gestures.Forms.Droid.RecognizerPlatformEffect),
    nameof(Velocity.Gestures.Forms.RecognizerEffect))]

namespace Velocity.Gestures.Forms.Droid
{
    using System;
    using System.Reactive.Disposables;
    using Android.Content;
    using Velocity.Gestures;
    using Velocity.Gestures.Droid;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    using VLongPressGestureRecognizer = Velocity.Gestures.Forms.LongPressGestureRecognizer;
    using VPanGestureRecognizer = Velocity.Gestures.Forms.PanGestureRecognizer;
    using VPinchGestureRecognizer = Velocity.Gestures.Forms.PinchGestureRecognizer;
    using VSwipeGestureRecognizer = Velocity.Gestures.Forms.SwipeGestureRecognizer;
    using VTapGestureRecognizer = Velocity.Gestures.Forms.TapGestureRecognizer;

    /// <summary>
    /// Platform implementation for <see cref="RecognizerEffect"/>.
    /// </summary>
    public class RecognizerPlatformEffect : PlatformEffect
    {
        private CompositeDisposable _disposable;
        private Context Context => Android.App.Application.Context;

        /// <summary>
        /// Initialize the platform effect.
        /// </summary>
        internal static void Init()
        {
            // Force Xamarin.iOS linker to preserve the effect.
            // https://bugzilla.xamarin.com/show_bug.cgi?id=31076
            _ = typeof(RecognizerPlatformEffect);
        }

        /// <inheritdoc/>
        protected override void OnAttached()
        {
            if (!(Element is View view))
            {
                return;
            }

            _disposable = new CompositeDisposable();

            foreach (var recognizer in view.GestureRecognizers)
            {
                switch (recognizer)
                {
                    case VTapGestureRecognizer formsTapRecognizer:
                        var tapRecognizer = new TapRecognizer(Context, Container, formsTapRecognizer.NumberOfTapsRequired, formsTapRecognizer.NumberOfTouchesRequired);
                        tapRecognizer.Tapped.Subscribe(e => formsTapRecognizer.InvokeTapped(view)).DisposeWith(_disposable);
                        tapRecognizer.TouchesBegan.Subscribe(point => formsTapRecognizer.InvokeTouchesBegan(view, point)).DisposeWith(_disposable);
                        tapRecognizer.TouchesEnded.Subscribe(point => formsTapRecognizer.InvokeTouchesEnded(view, point)).DisposeWith(_disposable);
                        _disposable.Add(tapRecognizer);
                        break;

                    case VLongPressGestureRecognizer formsLongPressRecognizer:
                        var longPressRecognizer = new LongPressRecognizer(Context, Container, formsLongPressRecognizer.NumberOfTouchesRequired);
                        longPressRecognizer.LongPressed.Subscribe(e => formsLongPressRecognizer.InvokeLongPressed(view)).DisposeWith(_disposable);
                        longPressRecognizer.TouchesBegan.Subscribe(point => formsLongPressRecognizer.InvokeTouchesBegan(view, point)).DisposeWith(_disposable);
                        longPressRecognizer.TouchesEnded.Subscribe(point => formsLongPressRecognizer.InvokeTouchesEnded(view, point)).DisposeWith(_disposable);
                        _disposable.Add(longPressRecognizer);
                        break;
                }                             
            }
        }

        /// <inheritdoc/>
        protected override void OnDetached()
        {
            _disposable?.Dispose();
        }
    }
}