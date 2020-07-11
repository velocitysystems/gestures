// <copyright file="PlatformPanRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Velocity.Gestures
{
    /// <summary>
    /// A multi-touch pan gesture recognizer.
    /// </summary>
    /// <typeparam name="TView">The native view.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class PlatformPanRecognizer<TView> : PlatformRecognizer<TView>, IPanRecognizer<TView> where TView : class
    {
        private readonly Subject<PanEvent> _panningSubject;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformPanRecognizer{TView}"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        protected PlatformPanRecognizer(TView view) : base(view, 1)
        {
            _panningSubject = new Subject<PanEvent>();
            Panning = _panningSubject.AsObservable();
        }

        /// <inheritdoc/>
        public IObservable<PanEvent> Panning { get; }

        /// <summary>
        /// Call when panning state has changed.
        /// </summary>
        /// <param name="state">The gesture state.</param>
        protected void OnPanningStateChanged(GestureState state) => _panningSubject.OnNext(new PanEvent(state));

        /// <summary>
        /// Call when panning delta has changed.
        /// </summary>
        /// <param name="totalX">The translation along the X-axis.</param>
        /// <param name="totalY">The translation along the Y-axis.</param>
        protected void OnPanningDeltaChanged(double totalX, double totalY) => _panningSubject.OnNext(new PanEvent(totalX, totalY));
    }
}