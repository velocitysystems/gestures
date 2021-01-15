// <copyright file="ListenerPlatformEffect.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

[assembly: Xamarin.Forms.ExportEffect(
    typeof(Velocity.Gestures.Forms.WPF.ListenerPlatformEffect),
    nameof(Velocity.Gestures.Forms.ListenerEffect))]

namespace Velocity.Gestures.Forms.WPF
{
    using System.Reactive.Disposables;
    using Velocity.Gestures.WPF;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.WPF;
    using FormsKeyGestureListener = Velocity.Gestures.Forms.KeyGestureListener;

    /// <summary>
    /// Platform implementation for <see cref="ListenerEffect"/>.
    /// </summary>
    public class ListenerPlatformEffect : PlatformEffect
    {
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

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

            foreach (var recognizer in view.GestureRecognizers)
            {
                switch (recognizer)
                {
                    case FormsKeyGestureListener key:
                        _disposable.Add(new KeyListener(Control).Bind(key, view, _disposable));
                        break;
                }
            }
        }

        /// <inheritdoc/>
        protected override void OnDetached() => _disposable?.Dispose();
    }
}