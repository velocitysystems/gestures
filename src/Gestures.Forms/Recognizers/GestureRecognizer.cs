// <copyright file="GestureRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms
{
    /// <summary>
    /// A multi-touch gesture recognizer.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class GestureRecognizer : Element, IGestureRecognizer
    {
        /// <summary>
        /// The touches began event handler.
        /// </summary>
        public event EventHandler<Point> TouchesBegan;

        /// <summary>
        /// The touches ended event handler.
        /// </summary>
        public event EventHandler<Point> TouchesEnded;

        /// <summary>
        /// The bindable number of touches required property.
        /// </summary>
        public static readonly BindableProperty NumberOfTouchesRequiredProperty = BindableProperty.Create(
            nameof(NumberOfTouchesRequired),
            typeof(int),
            typeof(GestureRecognizer),
            1);

        /// <summary>
        /// The bindable command property.
        /// </summary>
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(GestureRecognizer));

        /// <summary>
        /// The bindable command parameter property.
        /// </summary>
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            nameof(CommandParameter),
            typeof(object),
            typeof(GestureRecognizer));

        /// <summary>
        /// Initializes a new instance of the <see cref="GestureRecognizer"/> class.
        /// </summary>
        protected GestureRecognizer()
        {
        }

        /// <summary>
        /// Gets or sets the number of touches required.
        /// </summary>
        public int NumberOfTouchesRequired
        {
            get { return (int)GetValue(NumberOfTouchesRequiredProperty); }
            set { SetValue(NumberOfTouchesRequiredProperty, value); }
        }

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        /// <summary>
        /// Gets or sets the command parameter.
        /// </summary>
        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        /// <summary>
        /// Invoke the touches began event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="point">The point where touches began.</param>
        internal void InvokeTouchesBegan(View sender, Point point) => TouchesBegan?.Invoke(sender, point);

        /// <summary>
        /// Invoke the touches ended event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="point">The point where touches ended.</param>
        internal void InvokeTouchesEnded(View sender, Point point) => TouchesEnded?.Invoke(sender, point);
    }
}