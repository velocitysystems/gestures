using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: AssemblyVersion("0.1.0")]
[assembly: AssemblyCompany("Velocity Systems")]
[assembly: AssemblyCopyright("Copyright © 2020 Velocity Systems")]

// The assemblies that can access internals of each platform flavor of Watchtower.Meps.XPlat.Media.
[assembly: InternalsVisibleTo("Velocity.Gestures.Forms.UWP")]
[assembly: InternalsVisibleTo("Velocity.Gestures.Forms.Droid")]
[assembly: InternalsVisibleTo("Velocity.Gestures.Forms.iOS")]
[assembly: InternalsVisibleTo("Velocity.Gestures.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
