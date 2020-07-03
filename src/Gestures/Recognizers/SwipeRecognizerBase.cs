// <copyright file="SwipeRecognizerBase.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Velocity.Gestures
{
    /// <summary>
    /// A multi-touch swipe gesture recognizer.
    /// </summary>
    /// <typeparam name="TView">The native view.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class SwipeRecognizerBase<TView> : RecognizerBase<TView>, ISwipeRecognizer<TView> where TView : class
    {
        private readonly Subject<SwipeDirection> _swipedSubject;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwipeRecognizerBase{TView}"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        /// <param name="directionMask">The direction mask.</param>
        /// <param name="numberOfTouchesRequired">The number of touches required.</param>
        protected SwipeRecognizerBase(TView view, SwipeDirection directionMask, int numberOfTouchesRequired) : base(view, numberOfTouchesRequired)
        {
            DirectionMask = directionMask;

            _swipedSubject = new Subject<SwipeDirection>();
            Swiped = _swipedSubject.AsObservable();
        }

        /// <inheritdoc/>
        public SwipeDirection DirectionMask { get; }

        /// <inheritdoc/>
        public IObservable<SwipeDirection> Swiped { get; }

        /// <summary>
        /// Call when swiped.
        /// </summary>
        /// <param name="direction">The direction.</param>
        protected void OnSwiped(SwipeDirection direction) => _swipedSubject.OnNext(direction);
    }
}