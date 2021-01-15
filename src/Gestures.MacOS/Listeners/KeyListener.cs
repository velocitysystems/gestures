// <copyright file="KeyListener.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using AppKit;
using Velocity.Gestures.MacOs;

namespace Velocity.Gestures.MacOS
{
    /// <summary>
    /// A key interaction listener.
    /// </summary>
    public class KeyListener : PlatformKeyListener<NSView>
    {
        private readonly NSView _keyTrackingView;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyListener"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        public KeyListener(NSView view) : base(view)
        {
            _keyTrackingView = new KeyTrackingView(this);
            view.AddSubview(_keyTrackingView);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            _keyTrackingView.RemoveFromSuperview();
        }

        private class KeyTrackingView : NSView
        {
            private readonly KeyListener _listener;

            public KeyTrackingView(KeyListener listener)
            {
                _listener = listener;
            }

            public override bool AcceptsFirstResponder() => true;

            public override void KeyDown(NSEvent theEvent) => _listener.OnKeyDown(theEvent.ToKey());

            public override void KeyUp(NSEvent theEvent) => _listener.OnKeyUp(theEvent.ToKey());
        }
    }
}