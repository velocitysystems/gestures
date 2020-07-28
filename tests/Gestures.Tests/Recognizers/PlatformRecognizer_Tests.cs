// <copyright file="PlatformRecognizer_Tests.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using FluentAssertions;
using System;
using System.Reactive.Linq;
using Xunit;

namespace Velocity.Gestures.Tests
{
    /// <summary>
    /// Tests the implementation of <see cref="IPlatformRecognizer{TView}{TView}"/>.
    /// </summary>
    public class PlatformRecognizer_Tests
    {
        /// <summary>
        /// Tests that the constructor throws an <see cref="ArgumentNullException"/> when the view is null.
        /// </summary>
        [Fact]
        public void Ctor_throws_exception_when_view_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new PlatformRecognizerStub(default, 1));
        }

        /// <summary>
        /// Tests that the constructor throws an <see cref="ArgumentException"/> when the number of touches is invalid.
        /// </summary>
        /// <param name="numberOfTouchesRequired">The number of touches required.</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(5)]
        public void Ctor_throws_exception_when_number_of_touches_is_invalid(int numberOfTouchesRequired)
        {
            Assert.Throws<ArgumentException>(() => new PlatformRecognizerStub(new object(), numberOfTouchesRequired));
        }

        /// <summary>
        /// Tests that the constructor sets the property when the view is valid.
        /// </summary>
        [Fact]
        public void Ctor_sets_View_property_when_view_is_valid()
        {
            var view = new object();
            Assert.Same(view, new PlatformRecognizerStub(view, 1).View);
        }

        /// <summary>
        /// Tests that the constructor sets the property when the number of touches are valid.
        /// </summary>
        /// <param name="numberOfTouchesRequired">The number of touches required.</param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Ctor_sets_NumberOfTouches_property_when_number_of_touches_is_valid(int numberOfTouchesRequired)
        {
            Assert.Equal(numberOfTouchesRequired, new PlatformRecognizerStub(new object(), numberOfTouchesRequired).NumberOfTouchesRequired);
        }

        /// <summary>
        /// Tests that the observable emits when the method is invoked.
        /// </summary>
        [Fact]
        public void TouchesBegan_emits_when_method_invoked()
        {
            var recognizer = new PlatformRecognizerStub(new object(), 1);
            var newPoint = default(Point);
            recognizer.TouchesBegan.Take(1).Subscribe(point => newPoint = point);

            recognizer.OnTouchesBegan(4, 8);
            newPoint.X.Should().Be(4, "because this was the point on the X-axis");
            newPoint.Y.Should().Be(8, "because this was the point on the Y-axis");
        }

        /// <summary>
        /// Tests that the observable emits when the method is invoked.
        /// </summary>
        [Fact]
        public void TouchesEnded_emits_when_method_invoked()
        {
            var recognizer = new PlatformRecognizerStub(new object(), 1);
            var newPoint = default(Point);
            recognizer.TouchesEnded.Take(1).Subscribe(point => newPoint = point);

            recognizer.OnTouchesEnded(4, 8);
            newPoint.X.Should().Be(4, "because this was the point on the X-axis");
            newPoint.Y.Should().Be(8, "because this was the point on the Y-axis");
        }

        private class PlatformRecognizerStub : PlatformRecognizer<object>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PlatformRecognizerStub"/> class.
            /// </summary>
            /// <param name="view">The view.</param>
            /// <param name="numberOfTouchesRequired">The number of touches required.</param>
            public PlatformRecognizerStub(object view, int numberOfTouchesRequired) : base(view, numberOfTouchesRequired)
            {
            }

            /// <inheritdoc />
            public override void Dispose() => throw new NotImplementedException();
        }
    }
}