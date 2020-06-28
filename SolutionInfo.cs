// <copyright file="SolutionInfo.cs" company="Velocity Systems">
//     Copyright (c) 2020 Velocity Systems
// </copyright>

using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: AssemblyVersion("0.1.0")]
[assembly: AssemblyCompany("Velocity Systems")]
[assembly: AssemblyCopyright("Copyright © 2020 Velocity Systems")]

// The assemblies that can access internals of each platform flavor of Velocity.Gestures.
[assembly: InternalsVisibleTo("Velocity.Gestures.Droid")]
[assembly: InternalsVisibleTo("Velocity.Gestures.iOS")]
[assembly: InternalsVisibleTo("Velocity.Gestures.MacOS")]
[assembly: InternalsVisibleTo("Velocity.Gestures.UWP")]
[assembly: InternalsVisibleTo("Velocity.Gestures.WPF")]
[assembly: InternalsVisibleTo("Velocity.Gestures.Forms.Droid")]
[assembly: InternalsVisibleTo("Velocity.Gestures.Forms.iOS")]
[assembly: InternalsVisibleTo("Velocity.Gestures.Forms.MacOS")]
[assembly: InternalsVisibleTo("Velocity.Gestures.Forms.UWP")]
[assembly: InternalsVisibleTo("Velocity.Gestures.Forms.WPF")]
[assembly: InternalsVisibleTo("Velocity.Gestures.Tests")]
[assembly: InternalsVisibleTo("Velocity.Gestures")]