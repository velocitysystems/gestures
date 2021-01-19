// <copyright file="PlatformPinchRecognizer_Tests.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using FluentAssertions;
using System;
using System.Reactive.Linq;
using Xunit;

namespace Velocity.Gestures.Tests
{
    /// <summary>
    /// Tests the implementation of <see cref="PlatformPinchRecognizer{TView}"/>.
    /// </summary>
    public class PlatformPinchRecognizer_Tests
    {
        /// <summary>
        /// Tests that the method throws if a pinch is already in progress.
        /// </summary>
        [Fact]
        public void OnPinchingBegan_throws_if_pinch_already_in_progress()
        {
            var recognizer = new PlatformPinchRecognizerStub(new object());
            recognizer.OnPinchingBegan(0, 0);

            Assert.Throws<InvalidOperationException>(() => recognizer.OnPinchingBegan(0, 0));
        }

        /// <summary>
        /// Tests that the method throws if a pinch is not in progress.
        /// </summary>
        [Fact]
        public void OnPinchingScaleChanged_throws_if_pinch_not_in_progress()
        {
            var recognizer = new PlatformPinchRecognizerStub(new object());
            Assert.Throws<InvalidOperationException>(() => recognizer.OnPinchingScaleChanged(1.5));
        }

        /// <summary>
        /// Tests that the method throws if a pinch is not in progress.
        /// </summary>
        [Fact]
        public void OnPinchingStateChanged_throws_if_pinch_not_in_progress()
        {
            var recognizer = new PlatformPinchRecognizerStub(new object());
            Assert.Throws<InvalidOperationException>(() => recognizer.OnPinchingStateChanged(GestureState.Ended));
        }

        /// <summary>
        /// Tests that the property is true when a pinch begins.
        /// </summary>
        [Fact]
        public void PinchInProgress_is_true_when_pinch_begins()
        {
            var recognizer = new PlatformPinchRecognizerStub(new object());
            recognizer.OnPinchingBegan(0, 0);
            recognizer.PinchInProgress.Should().BeTrue("since the pinch has begun");
        }

        /// <summary>
        /// Tests that the property is false when the pinch state is changed.
        /// </summary>
        /// <param name="state">The gesture state.</param>
        [Theory]
        [InlineData(GestureState.Ended)]
        [InlineData(GestureState.Cancelled)]
        [InlineData(GestureState.Failed)]
        public void PinchInProgress_is_false_when_pinch_state_changed(GestureState state)
        {
            var recognizer = new PlatformPinchRecognizerStub(new object());
            recognizer.OnPinchingBegan(0, 0);
            recognizer.OnPinchingStateChanged(state);
            recognizer.PinchInProgress.Should().BeFalse("since the pinch state changed");
        }

        /// <summary>
        /// Tests that the observable emits when the method is invoked.
        /// </summary>
        [Fact]
        public void Pinching_emits_when_OnPinchingBegan_invoked()
        {
            var recognizer = new PlatformPinchRecognizerStub(new object());
            var pinch = default(PinchEvent);
            recognizer.Pinching.Take(1).Subscribe(ev => pinch = ev);

            recognizer.OnPinchingBegan(1, 2);
            pinch.State.Should().Be(GestureState.Began, "because pinching began");
            pinch.Origin.X.Should().Be(1);
            pinch.Origin.Y.Should().Be(2);
        }

        /// <summary>
        /// Tests that the observable emits when the method is invoked.
        /// </summary>
        [Fact]
        public void Pinching_emits_when_OnPinchingScaleChanged_invoked()
        {
            var recognizer = new PlatformPinchRecognizerStub(new object());
            var pinch = default(PinchEvent);
            recognizer.Pinching.Skip(1).Take(1).Subscribe(ev => pinch = ev);

            recognizer.OnPinchingBegan(0, 0);
            recognizer.OnPinchingScaleChanged(1.5);
            pinch.State.Should().Be(GestureState.Changed, "because pinching scale changed");
            pinch.Scale.Should().Be(1.5);
        }

        /// <summary>
        /// Tests that the observable emits when the method is invoked.
        /// </summary>
        [Fact]
        public void Pinching_emits_when_OnPinchingStateChanged_invoked()
        {
            var recognizer = new PlatformPinchRecognizerStub(new object());
            var pinch = default(PinchEvent);
            recognizer.Pinching.Skip(1).Take(1).Subscribe(ev => pinch = ev);

            recognizer.OnPinchingBegan(0, 0);
            recognizer.OnPinchingStateChanged(GestureState.Ended);
            pinch.State.Should().Be(GestureState.Ended, "because pinching state changed");
        }

        private class PlatformPinchRecognizerStub : PlatformPinchRecognizer<object>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PlatformPinchRecognizerStub"/> class.
            /// </summary>
            /// <param name="view">The view.</param>
            public PlatformPinchRecognizerStub(object view) : base(view)
            {
            }

            /// <inheritdoc />
            public override void Dispose() => throw new NotImplementedException();

            /// <summary>
            /// Simulate when pinching began.
            /// </summary>
            /// <param name="x">The X-coordinate.</param>
            /// <param name="y">The Y-coordinate.</param>
            public new void OnPinchingBegan(double x, double y) => base.OnPinchingBegan(x, y);

            /// <summary>
            /// Simulate when pinching scale has changed.
            /// </summary>
            /// <param name="scale">The pinch scale.</param>
            public new void OnPinchingScaleChanged(double scale) => base.OnPinchingScaleChanged(scale);

            /// <summary>
            /// Simulate when pinching state has changed.
            /// </summary>
            /// <param name="state">The gesture state.</param>
            public new void OnPinchingStateChanged(GestureState state) => base.OnPinchingStateChanged(state);
        }
    }
}