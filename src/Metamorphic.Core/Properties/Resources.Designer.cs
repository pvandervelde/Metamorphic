﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Metamorphic.Core.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Metamorphic.Core.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A parameter required for the action invocation was missing..
        /// </summary>
        internal static string Exceptions_Messages_MissingActionParameter {
            get {
                return ResourceManager.GetString("Exceptions_Messages_MissingActionParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A required configuration value was not provided..
        /// </summary>
        internal static string Exceptions_Messages_MissingConfiguration {
            get {
                return ResourceManager.GetString("Exceptions_Messages_MissingConfiguration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The required configuration value with key [{0}] was not provided..
        /// </summary>
        internal static string Exceptions_Messages_MissingConfiguration_WithKey {
            get {
                return ResourceManager.GetString("Exceptions_Messages_MissingConfiguration_WithKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No parameter with the specified name could be found..
        /// </summary>
        internal static string Exceptions_Messages_ParameterNotFound {
            get {
                return ResourceManager.GetString("Exceptions_Messages_ParameterNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No parameter with the name {0} could be found..
        /// </summary>
        internal static string Exceptions_Messages_ParameterNotFound_WithName {
            get {
                return ResourceManager.GetString("Exceptions_Messages_ParameterNotFound_WithName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The parameter should not be an empty string..
        /// </summary>
        internal static string Exceptions_Messages_ParameterShouldNotBeAnEmptyString {
            get {
                return ResourceManager.GetString("Exceptions_Messages_ParameterShouldNotBeAnEmptyString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Installing package {0} [{1}] from feed at {2}.
        /// </summary>
        internal static string Log_Messages_PackageInstaller_InstallingPackage_WithIdVersionAndRepository {
            get {
                return ResourceManager.GetString("Log_Messages_PackageInstaller_InstallingPackage_WithIdVersionAndRepository", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File in package {0} [{1}] at {2} already exists in destination at {3}..
        /// </summary>
        internal static string Log_Messages_PackageUtilities_AssemblyFileAlreadyExistsAtDestination_WithPackageIdAndVersionAndOriginAndDestination {
            get {
                return ResourceManager.GetString("Log_Messages_PackageUtilities_AssemblyFileAlreadyExistsAtDestination_WithPackageI" +
                        "dAndVersionAndOriginAndDestination", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Copying file in package {0} [{1}] from {2} to {3}..
        /// </summary>
        internal static string Log_Messages_PackageUtilities_CopyingAssemblyFile_WithPackageIdAndVersionAndOriginAndDestination {
            get {
                return ResourceManager.GetString("Log_Messages_PackageUtilities_CopyingAssemblyFile_WithPackageIdAndVersionAndOrigi" +
                        "nAndDestination", resourceCulture);
            }
        }
    }
}
