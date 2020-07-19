// <copyright file="RecognizerPlatformEffect.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

[assembly: Xamarin.Forms.ResolutionGroupName("Velocity")]
[assembly: Xamarin.Forms.ExportEffect(
    typeof(Velocity.Gestures.Forms.Droid.RecognizerPlatformEffect),
    nameof(Velocity.Gestures.Forms.RecognizerEffect))]

namespace Velocity.Gestures.Forms.Droid
{
    using System.Reactive.Disposables;
    using Android.Content;
    using Velocity.Gestures.Droid;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    using FormsHoverGestureRecognizer = Velocity.Gestures.Forms.HoverGestureRecognizer;
    using FormsLongPressGestureRecognizer = Velocity.Gestures.Forms.LongPressGestureRecognizer;
    using FormsPanGestureRecognizer = Velocity.Gestures.Forms.PanGestureRecognizer;
    using FormsPinchGestureRecognizer = Velocity.Gestures.Forms.PinchGestureRecognizer;
    using FormsSwipeGestureRecognizer = Velocity.Gestures.Forms.SwipeGestureRecognizer;
    using FormsTapGestureRecognizer = Velocity.Gestures.Forms.TapGestureRecognizer;

    /// <summary>
    /// Platform implementation for <see cref="RecognizerEffect"/>.
    /// </summary>
    public class RecognizerPlatformEffect : PlatformEffect
    {
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

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

            foreach (var recognizer in view.GestureRecognizers)
            {
                switch (recognizer)
                {
                    case FormsTapGestureRecognizer tap:
                        _disposable.Add(new TapRecognizer(Context, Container, tap.NumberOfTapsRequired, tap.NumberOfTouchesRequired).Bind(tap, view, _disposable));
                        break;

                    case FormsLongPressGestureRecognizer longPress:
                        _disposable.Add(new LongPressRecognizer(Context, Container, longPress.NumberOfTouchesRequired).Bind(longPress, view, _disposable));
                        break;

                    case FormsHoverGestureRecognizer hover:
                        _disposable.Add(new HoverRecognizer(Context, Container).Bind(hover, view, _disposable));
                        break;
                }
            }
        }

        /// <inheritdoc/>
        protected override void OnDetached() => _disposable?.Dispose();
    }
}