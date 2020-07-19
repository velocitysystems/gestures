// <copyright file="HoverRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using AppKit;
using CoreGraphics;

namespace Velocity.Gestures.MacOS
{
    /// <summary>
    /// A multi-touch hover gesture recognizer.
    /// </summary>
    public class HoverRecognizer : PlatformHoverRecognizer<NSView>
    {
        private readonly NSView _mouseTrackingView;

        /// <summary>
        /// Initializes a new instance of the <see cref="HoverRecognizer"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        public HoverRecognizer(NSView view) : base(view)
        {
            _mouseTrackingView = new MouseTrackingView(this, view.Frame);
            view.AddSubview(_mouseTrackingView);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            _mouseTrackingView.RemoveFromSuperview();
        }

        private class MouseTrackingView : NSView
        {
            private readonly HoverRecognizer _recognizer;
            private readonly CGRect _frame;

            public MouseTrackingView(HoverRecognizer recognizer, CGRect frame)
            {
                _recognizer = recognizer;

                // When intializing the tracking view, we support two scenarios:
                // 1. The parent view has not been measured.
                // 2. The parent view has been measured.
                if (frame.IsEmpty)
                {
                    AutoresizingMask = NSViewResizingMask.WidthSizable | NSViewResizingMask.HeightSizable;
                }
                else
                {
                    Frame = frame;
                    InitializeTrackingArea();
                }
            }

            public override void ViewWillDraw()
            {
                base.ViewWillDraw();

                if (_frame.IsEmpty)
                {
                    InitializeTrackingArea();
                }
            }

            public override void MouseEntered(NSEvent theEvent)
            {
                var point = ConvertPointFromView(theEvent.LocationInWindow, this);

                _recognizer.OnTouchesBegan(point.X, point.Y);
                _recognizer.OnHoveringStateChanged(GestureState.Began);
            }

            public override void MouseExited(NSEvent theEvent)
            {
                var point = ConvertPointFromView(theEvent.LocationInWindow, this);

                _recognizer.OnHoveringStateChanged(GestureState.Ended);
                _recognizer.OnTouchesEnded(point.X, point.Y);
            }

            private void InitializeTrackingArea()
            {
                var area = new NSTrackingArea(Frame, NSTrackingAreaOptions.ActiveInKeyWindow | NSTrackingAreaOptions.MouseEnteredAndExited, this, null);
                AddTrackingArea(area);
            }
        }
    }
}