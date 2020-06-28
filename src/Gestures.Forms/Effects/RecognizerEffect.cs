// <copyright file="RecognizerEffect.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

namespace Velocity.Gestures.Forms
{
    using Xamarin.Forms;

    /// <summary>
    /// <see cref="RoutingEffect"/> that provides platform support for recognizers.
    /// </summary>
    public class RecognizerEffect : RoutingEffect
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizerEffect"/> class.
        /// </summary>
        public RecognizerEffect() : base("Velocity.RecognizerEffect")
        {
        }
    }
}