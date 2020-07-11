// <copyright file="PlatformLongPressRecognizer.cs" company="Velocity Systems">
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
    /// A multi-touch long-press gesture recognizer.
    /// </summary>
    /// <typeparam name="TView">The native view.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class PlatformLongPressRecognizer<TView> : PlatformRecognizer<TView>, ILongPressRecognizer<TView> where TView : class
    {
        private readonly Subject<Unit> _longPressedSubject;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformLongPressRecognizer{TView}"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        /// <param name="numberOfTouchesRequired">The number of touches required.</param>
        protected PlatformLongPressRecognizer(TView view, int numberOfTouchesRequired) : base(view, numberOfTouchesRequired)
        {
            _longPressedSubject = new Subject<Unit>();
            LongPressed = _longPressedSubject.AsObservable();
        }

        /// <inheritdoc/>
        public IObservable<Unit> LongPressed { get; }

        /// <summary>
        /// Call when long-pressed.
        /// </summary>
        protected void OnLongPressed() => _longPressedSubject.OnNext(Unit.Default);
    }
}