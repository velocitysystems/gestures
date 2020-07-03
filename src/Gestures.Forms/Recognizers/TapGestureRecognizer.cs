// <copyright file="TapGestureRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms
{
    /// <summary>
    /// A multi-touch tap gesture recognizer.
    /// </summary>
    public class TapGestureRecognizer : GestureRecognizer
    {
        /// <summary>
        /// The tapped event handler.
        /// </summary>
        public event EventHandler<TapEventArgs> Tapped;

        /// <summary>
        /// The bindable number of taps required property.
        /// </summary>
        public static readonly BindableProperty NumberOfTapsRequiredProperty = BindableProperty.Create(
            nameof(NumberOfTapsRequired),
            typeof(int),
            typeof(TapGestureRecognizer),
            1);

        /// <summary>
        /// Gets or sets the number of taps required.
        /// </summary>
        public int NumberOfTapsRequired
        {
            get { return (int)GetValue(NumberOfTapsRequiredProperty); }
            set { SetValue(NumberOfTapsRequiredProperty, value); }
        }

        /// <summary>
        /// Invoke the tapped event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        internal void InvokeTapped(View sender)
        {
            Tapped?.Invoke(sender, new TapEventArgs(NumberOfTouchesRequired, NumberOfTapsRequired));
            if (Command is ICommand cmd && cmd.CanExecute(CommandParameter))
            {
                cmd.Execute(CommandParameter);
            }
        }
    }
}