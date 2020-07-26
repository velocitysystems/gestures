// <copyright file="PlatformListener_Tests.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using Xunit;

namespace Velocity.Gestures.Tests
{
    /// <summary>
    /// Tests the implementation of <see cref="IPlatformListener{TView}"/>.
    /// </summary>
    public class PlatformListener_Tests
    {
        /// <summary>
        /// Tests that the constructor throws an <see cref="ArgumentNullException"/> when the view is null.
        /// </summary>
        [Fact]
        public void Ctor_throws_exception_when_view_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new PlatformListenerStub(default));
        }

        /// <summary>
        /// Tests that the constructor sets the property when the view is valid.
        /// </summary>
        [Fact]
        public void Ctor_sets_View_property_when_view_is_valid()
        {
            var view = new object();
            Assert.Same(view, new PlatformListenerStub(view).View);
        }

        private class PlatformListenerStub : PlatformListener<object>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PlatformListenerStub"/> class.
            /// </summary>
            /// <param name="view">The view.</param>
            public PlatformListenerStub(object view) : base(view)
            {
            }

            /// <inheritdoc />
            public override void Dispose() => throw new NotImplementedException();
        }
    }
}