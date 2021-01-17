// <copyright file="SwipeGestureRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms
{
    /// <summary>
    /// A multi-touch swipe gesture recognizer.
    /// </summary>
    public class SwipeGestureRecognizer : GestureRecognizer
    {
        /// <summary>
        /// The swiped event handler.
        /// </summary>
        public event EventHandler<SwipeEventArgs> Swiped;

        /// <summary>
        /// The bindable swipe direction mask property.
        /// </summary>
        public static readonly BindableProperty DirectionMaskProperty = BindableProperty.Create(
            nameof(DirectionMask),
            typeof(SwipeDirection),
            typeof(SwipeGestureRecognizer),
            SwipeDirection.Any);

        /// <summary>
        /// Gets the swipe direction mask.
        /// </summary>
        public SwipeDirection DirectionMask
        {
            get { return (SwipeDirection)GetValue(DirectionMaskProperty); }
            set { SetValue(DirectionMaskProperty, value); }
        }

        /// <summary>
        /// Invoke the swiped event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="direction">The swipe direction.</param>
        internal void InvokeSwiped(View sender, SwipeDirection direction)
        {
            Swiped?.Invoke(sender, new SwipeEventArgs(direction));
            if (Command is ICommand cmd && cmd.CanExecute(CommandParameter))
            {
                cmd.Execute(CommandParameter);
            }
        }
    }
}