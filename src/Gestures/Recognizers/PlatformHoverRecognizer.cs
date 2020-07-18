// <copyright file="PlatformHoverRecognizer.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Velocity.Gestures
{
    /// <summary>
    /// A multi-touch hover gesture recognizer.
    /// </summary>
    /// <typeparam name="TView">The native view.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class PlatformHoverRecognizer<TView> : PlatformRecognizer<TView>, IHoverRecognizer<TView> where TView : class
    {
        private readonly Subject<HoverEvent> _hoveringSubject;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformHoverRecognizer{TView}"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        protected PlatformHoverRecognizer(TView view) : base(view, 1)
        {
            _hoveringSubject = new Subject<HoverEvent>();
            Hovering = _hoveringSubject.AsObservable();
        }

        /// <inheritdoc/>
        public IObservable<HoverEvent> Hovering { get; }

        /// <summary>
        /// Call when hovering state has changed.
        /// </summary>
        /// <param name="state">The gesture state.</param>
        protected void OnHoveringStateChanged(GestureState state) => _hoveringSubject.OnNext(new HoverEvent(state));
    }
}