// <copyright file="PlatformLongPressRecognizer_Tests.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using FluentAssertions;
using System;
using System.Reactive.Linq;
using Xunit;

namespace Velocity.Gestures.Tests
{
    /// <summary>
    /// Tests the implementation of <see cref="PlatformLongPressRecognizer{TView}"/>.
    /// </summary>
    public class PlatformLongPressRecognizer_Tests
    {
        /// <summary>
        /// Tests that the observable emits when the method is invoked.
        /// </summary>
        [Fact]
        public void LongPressed_emits_when_method_invoked()
        {
            var recognizer = new PlatformLongPressRecognizerStub(new object(), 1);
            var longPressed = false;
            recognizer.LongPressed.Take(1).Subscribe(_ => longPressed = true);

            recognizer.OnLongPressed();
            longPressed.Should().BeTrue("because a long-press occurred");
        }

        private class PlatformLongPressRecognizerStub : PlatformLongPressRecognizer<object>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PlatformLongPressRecognizerStub"/> class.
            /// </summary>
            /// <param name="view">The view.</param>
            /// <param name="numberOfTouchesRequired">The number of touches required.</param>
            public PlatformLongPressRecognizerStub(object view, int numberOfTouchesRequired) : base(view, numberOfTouchesRequired)
            {
            }

            /// <inheritdoc />
            public override void Dispose() => throw new NotImplementedException();

            /// <summary>
            /// Simulate a long-pressed event.
            /// </summary>
            public new void OnLongPressed() => base.OnLongPressed();
        }
    }
}