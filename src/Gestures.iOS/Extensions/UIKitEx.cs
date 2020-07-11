// <copyright file="UIKitEx.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using UIKit;

namespace Velocity.Gestures.iOS
{
    /// <summary>
    /// Extensions for <see cref="UIKit"/>.
    /// </summary>
    public static class UIKitEx
    {
        /// <summary>
        /// Convert to a <see cref="SwipeDirection"/>.
        /// </summary>
        /// <param name="direction">The <see cref="UISwipeGestureRecognizerDirection"/>.</param>
        /// <returns>The <see cref="SwipeDirection"/>.</returns>
        public static SwipeDirection ToSwipeDirection(this UISwipeGestureRecognizerDirection direction)
        {
            switch (direction)
            {
                case UISwipeGestureRecognizerDirection.Left:
                    return SwipeDirection.Left;

                case UISwipeGestureRecognizerDirection.Right:
                    return SwipeDirection.Right;

                case UISwipeGestureRecognizerDirection.Up:
                    return SwipeDirection.Up;

                case UISwipeGestureRecognizerDirection.Down:
                    return SwipeDirection.Down;

                default:
                    throw new NotImplementedException();
            }            
        }
    }
}