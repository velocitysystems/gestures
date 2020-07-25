// <copyright file="GestureListener.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Velocity.Gestures.Forms
{
    /// <summary>
    /// An interaction listener which routes input as an <see cref="IGestureRecognizer"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class GestureListener : Element, IGestureRecognizer
    {
        /// <summary>
        /// The bindable command property.
        /// </summary>
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(GestureListener));

        /// <summary>
        /// The bindable command parameter property.
        /// </summary>
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            nameof(CommandParameter),
            typeof(object),
            typeof(GestureListener));

        /// <summary>
        /// Initializes a new instance of the <see cref="GestureListener"/> class.
        /// </summary>
        protected GestureListener()
        {
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
    }
}