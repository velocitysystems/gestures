// <copyright file="PlatformPanRecognizer_Tests.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using FluentAssertions;
using System;
using System.Reactive.Linq;
using Xunit;

namespace Velocity.Gestures.Tests
{
    /// <summary>
    /// Tests the implementation of <see cref="PlatformPanRecognizer{TView}"/>.
    /// </summary>
    public class PlatformPanRecognizer_Tests
    {
        /// <summary>
        /// Tests that the method throws if a pan is already in progress.
        /// </summary>
        [Fact]
        public void OnPanningBegan_throws_if_pan_already_in_progress()
        {
            var recognizer = new PlatformPanRecognizerStub(new object());
            recognizer.OnPanningBegan(0, 0);

            Assert.Throws<InvalidOperationException>(() => recognizer.OnPanningBegan(0, 0));
        }

        /// <summary>
        /// Tests that the method throws if a pan is already in progress.
        /// </summary>
        [Fact]
        public void OnPanningStateChanged_throws_if_pan_already_in_progress()
        {
            var recognizer = new PlatformPanRecognizerStub(new object());
            recognizer.OnPanningStateChanged(GestureState.Began);

            Assert.Throws<InvalidOperationException>(() => recognizer.OnPanningStateChanged(GestureState.Began));
        }

        /// <summary>
        /// Tests that the method throws if a pan is not in progress.
        /// </summary>
        [Fact]
        public void OnPanningStateChanged_throws_if_pan_not_in_progress()
        {
            var recognizer = new PlatformPanRecognizerStub(new object());
            Assert.Throws<InvalidOperationException>(() => recognizer.OnPanningStateChanged(GestureState.Ended));
        }

        /// <summary>
        /// Tests that the method throws if a pan is not in progress.
        /// </summary>
        [Fact]
        public void OnPanningDeltaChanged_throws_if_pan_not_in_progress()
        {
            var recognizer = new PlatformPanRecognizerStub(new object());
            Assert.Throws<InvalidOperationException>(() => recognizer.OnPanningDeltaChanged(100, 100));
        }

        /// <summary>
        /// Tests that the property is true when a pan begins.
        /// </summary>
        [Fact]
        public void PanInProgress_is_true_when_pan_begins()
        {
            var recognizer = new PlatformPanRecognizerStub(new object());
            recognizer.OnPanningStateChanged(GestureState.Began);
            recognizer.PanInProgress.Should().BeTrue("since the pan has begun");
        }

        /// <summary>
        /// Tests that the property is false when the pan state is changed.
        /// </summary>
        /// <param name="state">The gesture state.</param>
        [Theory]
        [InlineData(GestureState.Ended)]
        [InlineData(GestureState.Cancelled)]
        [InlineData(GestureState.Failed)]
        public void PanInProgress_is_false_when_pan_state_changed(GestureState state)
        {
            var recognizer = new PlatformPanRecognizerStub(new object());
            recognizer.OnPanningStateChanged(GestureState.Began);
            recognizer.OnPanningStateChanged(state);
            recognizer.PanInProgress.Should().BeFalse("since the pan state changed");
        }

        /// <summary>
        /// Tests that the observable emits when the method is invoked.
        /// </summary>
        [Fact]
        public void Panning_emits_when_OnPanningBegan_invoked()
        {
            var recognizer = new PlatformPanRecognizerStub(new object());
            var pan = default(PanEvent);
            recognizer.Panning.Take(1).Subscribe(ev => pan = ev);

            recognizer.OnPanningBegan(0, 0);
            pan.State.Should().Be(GestureState.Began, "because panning began");
        }

        /// <summary>
        /// Tests that the observable emits when the method is invoked.
        /// </summary>
        [Fact]
        public void Panning_emits_when_OnPanningStateChanged_invoked()
        {
            var recognizer = new PlatformPanRecognizerStub(new object());
            var pan = default(PanEvent);
            recognizer.Panning.Skip(1).Take(1).Subscribe(ev => pan = ev);

            recognizer.OnPanningStateChanged(GestureState.Began);
            recognizer.OnPanningStateChanged(GestureState.Ended);
            pan.State.Should().Be(GestureState.Ended, "because panning state changed");
        }

        /// <summary>
        /// Tests that the observable emits when the method is invoked.
        /// </summary>
        [Fact]
        public void Panning_emits_when_OnPanningDeltaChanged_invoked()
        {
            var recognizer = new PlatformPanRecognizerStub(new object());
            var pan = default(PanEvent);
            recognizer.Panning.Skip(1).Take(1).Subscribe(ev => pan = ev);

            recognizer.OnPanningStateChanged(GestureState.Began);
            recognizer.OnPanningDeltaChanged(100, 200);
            pan.State.Should().Be(GestureState.Changed, "because panning delta changed");
            pan.TotalX.Should().Be(100);
            pan.TotalY.Should().Be(200);
        }

        /// <summary>
        /// Tests that the observable emits when the method is invoked.
        /// </summary>
        [Fact]
        public void Panning_emits_when_OnPanningPositionChanged_invoked()
        {
            var recognizer = new PlatformPanRecognizerStub(new object());
            var pan = default(PanEvent);
            recognizer.Panning.Skip(1).Take(1).Subscribe(ev => pan = ev);

            recognizer.OnPanningBegan(0, 0);
            recognizer.OnPanningPositionChanged(100, 200);
            pan.State.Should().Be(GestureState.Changed, "because panning position changed");
            pan.TotalX.Should().Be(100);
            pan.TotalY.Should().Be(200);
        }

        private class PlatformPanRecognizerStub : PlatformPanRecognizer<object>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PlatformPanRecognizerStub"/> class.
            /// </summary>
            /// <param name="view">The view.</param>
            public PlatformPanRecognizerStub(object view) : base(view)
            {
            }

            /// <inheritdoc />
            public override void Dispose() => throw new NotImplementedException();

            /// <summary>
            /// Simulate when panning began.
            /// </summary>
            /// <param name="x">The X-coordinate.</param>
            /// <param name="y">The Y-coordinate.</param>
            public new void OnPanningBegan(double x, double y) => base.OnPanningBegan(x, y);

            /// <summary>
            /// Simulate when panning state has changed.
            /// </summary>
            /// <param name="state">The gesture state.</param>
            public new void OnPanningStateChanged(GestureState state) => base.OnPanningStateChanged(state);

            /// <summary>
            /// Simulate when panning delta has changed.
            /// </summary>
            /// <param name="totalX">The translation along the X-axis.</param>
            /// <param name="totalY">The translation along the Y-axis.</param>
            public new void OnPanningDeltaChanged(double totalX, double totalY) => base.OnPanningDeltaChanged(totalX, totalY);

            /// <summary>
            /// Simulate when panning position has changed.
            /// </summary>
            /// <param name="x">The X-coordinate.</param>
            /// <param name="y">The Y-coordinate.</param>
            public new void OnPanningPositionChanged(double x, double y) => base.OnPanningPositionChanged(x, y);
        }
    }
}