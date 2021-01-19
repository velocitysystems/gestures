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
        /// Call when pinching began.
        /// </summary>
        /// <param name="x">The X-coordinate.</param>
        /// <param name="y">The Y-coordinate.</param>
        protected void OnPinchingBegan(double x, double y) => _pinchingSubject.OnNext(new PinchEvent(x, y));

        /// <summary>
        /// Call when pinching scale has changed.
        /// </summary>
        /// <param name="scale">The pinch scale.</param>
        protected void OnPinchingScaleChanged(double scale) => _pinchingSubject.OnNext(new PinchEvent(scale));

        /// <summary>
        /// Call when pinching state has changed.
        /// </summary>
        /// <param name="state">The gesture state.</param>
        protected void OnPinchingStateChanged(GestureState state) => _pinchingSubject.OnNext(new PinchEvent(state));
    }
}