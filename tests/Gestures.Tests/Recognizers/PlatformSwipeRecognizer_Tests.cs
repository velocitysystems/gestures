// <copyright file="PlatformSwipeRecognizer_Tests.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using FluentAssertions;
using System;
using System.Reactive.Linq;
using Xunit;

namespace Velocity.Gestures.Tests
{
    /// <summary>
    /// Tests the implementation of <see cref="PlatformSwipeRecognizer{TView}"/>.
    /// </summary>
    public class PlatformSwipeRecognizer_Tests
    {
        /// <summary>
        /// Tests that the constructor sets the property.
        /// </summary>
        [Fact]
        public void Ctor_sets_DirectionMask_property()
        {
            var mask = SwipeDirection.Left;
            Assert.Equal(mask, new PlatformSwipeRecognizerStub(new object(), mask, 1).DirectionMask);
        }

        /// <summary>
        /// Tests that the constructor throws an <see cref="ArgumentException"/> when the threshold is invalid.
        /// </summary>
        /// <param name="threshold">The threshold in pixels before a swipe is detected.</param>
        [Theory]
        [InlineData(-100)]
        [InlineData(0)]
        [InlineData(99)]
        public void Ctor_throws_exception_when_threshold_is_invalid(int threshold)
        {
            Assert.Throws<ArgumentException>(() => new PlatformSwipeRecognizerStub(new object(), SwipeDirection.Any, 1, threshold));
        }

        /// <summary>
        /// Tests that the method throws if a swipe is already in progress.
        /// </summary>
        [Fact]
        public void OnSwipeBegan_throws_if_swipe_already_in_progress()
        {
            var recognizer = new PlatformSwipeRecognizerStub(new object(), SwipeDirection.Any, 1);
            recognizer.OnSwipeBegan(0, 0);

            Assert.Throws<InvalidOperationException>(() => recognizer.OnSwipeBegan(0, 0));
        }

        /// <summary>
        /// Tests that the method throws if a swipe is not in progress.
        /// </summary>
        [Fact]
        public void OnSwipeEnded_throws_if_swipe_not_in_progress()
        {
            var recognizer = new PlatformSwipeRecognizerStub(new object(), SwipeDirection.Any, 1);
            Assert.Throws<InvalidOperationException>(() => recognizer.OnSwipeEnded(0, 0));
        }

        /// <summary>
        /// Tests that the method detects a swipe when it matches the direction mask and threshold.
        /// </summary>
        /// <param name="x1">The starting X-position.</param>
        /// <param name="y1">The starting Y-position.</param>
        /// <param name="x2">The ending X-position.</param>
        /// <param name="y2">The ending Y-position.</param>
        /// <param name="expected">The expected swipe direction.</param>
        [Theory]
        [InlineData(0, 0, -101, 0, SwipeDirection.Left)]
        [InlineData(0, 0, 101, 0, SwipeDirection.Right)]
        [InlineData(0, 0, 0, -101, SwipeDirection.Up)]
        [InlineData(0, 0, 0, 101, SwipeDirection.Down)]
        public void OnSwipeEnded_detects_swipe_when_matches_direction_mask_and_threshold(int x1, int y1, int x2, int y2, SwipeDirection expected)
        {
            var recognizer = new PlatformSwipeRecognizerStub(new object(), SwipeDirection.Any, 1);
            var swiped = default(SwipeDirection?);
            recognizer.Swiped.Take(1).Subscribe(direction => swiped = direction);

            recognizer.OnSwipeBegan(x1, y1);
            recognizer.OnSwipeEnded(x2, y2).Should().BeTrue("because a swipe was detected");
            swiped.Should().Be(expected, $"because a swipe {swiped} occurred");
        }

        /// <summary>
        /// Tests that the method ignores a swipe when it does not match the direction mask.
        /// </summary>
        /// <param name="x1">The starting X-position.</param>
        /// <param name="y1">The starting Y-position.</param>
        /// <param name="x2">The ending X-position.</param>
        /// <param name="y2">The ending Y-position.</param>
        /// <param name="directionMask">The swipe direction mask.</param>
        [Theory]
        [InlineData(0, 0, -99, 0, SwipeDirection.Right)]
        [InlineData(0, 0, 99, 0, SwipeDirection.Left)]
        [InlineData(0, 0, 0, -99, SwipeDirection.Down)]
        [InlineData(0, 0, 0, 99, SwipeDirection.Up)]
        public void OnSwipeEnded_ignores_swipe_when_does_not_match_direction_mask(int x1, int y1, int x2, int y2, SwipeDirection directionMask)
        {
            var recognizer = new PlatformSwipeRecognizerStub(new object(), directionMask, 1);
            recognizer.OnSwipeBegan(x1, y1);
            recognizer.OnSwipeEnded(x2, y2).Should().BeFalse("because no swipe was detected");
        }

        /// <summary>
        /// Tests that the method ignores a swipe when it does not exceed the threshold.
        /// </summary>
        /// <param name="x1">The starting X-position.</param>
        /// <param name="y1">The starting Y-position.</param>
        /// <param name="x2">The ending X-position.</param>
        /// <param name="y2">The ending Y-position.</param>
        [Theory]
        [InlineData(0, 0, -99, 0)]
        [InlineData(0, 0, 99, 0)]
        [InlineData(0, 0, 0, -99)]
        [InlineData(0, 0, 0, 99)]
        public void OnSwipeEnded_ignores_swipe_when_does_not_exceed_threshold(int x1, int y1, int x2, int y2)
        {
            var recognizer = new PlatformSwipeRecognizerStub(new object(), SwipeDirection.Any, 1);
            recognizer.OnSwipeBegan(x1, y1);
            recognizer.OnSwipeEnded(x2, y2).Should().BeFalse("because no swipe was detected");
        }

        /// <summary>
        /// Tests that the method throws if a swipe is not in progress.
        /// </summary>
        [Fact]
        public void OnSwipeCancelled_throws_if_swipe_not_in_progress()
        {
            var recognizer = new PlatformSwipeRecognizerStub(new object(), SwipeDirection.Any, 1);
            Assert.Throws<InvalidOperationException>(() => recognizer.OnSwipeCancelled());
        }

        /// <summary>
        /// Tests that the property is true when a swipe begins.
        /// </summary>
        [Fact]
        public void SwipeInProgress_is_true_when_swipe_begins()
        {
            var recognizer = new PlatformSwipeRecognizerStub(new object(), SwipeDirection.Any, 1);
            recognizer.OnSwipeBegan(0, 0);
            recognizer.SwipeInProgress.Should().BeTrue("since the swipe has begun");
        }

        /// <summary>
        /// Tests that the property is false when a swipe ends.
        /// </summary>
        [Fact]
        public void SwipeInProgress_is_false_when_swipe_ends()
        {
            var recognizer = new PlatformSwipeRecognizerStub(new object(), SwipeDirection.Any, 1);
            recognizer.OnSwipeBegan(0, 0);
            recognizer.OnSwipeEnded(1, 1);
            recognizer.SwipeInProgress.Should().BeFalse("since the swipe has ended");
        }

        /// <summary>
        /// Tests that the property is false when a swipe is cancelled.
        /// </summary>
        [Fact]
        public void SwipeInProgress_is_false_when_swipe_cancelled()
        {
            var recognizer = new PlatformSwipeRecognizerStub(new object(), SwipeDirection.Any, 1);
            recognizer.OnSwipeBegan(0, 0);
            recognizer.OnSwipeCancelled();
            recognizer.SwipeInProgress.Should().BeFalse("since the swipe has been cancelled");
        }

        /// <summary>
        /// Tests that the observable emits when the method is invoked.
        /// </summary>
        [Fact]
        public void Swiped_emits_when_method_invoked()
        {
            var recognizer = new PlatformSwipeRecognizerStub(new object(), SwipeDirection.Any, 1);
            var swiped = default(SwipeDirection?);
            recognizer.Swiped.Take(1).Subscribe(direction => swiped = direction);

            recognizer.OnSwiped(SwipeDirection.Left).Should().BeTrue("because a swipe was detected");
            swiped.Should().Be(SwipeDirection.Left, "because a swipe left occurred");
        }

        /// <summary>
        /// Tests that the observable does not emit if the swipe does not match the direction mask.
        /// </summary>
        [Fact]
        public void Swiped_does_not_emit_if_swipe_does_not_match_direction_mask()
        {
            var recognizer = new PlatformSwipeRecognizerStub(new object(), SwipeDirection.Right, 1);
            var swiped = default(SwipeDirection?);
            recognizer.Swiped.Take(1).Subscribe(direction => swiped = direction);

            recognizer.OnSwiped(SwipeDirection.Left).Should().BeFalse("because no swipe was detected");
            swiped.Should().Be(default, "because the swiped event did not fire");
        }

        private class PlatformSwipeRecognizerStub : PlatformSwipeRecognizer<object>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PlatformSwipeRecognizerStub"/> class.
            /// </summary>
            /// <param name="view">The view.</param>
            /// <param name="directionMask">The swipe direction mask.</param>
            /// <param name="numberOfTouchesRequired">The number of touches required.</param>
            /// <param name="threshold">Optional threshold in pixels before a swipe is detected.</param>
            public PlatformSwipeRecognizerStub(object view, SwipeDirection directionMask, int numberOfTouchesRequired, int threshold = Defaults.Threshold) : base(view, directionMask, numberOfTouchesRequired, threshold)
            {
            }

            /// <inheritdoc />
            public override void Dispose() => throw new NotImplementedException();

            /// <summary>
            /// Simulate when the swipe began.
            /// </summary>
            /// <param name="x">The X-coordinate.</param>
            /// <param name="y">The Y-coordinate.</param>
            public new void OnSwipeBegan(double x, double y) => base.OnSwipeBegan(x, y);

            /// <summary>
            /// Simulate when the swipe ended.
            /// </summary>
            /// <param name="x">The X-coordinate.</param>
            /// <param name="y">The Y-coordinate.</param>
            /// <returns>True if a valid swipe was detected, else false.</returns>
            public new bool OnSwipeEnded(double x, double y) => base.OnSwipeEnded(x, y);

            /// <summary>
            /// Simulate when the swipe was cancelled or failed.
            /// </summary>
            public new void OnSwipeCancelled() => base.OnSwipeCancelled();

            /// <summary>
            /// Simulate a swiped event.
            /// </summary>
            /// <returns>True if a valid swipe was detected, else false.</returns>
            public new bool OnSwiped(SwipeDirection direction) => base.OnSwiped(direction);
        }
    }
}