// <copyright file="Platform.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

namespace Velocity.Gestures.Forms.iOS
{
    /// <summary>
    /// Platform support for gestures.
    /// </summary>
    public static class Platform
    {
        /// <summary>
        /// Initialize platform support for gestures.
        /// </summary>
        public static void Init()
        {
            RecognizerPlatformEffect.Init();
        }
    }
}