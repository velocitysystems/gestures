// <copyright file="PlatformSwipeRecognizer.cs" company="Velocity Systems">
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
    public abstract class PlatformSwipeRecognizer<TView> : PlatformRecognizer<TView>, ISwipeRecognizer<TView> where TView : class
    {
        private readonly Subject<SwipeDirection> _swipedSubject;
        private double? _startX;
        private double? _startY;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformSwipeRecognizer{TView}"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        /// <param name="directionMask">The direction mask.</param>
        /// <param name="numberOfTouchesRequired">The number of touches required.</param>
        /// <param name="threshold">Optional default threshold in pixels before a swipe is detected.</param>
        protected PlatformSwipeRecognizer(TView view, SwipeDirection directionMask, int numberOfTouchesRequired, int threshold = Defaults.Threshold) : base(view, numberOfTouchesRequired)
        {
            DirectionMask = directionMask;
            Threshold = threshold;

            _swipedSubject = new Subject<SwipeDirection>();
            Swiped = _swipedSubject.AsObservable();
        }

        /// <inheritdoc/>
        public SwipeDirection DirectionMask { get; }

        /// <inheritdoc/>
        public IObservable<SwipeDirection> Swiped { get; }

        /// <summary>
        /// Gets the threshold in pixels before a swipe is detected.
        /// This is only used by platforms which do not have an inbuilt swipe gesture recognizer.
        /// </summary>
        private double Threshold { get; }

        /// <summary>
        /// Call when the swipe began.
        /// </summary>
        /// <param name="x">The X-coordinate.</param>
        /// <param name="y">The Y-coordinate.</param>
        protected void OnSwipeBegan(double x, double y)
        {
            _startX = x;
            _startY = y;
        }

        /// <summary>
        /// Call when the swipe was cancelled or failed.
        /// </summary>
        protected void OnSwipeCancelled()
        {
            _startX = null;
            _startY = null;
        }

        /// <summary>
        /// Call when the swipe ended.
        /// </summary>
        /// <param name="x">The X-coordinate.</param>
        /// <param name="y">The Y-coordinate.</param>
        /// <returns>True if a swipe was detected, else false.</returns>
        protected bool OnSwipeEnded(double x, double y)
        {
            if (_startX is null || _startY is null)
            {
                throw new InvalidOperationException($"You must call {nameof(OnSwipeBegan)} before calling {nameof(OnSwipeEnded)}.");
            }

            var dX = x - _startX;
            var dY = y - _startY;

            if (DirectionMask.HasFlag(SwipeDirection.Left) && dX < -Threshold)
            {
                OnSwiped(SwipeDirection.Left);
                return true;
            }
            else if (DirectionMask.HasFlag(SwipeDirection.Right) && dX > Threshold)
            {
                OnSwiped(SwipeDirection.Right);
                return true;
            }
            else if (DirectionMask.HasFlag(SwipeDirection.Up) && dY < -Threshold)
            {
                OnSwiped(SwipeDirection.Up);
                return true;
            }
            else if (DirectionMask.HasFlag(SwipeDirection.Down) && dY > Threshold)
            {
                OnSwiped(SwipeDirection.Down);
                return true;
            }

            _startX = null;
            _startY = null;
            return false;
        }

        /// <summary>
        /// Call when swiped.
        /// </summary>
        /// <param name="direction">The direction.</param>
        protected void OnSwiped(SwipeDirection direction) => _swipedSubject.OnNext(direction);
    }
}