// <copyright file="VirtualKeyEx.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System.Collections.Generic;
using AppKit;

namespace Velocity.Gestures.MacOs
{
    /// <summary>
    /// Extensions for <see cref="VirtualKey"/>.
    /// </summary>
    public static class VirtualKeyEx
    {
        /// <summary>
        /// Mapping dictionary between a <see cref="NSEvent"/> keycode and a <see cref="Key"/>.
        /// </summary>
        private static readonly Dictionary<ushort, Key> _lookup = new Dictionary<ushort, Key>()
        {
            // { WKey.None, Key.None },
            // { WKey.Cancel, Key.Cancel },
            // { WKey.Back, Key.Back },
            { 48, Key.Tab },
            // { WKey.Clear, Key.Clear },
            { 36, Key.Enter },
            // { WKey.Pause, Key.Pause },
            { 57, Key.CapitalLock },
            // { WKey.KanaMode, Key.Kana },
            // { WKey.JunjaMode, Key.Junja },
            // { WKey.FinalMode, Key.Final },
            // { WKey.KanjiMode, Key.Kanji },
            { 53, Key.Escape },
            // { WKey.ImeConvert, Key.Convert },
            // { WKey.ImeNonConvert, Key.NonConvert },
            // { WKey.ImeAccept, Key.Accept },
            // { WKey.ImeModeChange, Key.ModeChange },
            { 49, Key.Space },
            { 116, Key.PageUp },
            { 121, Key.PageDown },
            { 119, Key.End },
            { 115, Key.Home },
            { 123, Key.Left },
            { 126, Key.Up },
            { 124, Key.Right },
            { 125, Key.Down },
            // { WKey.Select, Key.Select },
            // { WKey.Print, Key.Print },
            // { WKey.Execute, Key.Execute },
            // { WKey.Snapshot, Key.Snapshot },
            // { WKey.Insert, Key.Insert },
            { 51, Key.Delete },
            // { WKey.Help, Key.Help },
            { 29, Key.Number0 },
            { 18, Key.Number1 },
            { 19, Key.Number2 },
            { 20, Key.Number3 },
            { 21, Key.Number4 },
            { 23, Key.Number5 },
            { 22, Key.Number6 },
            { 26, Key.Number7 },
            { 28, Key.Number8 },
            { 25, Key.Number9 },
            { 0, Key.A },
            { 11, Key.B },
            { 8, Key.C },
            { 2, Key.D },
            { 14, Key.E },
            { 3, Key.F },
            { 5, Key.G },
            { 4, Key.H },
            { 34, Key.I },
            { 38, Key.J },
            { 40, Key.K },
            { 37, Key.L },
            { 46, Key.M },
            { 45, Key.N },
            { 31, Key.O },
            { 35, Key.P },
            { 12, Key.Q },
            { 15, Key.R },
            { 1, Key.S },
            { 17, Key.T },
            { 32, Key.U },
            { 9, Key.V },
            { 13, Key.W },
            { 7, Key.X },
            { 16, Key.Y },
            { 6, Key.Z },
            { 55, Key.LeftWindows },
            // { WKey.RWin, Key.RightWindows },
            // { WKey.Sleep, Key.Sleep },
            { 82, Key.NumberPad0 },
            { 83, Key.NumberPad1 },
            { 84, Key.NumberPad2 },
            { 85, Key.NumberPad3 },
            { 86, Key.NumberPad4 },
            { 87, Key.NumberPad5 },
            { 88, Key.NumberPad6 },
            { 89, Key.NumberPad7 },
            { 91, Key.NumberPad8 },
            { 92, Key.NumberPad9 },
            { 67, Key.Multiply },
            { 69, Key.Add },
            // { WKey.Seperator, Key.Separator },
            { 78, Key.Subtract },
            { 65, Key.Decimal },
            { 75, Key.Divide },
            { 122, Key.F1 },
            { 120, Key.F2 },
            { 99, Key.F3 },
            { 118, Key.F4 },
            { 96, Key.F5 },
            { 97, Key.F6 },
            { 98, Key.F7 },
            { 100, Key.F8 },
            { 101, Key.F9 },
            { 109, Key.F10 },
            { 103, Key.F11 },
            { 111, Key.F12 },
            { 105, Key.F13 },
            { 107, Key.F14 },
            { 113, Key.F15 },
            { 106, Key.F16 },
            { 64, Key.F17 },
            { 79, Key.F18 },
            { 80, Key.F19 },
            { 90, Key.F20 },
            // { WKey.F21, Key.F21 },
            // { WKey.F22, Key.F22 },
            // { WKey.F23, Key.F23 },
            // { WKey.F24, Key.F24 },
            // { WKey.NumLock, Key.NumberKeyLock },
            { 56, Key.LeftShift },
            { 60, Key.RightShift },
            { 59, Key.LeftControl },
            // { WKey.RightCtrl, Key.RightControl },
            // { WKey.BrowserBack, Key.GoBack },
            // { WKey.BrowserForward, Key.GoForward },
            // { WKey.BrowserRefresh, Key.Refresh },
            // { WKey.BrowserStop, Key.Stop },
            // { WKey.BrowserSearch, Key.Search },
            // { WKey.BrowserFavorites, Key.Favorites },
            // { WKey.BrowserHome, Key.GoHome }
        };

        /// <summary>
        /// Convert to a <see cref="Key"/>.
        /// </summary>
        /// <param name="ev">The <see cref="NSEvent"/>.</param>
        /// <returns>The <see cref="Key"/>.</returns>
        public static Key ToKey(this NSEvent ev) => _lookup[ev.KeyCode];
    }
}