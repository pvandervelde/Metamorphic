﻿//-----------------------------------------------------------------------
// <copyright company="Metamorphic">
// Copyright (c) Metamorphic. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENCE.md file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Globalization;
using EasyNetQ;
using Nuclei.Diagnostics;
using Nuclei.Diagnostics.Logging;

namespace Metamorphic.Core.Queueing
{
    /// <summary>
    /// Implements the <see cref="IEasyNetQLogger"/> interface to allow logging EasyNetQ log messages.
    /// </summary>
    internal sealed class EasyNetQLogger : IEasyNetQLogger
    {
        /// <summary>
        /// The object that provides the diagnostics methods for the system.
        /// </summary>
        private readonly SystemDiagnostics _diagnostics;

        /// <summary>
        /// Initializes a new instance of the <see cref="EasyNetQLogger"/> class.
        /// </summary>
        /// <param name="diagnostics">The object that provides the diagnostics methods for the system.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="diagnostics"/> is <see langword="null" />.
        /// </exception>
        public EasyNetQLogger(SystemDiagnostics diagnostics)
        {
            if (diagnostics == null)
            {
                throw new ArgumentNullException("diagnostics");
            }

            _diagnostics = diagnostics;
        }

        public void DebugWrite(string format, params object[] args)
        {
            // Check if there are arguments, if there aren't we shouldn't format because
            // we might be writing a JSON string with { and }. So because
            // this: https://github.com/EasyNetQ/EasyNetQ/issues/228
            if ((args == null) || (args.Length == 0))
            {
                _diagnostics.Log(
                    LevelToLog.Debug,
                    format);
            }
            else
            {
                _diagnostics.Log(
                    LevelToLog.Debug,
                    string.Format(
                        CultureInfo.InvariantCulture,
                        format,
                        args));
            }
        }

        public void ErrorWrite(Exception exception)
        {
            if (exception == null)
            {
                return;
            }

            _diagnostics.Log(
                LevelToLog.Error,
                exception.ToString());
        }

        public void ErrorWrite(string format, params object[] args)
        {
            // Check if there are arguments, if there aren't we shouldn't format because
            // we might be writing a JSON string with { and }. So because
            // this: https://github.com/EasyNetQ/EasyNetQ/issues/228
            if ((args == null) || (args.Length == 0))
            {
                _diagnostics.Log(
                    LevelToLog.Error,
                    format);
            }
            else
            {
                _diagnostics.Log(
                    LevelToLog.Error,
                    string.Format(
                        CultureInfo.InvariantCulture,
                        format,
                        args));
            }
        }

        public void InfoWrite(string format, params object[] args)
        {
            // Check if there are arguments, if there aren't we shouldn't format because
            // we might be writing a JSON string with { and }. So because
            // this: https://github.com/EasyNetQ/EasyNetQ/issues/228
            if ((args == null) || (args.Length == 0))
            {
                _diagnostics.Log(
                    LevelToLog.Info,
                    format);
            }
            else
            {
                _diagnostics.Log(
                    LevelToLog.Info,
                    string.Format(
                        CultureInfo.InvariantCulture,
                        format,
                        args));
            }
        }
    }
}
