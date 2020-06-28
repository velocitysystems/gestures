// <copyright file="RecognizerPlatformEffect.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

[assembly: Xamarin.Forms.ResolutionGroupName("Velocity")]
[assembly: Xamarin.Forms.ExportEffect(
    typeof(Velocity.Gestures.Forms.MacOS.RecognizerPlatformEffect),
    nameof(Velocity.Gestures.Forms.RecognizerEffect))]

namespace Velocity.Gestures.Forms.MacOS
{
    using System;
    using System.Reactive.Disposables;
    using Velocity.Gestures;
    using Velocity.Gestures.MacOS;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.MacOS;
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

        /// <summary>
        /// Initialize the platform effect.
        /// </summary>
        internal static void Init()
        {
            // Force Xamarin.macOS linker to preserve the effect.
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