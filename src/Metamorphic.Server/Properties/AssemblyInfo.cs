﻿//-----------------------------------------------------------------------
// <copyright company="Metamorphic">
// Copyright (c) Metamorphic. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENCE.md file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Nuclei.Build;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Metamorphic.Server")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyProduct("Metamorphic.Server")]

[assembly: AssemblyCompany("")]
[assembly: AssemblyCopyright("Copyright (c)")]
[assembly: AssemblyTrademark("")]

[assembly: AssemblyCulture("")]
[assembly: NeutralResourcesLanguage("en")]

[assembly: AssemblyConfiguration("")]

[assembly: CLSCompliant(true)]

[assembly: InternalsVisibleTo("Test.Unit.Server")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("5083e0c3-486c-48d7-971c-7f04cec98b11")]

[assembly: AssemblyVersion("0.1.0.0")]
[assembly: AssemblyFileVersion("0.1.0.0")]
[assembly: AssemblyInformationalVersion("0.1.0")]

[assembly: AssemblyBuildTime(buildTime: "1900-01-01T00:00:00.0000000+12:00")]

[assembly: SuppressMessage(
    "Microsoft.Usage",
    "CA2243:AttributeStringLiteralsShouldParseCorrectly",
    Justification = "It is not a version, it's version control information.")]
[assembly: AssemblyBuildInformation(buildNumber: 0, versionControlInformation: "1234567890")]
