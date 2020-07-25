// <copyright file="Platform.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

[assembly: Xamarin.Forms.ResolutionGroupName("Velocity")]

namespace Velocity.Gestures.Forms.UWP
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