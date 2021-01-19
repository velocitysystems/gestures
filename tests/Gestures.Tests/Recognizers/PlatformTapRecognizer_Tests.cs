// <copyright file="PlatformTapRecognizer_Tests.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using FluentAssertions;
using System;
using System.Reactive.Linq;
using Xunit;

namespace Velocity.Gestures.Tests
{
    /// <summary>
    /// Tests the implementation of <see cref="PlatformTapRecognizer{TView}"/>.
    /// </summary>
    public class PlatformTapRecognizer_Tests
    {
        /// <summary>
        /// Tests that the constructor throws an <see cref="ArgumentException"/> when the number of taps is invalid.
        /// </summary>
        /// <param name="numberOfTapsRequired">The number of taps required.</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(3)]
        public void Ctor_throws_exception_when_number_of_taps_is_invalid(int numberOfTapsRequired)
        {
            Assert.Throws<ArgumentException>(() => new PlatformTapRecognizerStub(new object(), numberOfTapsRequired, 1));
        }

        /// <summary>
        /// Tests that the constructor sets the property when the number of taps are valid.
        /// </summary>
        /// <param name="numberOfTapsRequired">The number of taps required.</param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Ctor_sets_NumberOfTapsRequired_property_when_number_of_taps_is_valid(int numberOfTapsRequired)
        {
            Assert.Equal(numberOfTapsRequired, new PlatformTapRecognizerStub(new object(), numberOfTapsRequired, 1).NumberOfTapsRequired);
        }

        /// <summary>
        /// Tests that the observable emits when the method is invoked.
        /// </summary>
        [Fact]
        public void Tapped_emits_when_method_invoked()
        {
            var recognizer = new PlatformTapRecognizerStub(new object(), 1, 1);
            var tapped = false;
            recognizer.Tapped.Take(1).Subscribe(_ => tapped = true);

            recognizer.OnTapped();
            tapped.Should().BeTrue("because a tap occurred");
        }

        private class PlatformTapRecognizerStub : PlatformTapRecognizer<object>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PlatformTapRecognizerStub"/> class.
            /// </summary>
            /// <param name="view">The view.</param>
            /// <param name="numberOfTapsRequired">The number of taps required.</param>
            /// <param name="numberOfTouchesRequired">The number of touches required.</param>
            public PlatformTapRecognizerStub(object view, int numberOfTapsRequired, int numberOfTouchesRequired) : base(view, numberOfTapsRequired, numberOfTouchesRequired)
            {
            }

            /// <inheritdoc />
            public override void Dispose() => throw new NotImplementedException();

            /// <summary>
            /// Simulate a tapped event.
            /// </summary>
            public new void OnTapped() => base.OnTapped();
        }
    }
}