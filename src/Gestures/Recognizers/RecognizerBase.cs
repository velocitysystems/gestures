// <copyright file="RecognizerBase.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Velocity.Gestures
{
    /// <summary>
    /// A multi-touch gesture recognizer.
    /// </summary>
    /// <typeparam name="TView">The native view.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class RecognizerBase<TView> : IRecognizer<TView> where TView : class
    {
        private readonly ISubject<Point> _touchesBeganSubject;
        private readonly ISubject<Point> _touchesEndedSubject;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizerBase{TView}"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        /// <param name="numberOfTouchesRequired">The number of touches required.</param>
        protected RecognizerBase(TView view, int numberOfTouchesRequired)
        {
            View = view ?? throw new ArgumentNullException(nameof(view));
            NumberOfTouchesRequired = numberOfTouchesRequired;

            _touchesBeganSubject = new Subject<Point>();
            TouchesBegan = _touchesBeganSubject.AsObservable();

            _touchesEndedSubject = new Subject<Point>();            
            TouchesEnded = _touchesEndedSubject.AsObservable();
        }

        /// <inheritdoc/>
        public TView View { get; }

        /// <inheritdoc/>
        public int NumberOfTouchesRequired { get; }

        /// <inheritdoc/>
        public IObservable<Point> TouchesBegan { get; }

        /// <inheritdoc/>
        public IObservable<Point> TouchesEnded { get; }

        /// <inheritdoc/>
        public abstract void Dispose();

        /// <summary>
        /// Call when touches begin.
        /// </summary>
        /// <param name="x">The X-coordinate.</param>
        /// <param name="y">The Y-coordinate.</param>
        protected void OnTouchesBegan(double x, double y) => _touchesBeganSubject.OnNext(new Point(x, y));

        /// <summary>
        /// Call when touches end.
        /// </summary>
        /// <param name="x">The X-coordinate.</param>
        /// <param name="y">The Y-coordinate.</param>
        protected void OnTouchesEnded(double x, double y) => _touchesEndedSubject.OnNext(new Point(x, y));
    }
}