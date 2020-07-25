// <copyright file="PlatformKeyListener.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Velocity.Gestures
{
    /// <summary>
    /// A key interaction listener.
    /// </summary>
    /// <typeparam name="TView">The native view.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class PlatformKeyListener<TView> : PlatformListener<TView>, IKeyListener<TView> where TView : class
    {
        private readonly ConcurrentDictionary<Key, DateTime> _concurrentKeys;
        private readonly Subject<Key[]> _pressedSubject;
        private readonly Subject<Key> _keyDownSubject;
        private readonly Subject<Key> _keyUpSubject;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformKeyListener{TView}"/> class.
        /// </summary>
        /// <param name="view">The native view.</param>
        protected PlatformKeyListener(TView view) : base(view)
        {
            _concurrentKeys = new ConcurrentDictionary<Key, DateTime>();

            _pressedSubject = new Subject<Key[]>();
            Pressed = _pressedSubject.AsObservable();

            _keyDownSubject = new Subject<Key>();
            KeyDown = _keyDownSubject.AsObservable();

            _keyUpSubject = new Subject<Key>();
            KeyUp = _keyUpSubject.AsObservable();
        }

        /// <inheritdoc/>
        public IObservable<Key[]> Pressed { get; }

        /// <inheritdoc/>
        public IObservable<Key> KeyDown { get; }

        /// <inheritdoc/>
        public IObservable<Key> KeyUp { get; }

        /// <summary>
        /// Call when key down received.
        /// </summary>
        /// <param name="key">The key.</param>
        protected void OnKeyDown(Key key)
        {
            _keyDownSubject.OnNext(key);
            _concurrentKeys.TryAdd(key, DateTime.Now);

            // Fire if one or more key(s) are pressed.
            var keys = _concurrentKeys.OrderBy(q => q.Value).Select(q => q.Key);
            _pressedSubject.OnNext(keys.ToArray());
        }

        /// <summary>
        /// Call when key up received.
        /// </summary>
        /// <param name="key">The key.</param>
        protected void OnKeyUp(Key key)
        {
            _keyUpSubject.OnNext(key);
            _concurrentKeys.TryRemove(key, out _);
        }
    }
}