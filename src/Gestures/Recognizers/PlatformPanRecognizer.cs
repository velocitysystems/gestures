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
        private Point _start;

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
        /// Gets a value indicating whether a pan is in progress.
        /// This may be used for testing purposes or on platforms which do not have an inbuilt pan gesture recognizer.
        /// </summary>
        internal bool PanInProgress { get; private set; }

        /// <summary>
        /// Call when panning began.
        /// </summary>
        /// <param name="x">The X-coordinate.</param>
        /// <param name="y">The Y-coordinate.</param>
        protected void OnPanningBegan(double x, double y)
        {
            if (PanInProgress)
            {
                throw new InvalidOperationException($"You must call {nameof(OnPanningStateChanged)} before calling {nameof(OnPanningBegan)}.");
            }

            _start = new Point(x, y);
            _panningSubject.OnNext(new PanEvent(GestureState.Began));
            PanInProgress = true;
        }

        /// <summary>
        /// Call when panning state has changed.
        /// </summary>
        /// <param name="state">The gesture state.</param>
        protected void OnPanningStateChanged(GestureState state)
        {
            if (state == GestureState.Began)
            {
                if (PanInProgress)
                {
                    throw new InvalidOperationException($"You must call {nameof(OnPanningStateChanged)} to end the gesture.");
                }

                _panningSubject.OnNext(new PanEvent(state));
                PanInProgress = true;
                return;
            }

            if (!PanInProgress)
            {
                throw new InvalidOperationException($"You must call {nameof(OnPanningStateChanged)} to begin the gesture.");
            }

            _panningSubject.OnNext(new PanEvent(state));
            PanInProgress = false;
        }

        /// <summary>
        /// Call when panning delta has changed.
        /// </summary>
        /// <param name="totalX">The translation along the X-axis.</param>
        /// <param name="totalY">The translation along the Y-axis.</param>
        protected void OnPanningDeltaChanged(double totalX, double totalY)
        {
            if (!PanInProgress)
            {
                throw new InvalidOperationException($"You must call {nameof(OnPanningStateChanged)} before calling {nameof(OnPanningDeltaChanged)}.");
            }

            _panningSubject.OnNext(new PanEvent(totalX, totalY));
        }

        /// <summary>
        /// Call when panning position has changed.
        /// </summary>
        /// <param name="x">The X-coordinate.</param>
        /// <param name="y">The Y-coordinate.</param>
        protected void OnPanningPositionChanged(double x, double y)
        {
            if (!PanInProgress || _start is null)
            {
                throw new InvalidOperationException($"You must call {nameof(OnPanningBegan)} before calling {nameof(OnPanningPositionChanged)}.");
            }

            var totalX = x - _start.X;
            var totalY = y - _start.Y;
            _panningSubject.OnNext(new PanEvent(totalX, totalY));
        }
    }
}