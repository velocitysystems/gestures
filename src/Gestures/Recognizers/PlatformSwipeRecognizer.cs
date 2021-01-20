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
        private Point _start;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformSwipeRecognizer{TView}"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        /// <param name="directionMask">The direction mask.</param>
        /// <param name="numberOfTouchesRequired">The number of touches required.</param>
        /// <param name="threshold">Optional threshold in pixels before a swipe is detected.</param>
        protected PlatformSwipeRecognizer(TView view, SwipeDirection directionMask, int numberOfTouchesRequired, int threshold = Defaults.Threshold) : base(view, numberOfTouchesRequired)
        {
            if (threshold < Defaults.Threshold)
            {
                throw new ArgumentException(nameof(numberOfTouchesRequired), $"Threshold must be greater than {Defaults.Threshold}.");
            }

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
        /// Gets a value indicating whether a swipe is in progress.
        /// This may be used for testing purposes or on platforms which do not have an inbuilt swipe gesture recognizer.
        /// </summary>
        internal bool SwipeInProgress => _start is Point;

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
            if (SwipeInProgress)
            {
                throw new InvalidOperationException($"You must call {nameof(OnSwipeCancelled)} or {nameof(OnSwipeEnded)} before calling {nameof(OnSwipeBegan)}.");
            }

            _start = new Point(x, y);
        }

        /// <summary>
        /// Call when the swipe ended.
        /// </summary>
        /// <param name="x">The X-coordinate.</param>
        /// <param name="y">The Y-coordinate.</param>
        /// <returns>True if a valid swipe was detected, else false.</returns>
        protected bool OnSwipeEnded(double x, double y)
        {
            if (!SwipeInProgress)
            {
                throw new InvalidOperationException($"You must call {nameof(OnSwipeBegan)} before calling {nameof(OnSwipeEnded)}.");
            }

            var dX = x - _start.X;
            var dY = y - _start.Y;

            if (DirectionMask.HasFlag(SwipeDirection.Left) && dX <= -Threshold)
            {
                return HandleSwipe(SwipeDirection.Left);
            }
            else if (DirectionMask.HasFlag(SwipeDirection.Right) && dX >= Threshold)
            {
                return HandleSwipe(SwipeDirection.Right);
            }
            else if (DirectionMask.HasFlag(SwipeDirection.Up) && dY <= -Threshold)
            {
                return HandleSwipe(SwipeDirection.Up);
            }
            else if (DirectionMask.HasFlag(SwipeDirection.Down) && dY >= Threshold)
            {
                return HandleSwipe(SwipeDirection.Down);
            }

            return HandleSwipe();

            bool HandleSwipe(SwipeDirection? direction = default)
            {
                if (direction.HasValue)
                {
                    OnSwiped(direction.Value);
                }

                _start = default;
                return direction.HasValue;
            }
        }

        /// <summary>
        /// Call when the swipe was cancelled or failed.
        /// </summary>
        protected void OnSwipeCancelled()
        {
            if (!SwipeInProgress)
            {
                throw new InvalidOperationException($"You must call {nameof(OnSwipeBegan)} before calling {nameof(OnSwipeCancelled)}.");
            }

            _start = default;
        }

        /// <summary>
        /// Call when swiped.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns>True if a valid swipe was detected, else false.</returns>
        protected bool OnSwiped(SwipeDirection direction)
        {
            if (DirectionMask.HasFlag(direction))
            {
                _swipedSubject.OnNext(direction);
                return true;
            }

            return false;
        }
    }
}