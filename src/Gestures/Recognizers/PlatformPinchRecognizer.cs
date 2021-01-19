// <copyright file="PlatformPinchRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Velocity.Gestures
{
    /// <summary>
    /// A multi-touch pinch gesture recognizer.
    /// </summary>
    /// <typeparam name="TView">The native view.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class PlatformPinchRecognizer<TView> : PlatformRecognizer<TView>, IPinchRecognizer<TView> where TView : class
    {
        private readonly Subject<PinchEvent> _pinchingSubject;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformPinchRecognizer{TView}"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        protected PlatformPinchRecognizer(TView view) : base(view, 2)
        {
            _pinchingSubject = new Subject<PinchEvent>();
            Pinching = _pinchingSubject.AsObservable();
        }

        /// <inheritdoc/>
        public IObservable<PinchEvent> Pinching { get; }

        /// <summary>
        /// Gets a value indicating whether a pinch is in progress.
        /// This may be used for testing purposes or on platforms which do not have an inbuilt pinch gesture recognizer.
        /// </summary>
        internal bool PinchInProgress { get; private set; }

        /// <summary>
        /// Call when pinching began.
        /// </summary>
        /// <param name="x">The X-coordinate.</param>
        /// <param name="y">The Y-coordinate.</param>
        protected void OnPinchingBegan(double x, double y)
        {
            if (PinchInProgress)
            {
                throw new InvalidOperationException($"You must call {nameof(OnPinchingStateChanged)} before calling {nameof(OnPinchingBegan)}.");
            }

            _pinchingSubject.OnNext(new PinchEvent(x, y));
            PinchInProgress = true;
        }

        /// <summary>
        /// Call when pinching scale has changed.
        /// </summary>
        /// <param name="scale">The pinch scale.</param>
        protected void OnPinchingScaleChanged(double scale)
        {
            if (!PinchInProgress)
            {
                throw new InvalidOperationException($"You must call {nameof(OnPinchingBegan)} before calling {nameof(OnPinchingScaleChanged)}.");
            }

            _pinchingSubject.OnNext(new PinchEvent(scale));
        }

        /// <summary>
        /// Call when pinching state has changed.
        /// </summary>
        /// <param name="state">The gesture state.</param>
        protected void OnPinchingStateChanged(GestureState state)
        {
            if (!PinchInProgress)
            {
                throw new InvalidOperationException($"You must call {nameof(OnPinchingBegan)} before calling {nameof(OnPinchingStateChanged)}.");
            }

            _pinchingSubject.OnNext(new PinchEvent(state));
            switch (state)
            {
                case GestureState.Ended:
                case GestureState.Cancelled:
                case GestureState.Failed:
                    PinchInProgress = false;
                    break;
            }
        }
    }
}