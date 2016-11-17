//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Metamorphic.Agent.Nuclei.ExceptionHandling
{
    /// <summary>
    /// Defines a top level exception handler which stops all exceptions from propagating out of the application, thus
    /// providing a chance for logging and semi-graceful termination of the application.
    /// </summary>
    [GeneratedCode("Nuclei.ExceptionHandling", "0.8.0")]
    internal static class TopLevelExceptionGuard
    {
        /// <summary>
        /// Runs an action inside a high level try .. catch construct that will not let any errors escape
        /// but will log errors to a file and the event log.
        /// </summary>
        /// <param name="actionToExecute">The action that should be executed.</param>
        /// <param name="exceptionProcessors">The collection of exception processors that will be used to log any unhandled exception.</param>
        /// <returns>
        /// A value indicating whether the action executed successfully or not.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "Catching an Exception object here because this is the top-level exception handler.")]
        public static GuardResult RunGuarded(Action actionToExecute, params ExceptionProcessor[] exceptionProcessors)
        {
            {
                Debug.Assert(actionToExecute != null, "The application method should not be null.");
            }

            var processor = new ExceptionHandler(exceptionProcessors);
            var result = GuardResult.None;
            ExceptionFilter.ExecuteWithFilter(
                () =>
                {
                    actionToExecute();
                    result = GuardResult.Success;
                },
                e =>
                {
                    processor.OnException(e, false);
                    result = GuardResult.Failure;
                });

            return result;
        }
    }
}
