// <copyright file="RecognizerPlatformEffect.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

[assembly: Xamarin.Forms.ResolutionGroupName("Velocity")]
[assembly: Xamarin.Forms.ExportEffect(
    typeof(Velocity.Gestures.Forms.UWP.RecognizerPlatformEffect),
    nameof(Velocity.Gestures.Forms.RecognizerEffect))]

namespace Velocity.Gestures.Forms.UWP
{
    using System;
    using System.Reactive.Disposables;
    using Velocity.Gestures;
    using Velocity.Gestures.UWP;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.UWP;
    using VLongPressGestureRecognizer = Velocity.Gestures.Forms.LongPressGestureRecognizer;
    using VTapGestureRecognizer = Velocity.Gestures.Forms.TapGestureRecognizer;

    /// <summary>
    /// Platform implementation for <see cref="RecognizerEffect"/>.
    /// </summary>
    public class RecognizerPlatformEffect : PlatformEffect
    {
        private CompositeDisposable _disposable;

        /// <summary>
        /// Initialize the platform effect.
        /// </summary>
        internal static void Init()
        {
            // Force .NET Native linker to preserve the effect.
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
                        var tapRecognizer = new TapRecognizer(Container, formsTapRecognizer.NumberOfTouchesRequired, formsTapRecognizer.NumberOfTapsRequired);
                        tapRecognizer.Tapped.Subscribe(e => formsTapRecognizer.InvokeTapped(view)).DisposeWith(_disposable);
                        tapRecognizer.TouchesBegan.Subscribe(point => formsTapRecognizer.InvokeTouchesBegan(view, point)).DisposeWith(_disposable);
                        tapRecognizer.TouchesEnded.Subscribe(point => formsTapRecognizer.InvokeTouchesEnded(view, point)).DisposeWith(_disposable);
                        _disposable.Add(tapRecognizer);
                        break;

                    case VLongPressGestureRecognizer formsLongPressRecognizer:
                        var longPressRecognizer = new LongPressRecognizer(Container, formsLongPressRecognizer.NumberOfTouchesRequired);
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