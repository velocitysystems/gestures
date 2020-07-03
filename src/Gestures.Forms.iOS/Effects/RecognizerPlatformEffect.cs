// <copyright file="RecognizerPlatformEffect.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

[assembly: Xamarin.Forms.ResolutionGroupName("Velocity")]
[assembly: Xamarin.Forms.ExportEffect(
    typeof(Velocity.Gestures.Forms.iOS.RecognizerPlatformEffect),
    nameof(Velocity.Gestures.Forms.RecognizerEffect))]

namespace Velocity.Gestures.Forms.iOS
{
    using System;
    using System.Reactive.Disposables;
    using Velocity.Gestures;
    using Velocity.Gestures.iOS;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
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
                        var tapRecognizer = new TapRecognizer(Container, formsTapRecognizer.NumberOfTapsRequired, formsTapRecognizer.NumberOfTouchesRequired);
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

                    case VSwipeGestureRecognizer formsSwipeRecognizer:
                        var swipeRecognizer = new SwipeRecognizer(Container, formsSwipeRecognizer.DirectionMask, formsSwipeRecognizer.NumberOfTouchesRequired);
                        swipeRecognizer.Swiped.Subscribe(e => formsSwipeRecognizer.InvokeSwiped(view, e)).DisposeWith(_disposable);
                        swipeRecognizer.TouchesBegan.Subscribe(point => formsSwipeRecognizer.InvokeTouchesBegan(view, point)).DisposeWith(_disposable);
                        swipeRecognizer.TouchesEnded.Subscribe(point => formsSwipeRecognizer.InvokeTouchesEnded(view, point)).DisposeWith(_disposable);
                        _disposable.Add(swipeRecognizer);
                        break;

                    case VPanGestureRecognizer formsPanGestureRecognizer:
                        var panRecognizer = new PanRecognizer(Container);
                        panRecognizer.Panning.Subscribe(e => formsPanGestureRecognizer.InvokePanning(view, e)).DisposeWith(_disposable);
                        panRecognizer.TouchesBegan.Subscribe(point => formsPanGestureRecognizer.InvokeTouchesBegan(view, point)).DisposeWith(_disposable);
                        panRecognizer.TouchesEnded.Subscribe(point => formsPanGestureRecognizer.InvokeTouchesEnded(view, point)).DisposeWith(_disposable);
                        _disposable.Add(panRecognizer);
                        break;

                    case VPinchGestureRecognizer formsPinchGestureRecognizer:
                        var pinchRecognizer = new PinchRecognizer(Container);
                        pinchRecognizer.Pinching.Subscribe(e => formsPinchGestureRecognizer.InvokePinching(view, e)).DisposeWith(_disposable);
                        pinchRecognizer.TouchesBegan.Subscribe(point => formsPinchGestureRecognizer.InvokeTouchesBegan(view, point)).DisposeWith(_disposable);
                        pinchRecognizer.TouchesEnded.Subscribe(point => formsPinchGestureRecognizer.InvokeTouchesEnded(view, point)).DisposeWith(_disposable);
                        _disposable.Add(pinchRecognizer);
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