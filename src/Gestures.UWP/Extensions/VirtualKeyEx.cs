// <copyright file="VirtualKeyEx.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using Windows.System;

namespace Velocity.Gestures.UWP
{
    /// <summary>
    /// Extensions for <see cref="VirtualKey"/>.
    /// </summary>
    public static class VirtualKeyEx
    {
        /// <summary>
        /// Convert to a <see cref="Key"/>.
        /// </summary>
        /// <param name="key">The <see cref="VirtualKey"/>.</param>
        /// <returns>The <see cref="Key"/>.</returns>
        public static Key ToKey(this VirtualKey key) => (Key)key;
    }
}