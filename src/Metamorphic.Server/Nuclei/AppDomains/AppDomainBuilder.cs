//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

//-----------------------------------------------------------------------
// <copyright company="Nuclei">
//     Copyright 2013 Nuclei. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Security.Permissions;
using Nuclei;
using Metamorphic.Server.Nuclei.ExceptionHandling;
using System.CodeDom.Compiler;

namespace Metamorphic.Server.Nuclei.AppDomains
{
    /// <summary>
    /// Builds AppDomains with unhandled exception handlers and fusion loading events.
    /// </summary>
    [GeneratedCode("Nuclei.Appdomains", "0.8.0")]
    internal static partial class AppDomainBuilder
    {
        /// <summary>
        /// A class used to attach an exception handler to the created domain.
        /// </summary>
        private sealed class ExceptionHandlerAttacher : MarshalByRefObject
        {
            /// <summary>
            /// Attaches the exception handler to the domain.
            /// </summary>
            [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic",
                Justification = "This needs to be called on a proxy so it can't be a static method.")]
            public void Attach()
            {
                var domain = AppDomain.CurrentDomain;
                var handler = new ExceptionHandler(null, null);
                domain.UnhandledException += (s, e) => handler.OnException(e.ExceptionObject as Exception, e.IsTerminating);
            }
        }

        /// <summary>
        /// The default friendly name.
        /// </summary>
        private const string DefaultFriendlyName = "AppDomain generated by Nuclei.AppDomains";

        /// <summary>
        /// Generates the new name of the app domain.
        /// </summary>
        /// <returns>The newly generated <c>AppDomain</c> name.</returns>
        private static string GenerateNewAppDomainName()
        {
            return DefaultFriendlyName;
        }

        /// <summary>
        /// Creates a new <see cref="AppDomain"/>.
        /// </summary>
        /// <param name="name">The friendly name of the new <c>AppDomain</c>.</param>
        /// <param name="resolutionPaths">The assembly resolution paths for the new <c>AppDomain</c>.</param>
        /// <returns>The newly created <c>AppDomain</c>.</returns>
        private static AppDomain Create(string name, AppDomainResolutionPaths resolutionPaths)
        {
            {
                Debug.Assert(resolutionPaths != null, "The base path must be defined");
            }

            var setup = new AppDomainSetup
                {
                    ApplicationName = Assembly.GetCallingAssembly().GetName().Name,
                    ApplicationBase = resolutionPaths.BasePath, 
                    ShadowCopyFiles = "false", 
                    DisallowCodeDownload = true
                };

            var result = AppDomain.CreateDomain(
                string.IsNullOrEmpty(name) ? GenerateNewAppDomainName() : name,
                null,
                setup);
            return result;
        }

        /// <summary>
        /// Creates a new <see cref="AppDomain"/> and attaches the assembly resolver and exception handlers.
        /// </summary>
        /// <param name="friendlyName">The friendly name of the new <c>AppDomain</c>.</param>
        /// <param name="resolutionPaths">The assembly resolution paths for the new <c>AppDomain</c>.</param>
        /// <returns>The newly created <c>AppDomain</c>.</returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="resolutionPaths"/> is <see langword="null" />.
        /// </exception>
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        public static AppDomain Assemble(
            string friendlyName, 
            AppDomainResolutionPaths resolutionPaths)
        {
            {
                Lokad.Enforce.Argument(() => resolutionPaths);
            }

            var domain = Create(friendlyName, resolutionPaths);

            // Attach to the assembly file resolve event
            // We check for a null reference but not for an empty one,
            // there is after all no reason why the collection couldn't fill up later.
            if (resolutionPaths.Files != null)
            {
                var resolver = Activator.CreateInstanceFrom(
                    domain,
                    typeof(FileBasedResolver).Assembly.LocalFilePath(),
                    typeof(FileBasedResolver).FullName).Unwrap() as FileBasedResolver;

                Debug.Assert(resolver != null, "Somehow we didn't create a resolver.");
                resolver.StoreFilePaths(resolutionPaths.Files);
                resolver.Attach();
            }

            // Attach to the assembly directory resolve event
            // We check for a null reference but not for an empty one,
            // there is after all no reason why the collection couldn't fill up later.
            if (resolutionPaths.Directories != null)
            {
                var resolver = Activator.CreateInstanceFrom(
                    domain,
                    typeof(DirectoryBasedResolver).Assembly.LocalFilePath(),
                    typeof(DirectoryBasedResolver).FullName).Unwrap() as DirectoryBasedResolver;

                Debug.Assert(resolver != null, "Somehow we didn't create a resolver.");
                resolver.StoreDirectoryPaths(resolutionPaths.Directories);
                resolver.Attach();
            }

            // Attach the exception handler
            {
                var attacher = Activator.CreateInstanceFrom(
                    domain,
                    typeof(ExceptionHandlerAttacher).Assembly.LocalFilePath(),
                    typeof(ExceptionHandlerAttacher).FullName).Unwrap() as ExceptionHandlerAttacher;

                Debug.Assert(attacher != null, "Somehow we didn't create an exception handler attacher.");
                attacher.Attach();
            }

            return domain;
        }
    }
}

