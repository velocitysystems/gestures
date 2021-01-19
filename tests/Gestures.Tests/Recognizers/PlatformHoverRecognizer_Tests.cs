// <copyright file="PlatformHoverRecognizer_Tests.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using FluentAssertions;
using System;
using System.Reactive.Linq;
using Xunit;

namespace Velocity.Gestures.Tests
{
    /// <summary>
    /// Tests the implementation of <see cref="PlatformHoverRecognizer{TView}{TView}"/>.
    /// </summary>
    public class PlatformHoverRecognizer_Tests
    {
        /// <summary>
        /// Tests that the observable emits when the method is invoked.
        /// </summary>
        [Fact]
        public void Hovering_emits_when_method_invoked()
        {
            var recognizer = new PlatformHoverRecognizerStub(new object());
            var hovering = false;
            recognizer.Hovering.Take(1).Subscribe(_ => hovering = true);

            recognizer.OnHoveringStateChanged(GestureState.Began);
            hovering.Should().BeTrue("because hovering occurred");
        }

        private class PlatformHoverRecognizerStub : PlatformHoverRecognizer<object>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PlatformHoverRecognizerStub"/> class.
            /// </summary>
            /// <param name="view">The view.</param>
            public PlatformHoverRecognizerStub(object view) : base(view)
            {
            }

            /// <inheritdoc />
            public override void Dispose() => throw new NotImplementedException();

            /// <summary>
            /// Simulate when hovering state has changed.
            /// </summary>
            /// <param name="state">The gesture state.</param>
            public new void OnHoveringStateChanged(GestureState state) => base.OnHoveringStateChanged(state);
        }
    }
}