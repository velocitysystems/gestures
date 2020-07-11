// <copyright file="PlatformTapRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Velocity.Gestures
{
    /// <summary>
    /// A multi-touch tap gesture recognizer.
    /// </summary>
    /// <typeparam name="TView">The native view.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class PlatformTapRecognizer<TView> : PlatformRecognizer<TView>, ITapRecognizer<TView> where TView : class
    {
        private readonly Subject<Unit> _tappedSubject;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformTapRecognizer{TView}"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        /// <param name="numberOfTapsRequired">The number of taps required.</param>
        /// <param name="numberOfTouchesRequired">The number of touches required.</param>
        protected PlatformTapRecognizer(TView view, int numberOfTapsRequired, int numberOfTouchesRequired) : base(view, numberOfTouchesRequired)
        {
            NumberOfTapsRequired = numberOfTapsRequired;

            _tappedSubject = new Subject<Unit>();
            Tapped = _tappedSubject.AsObservable();
        }

        /// <inheritdoc/>
        public int NumberOfTapsRequired { get; }

        /// <inheritdoc/>
        public IObservable<Unit> Tapped { get; }

        /// <summary>
        /// Call when tapped.
        /// </summary>
        protected void OnTapped() => _tappedSubject.OnNext(Unit.Default);
    }
}