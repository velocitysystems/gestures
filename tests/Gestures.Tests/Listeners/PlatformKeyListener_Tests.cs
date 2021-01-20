// <copyright file="PlatformKeyListener_Tests.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using FluentAssertions;
using System;
using System.Linq;
using System.Reactive.Linq;
using Xunit;

namespace Velocity.Gestures.Tests
{
    /// <summary>
    /// Tests the implementation of <see cref="PlatformKeyListener{TView}"/>.
    /// </summary>
    public class PlatformKeyListener_Tests
    {
        /// <summary>
        /// Tests that the property is true when a key-down occurs.
        /// </summary>
        [Fact]
        public void KeySequenceInProgress_is_true_when_KeyDown_occurs()
        {
            var recognizer = new PlatformKeyListenerStub(new object());
            recognizer.OnKeyDown(Key.A);
            recognizer.KeySequenceInProgress.Should().BeTrue("since key sequence in progress");
        }

        /// <summary>
        /// Tests that the property is false when a key-down and corresponding key-up occurs.
        /// </summary>
        [Fact]
        public void KeySequenceInProgress_is_false_when_KeyDown_and_KeyUp_occurs()
        {
            var recognizer = new PlatformKeyListenerStub(new object());
            recognizer.OnKeyDown(Key.A);
            recognizer.OnKeyUp(Key.A);
            recognizer.KeySequenceInProgress.Should().BeFalse("since key sequence has ended");
        }

        /// <summary>
        /// Tests that the observable emits when a key is pressed.
        /// </summary>
        [Fact]
        public void Pressed_emits_when_a_key_is_pressed()
        {
            var recognizer = new PlatformKeyListenerStub(new object());
            var newKey = default(Key?);
            recognizer.Pressed.Take(1).Subscribe(keys => newKey = keys.First());

            recognizer.OnKeyDown(Key.A);
            newKey.Should().Be(Key.A, $"because {Key.A} was pressed");
        }

        /// <summary>
        /// Tests that the observable emits when multiple keys are pressed.
        /// </summary>
        [Fact]
        public void Pressed_emits_when_multiple_keys_are_pressed()
        {
            var recognizer = new PlatformKeyListenerStub(new object());
            var newKeys = default(Key[]);
            recognizer.Pressed.Skip(2).Take(1).Subscribe(keys => newKeys = keys);

            recognizer.OnKeyDown(Key.A);
            recognizer.OnKeyDown(Key.B);
            recognizer.OnKeyDown(Key.C);
            newKeys[0].Should().Be(Key.A, $"because {Key.A} was pressed");
            newKeys[1].Should().Be(Key.B, $"because {Key.B} was pressed");
            newKeys[2].Should().Be(Key.C, $"because {Key.C} was pressed");
        }

        /// <summary>
        /// Tests that the observable emits when the method is invoked.
        /// </summary>
        [Fact]
        public void KeyDown_emits_when_method_invoked()
        {
            var recognizer = new PlatformKeyListenerStub(new object());
            var keyDown = false;
            recognizer.KeyDown.Take(1).Subscribe(_ => keyDown = true);

            recognizer.OnKeyDown(Key.A);
            keyDown.Should().BeTrue("because a key-down occurred");
        }

        /// <summary>
        /// Tests that the observable emits when the method is invoked.
        /// </summary>
        [Fact]
        public void KeyUp_emits_when_method_invoked()
        {
            var recognizer = new PlatformKeyListenerStub(new object());
            var keyUp = false;
            recognizer.KeyUp.Take(1).Subscribe(_ => keyUp = true);

            recognizer.OnKeyDown(Key.A);
            recognizer.OnKeyUp(Key.A);
            keyUp.Should().BeTrue("because a key-up occurred");
        }

        /// <summary>
        /// Tests that the method throws if a key sequence is not in progress.
        /// </summary>
        [Fact]
        public void OnKeyUp_throws_if_key_sequence_not_in_progress()
        {
            var recognizer = new PlatformKeyListenerStub(new object());
            Assert.Throws<InvalidOperationException>(() => recognizer.OnKeyUp(Key.A));
        }

        private class PlatformKeyListenerStub : PlatformKeyListener<object>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PlatformKeyListenerStub"/> class.
            /// </summary>
            /// <param name="view">The view.</param>
            public PlatformKeyListenerStub(object view) : base(view)
            {
            }

            /// <inheritdoc />
            public override void Dispose() => throw new NotImplementedException();

            /// <summary>
            /// Simulate when key down received.
            /// </summary>
            /// <param name="key">The key.</param>
            public new void OnKeyDown(Key key) => base.OnKeyDown(key);

            /// <summary>
            /// Simulate when key up received.
            /// </summary>
            /// <param name="key">The key.</param>
            public new void OnKeyUp(Key key) => base.OnKeyUp(key);
        }
    }
}