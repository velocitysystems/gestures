// <copyright file="VirtualKeyEx.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System.Collections.Generic;
using WKey = System.Windows.Input.Key;

namespace Velocity.Gestures.WPF
{
    /// <summary>
    /// Extensions for <see cref="VirtualKey"/>.
    /// </summary>
    public static class VirtualKeyEx
    {
        /// <summary>
        /// Mapping dictionary between a <see cref="WKey"/> and a <see cref="Key"/>.
        /// </summary>
        private static readonly Dictionary<WKey, Key> _lookup = new Dictionary<WKey, Key>()
        {
            { WKey.None, Key.None },
            { WKey.Cancel, Key.Cancel },
            { WKey.Back, Key.Back },
            { WKey.Tab, Key.Tab },
            { WKey.Clear, Key.Clear },
            { WKey.Enter, Key.Enter },
            { WKey.Pause, Key.Pause },
            { WKey.CapsLock, Key.CapitalLock },
            { WKey.KanaMode, Key.Kana },
            { WKey.JunjaMode, Key.Junja },
            { WKey.FinalMode, Key.Final },
            { WKey.KanjiMode, Key.Kanji },
            { WKey.Escape, Key.Escape },
            { WKey.ImeConvert, Key.Convert },
            { WKey.ImeNonConvert, Key.NonConvert },
            { WKey.ImeAccept, Key.Accept },
            { WKey.ImeModeChange, Key.ModeChange },
            { WKey.Space, Key.Space },
            { WKey.PageUp, Key.PageUp },
            { WKey.PageDown, Key.PageDown },
            { WKey.End, Key.End },
            { WKey.Home, Key.Home },
            { WKey.Left, Key.Left },
            { WKey.Up, Key.Up },
            { WKey.Right, Key.Right },
            { WKey.Down, Key.Down },
            { WKey.Select, Key.Select },
            { WKey.Print, Key.Print },
            { WKey.Execute, Key.Execute },
            { WKey.Snapshot, Key.Snapshot },
            { WKey.Insert, Key.Insert },
            { WKey.Delete, Key.Delete },
            { WKey.Help, Key.Help },
            { WKey.D0, Key.Number0 },
            { WKey.D1, Key.Number1 },
            { WKey.D2, Key.Number2 },
            { WKey.D3, Key.Number3 },
            { WKey.D4, Key.Number4 },
            { WKey.D5, Key.Number5 },
            { WKey.D6, Key.Number6 },
            { WKey.D7, Key.Number7 },
            { WKey.D8, Key.Number8 },
            { WKey.D9, Key.Number9 },
            { WKey.A, Key.A },
            { WKey.B, Key.B },
            { WKey.C, Key.C },
            { WKey.D, Key.D },
            { WKey.E, Key.E },
            { WKey.F, Key.F },
            { WKey.G, Key.G },
            { WKey.H, Key.H },
            { WKey.I, Key.I },
            { WKey.J, Key.J },
            { WKey.K, Key.K },
            { WKey.L, Key.L },
            { WKey.M, Key.M },
            { WKey.N, Key.N },
            { WKey.O, Key.O },
            { WKey.P, Key.P },
            { WKey.Q, Key.Q },
            { WKey.R, Key.R },
            { WKey.S, Key.S },
            { WKey.T, Key.T },
            { WKey.U, Key.U },
            { WKey.V, Key.V },
            { WKey.W, Key.W },
            { WKey.X, Key.X },
            { WKey.Y, Key.Y },
            { WKey.Z, Key.Z },
            { WKey.LWin, Key.LeftWindows },
            { WKey.RWin, Key.RightWindows },
            { WKey.Sleep, Key.Sleep },
            { WKey.NumPad0, Key.NumberPad0 },
            { WKey.NumPad1, Key.NumberPad1 },
            { WKey.NumPad2, Key.NumberPad2 },
            { WKey.NumPad3, Key.NumberPad3 },
            { WKey.NumPad4, Key.NumberPad4 },
            { WKey.NumPad5, Key.NumberPad5 },
            { WKey.NumPad6, Key.NumberPad6 },
            { WKey.NumPad7, Key.NumberPad7 },
            { WKey.NumPad8, Key.NumberPad8 },
            { WKey.NumPad9, Key.NumberPad9 },
            { WKey.Multiply, Key.Multiply },
            { WKey.Add, Key.Add },
            { WKey.Separator, Key.Separator },
            { WKey.Subtract, Key.Subtract },
            { WKey.Decimal, Key.Decimal },
            { WKey.Divide, Key.Divide },
            { WKey.F1, Key.F1 },
            { WKey.F2, Key.F2 },
            { WKey.F3, Key.F3 },
            { WKey.F4, Key.F4 },
            { WKey.F5, Key.F5 },
            { WKey.F6, Key.F6 },
            { WKey.F7, Key.F7 },
            { WKey.F8, Key.F8 },
            { WKey.F9, Key.F9 },
            { WKey.F10, Key.F10 },
            { WKey.F11, Key.F11 },
            { WKey.F12, Key.F12 },
            { WKey.F13, Key.F13 },
            { WKey.F14, Key.F14 },
            { WKey.F15, Key.F15 },
            { WKey.F16, Key.F16 },
            { WKey.F17, Key.F17 },
            { WKey.F18, Key.F18 },
            { WKey.F19, Key.F19 },
            { WKey.F20, Key.F20 },
            { WKey.F21, Key.F21 },
            { WKey.F22, Key.F22 },
            { WKey.F23, Key.F23 },
            { WKey.F24, Key.F24 },
            { WKey.NumLock, Key.NumberKeyLock },
            { WKey.LeftShift, Key.LeftShift },
            { WKey.RightShift, Key.RightShift },
            { WKey.LeftCtrl, Key.LeftControl },
            { WKey.RightCtrl, Key.RightControl },
            { WKey.BrowserBack, Key.GoBack },
            { WKey.BrowserForward, Key.GoForward },
            { WKey.BrowserRefresh, Key.Refresh },
            { WKey.BrowserStop, Key.Stop },
            { WKey.BrowserSearch, Key.Search },
            { WKey.BrowserFavorites, Key.Favorites },
            { WKey.BrowserHome, Key.GoHome }
        };

        /// <summary>
        /// Convert to a <see cref="Key"/>.
        /// </summary>
        /// <param name="key">The <see cref="WKey"/>.</param>
        /// <returns>The <see cref="Key"/>.</returns>
        public static Key ToKey(this WKey key) => _lookup.TryGetValue(key, out var match) ? match : Key.None;
    }
}