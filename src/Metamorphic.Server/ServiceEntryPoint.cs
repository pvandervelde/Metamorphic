﻿//-----------------------------------------------------------------------
// <copyright company="Metamorphic">
// Copyright (c) Metamorphic. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENCE.md file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading;
using Autofac;
using Metamorphic.Server.Properties;
using Nuclei.Communication;
using Nuclei.Diagnostics;
using Nuclei.Diagnostics.Logging;

namespace Metamorphic.Server
{
    /// <summary>
    /// Defines the methods used by the service manager to control the service.
    /// </summary>
    internal sealed class ServiceEntryPoint : IDisposable
    {
        /// <summary>
        /// The object used to lock on.
        /// </summary>
        private readonly object _lock = new object();

        /// <summary>
        /// The IOC container for the service.
        /// </summary>
        private IContainer _container;

        /// <summary>
        /// The object that provides the diagnostics methods for the application.
        /// </summary>
        private SystemDiagnostics _diagnostics;

        /// <summary>
        /// A flag that indicates that the application has been stopped.
        /// </summary>
        private volatile bool _hasBeenStopped;

        /// <summary>
        /// A flag that indicates if the service has been disposed or not.
        /// </summary>
        private volatile bool _isDisposed;

        /// <summary>
        /// The object that processes signals.
        /// </summary>
        private SignalProcessor _signalProcessor;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (!_isDisposed)
            {
                OnStop();

                _isDisposed = true;
            }
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Start command is sent
        /// to the service by the Service Control Manager (SCM) or when the operating
        /// system starts (for a service that starts automatically). Specifies actions
        /// to take when the service starts.
        /// </summary>
        public void OnStart()
        {
            _container = DependencyInjection.CreateContainer();

            _signalProcessor = _container.Resolve<SignalProcessor>();
            _diagnostics = _container.Resolve<SystemDiagnostics>();
            var facade = _container.Resolve<ICommunicationFacade>();

            // Wait for the communication to be online
            var killTime = DateTime.Now.AddSeconds(90);
            while (DateTime.Now < killTime)
            {
                if (facade.KnownEndpoints().Any())
                {
                    break;
                }

                Thread.Sleep(500);
            }

            if (!facade.KnownEndpoints().Any())
            {
                throw new FailedToConnectToStorageException();
            }

            _diagnostics.Log(
                LevelToLog.Info,
                ServerConstants.LogPrefix,
                Resources.Log_Messages_ServiceStarted);
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Stop command is sent
        /// to the service by the Service Control Manager (SCM). Specifies actions to
        /// take when a service stops running.
        /// </summary>
        public void OnStop()
        {
            bool hasBeenStopped;
            lock (_lock)
            {
                hasBeenStopped = _hasBeenStopped;
            }

            if (hasBeenStopped)
            {
                return;
            }

            try
            {
                if (_signalProcessor != null)
                {
                    _signalProcessor = null;
                }

                // Do what ever we need to do to stop the service here
                _diagnostics.Log(
                    LevelToLog.Info,
                    ServerConstants.LogPrefix,
                    Resources.Log_Messages_ServiceStopped);

                if (_container != null)
                {
                    _container.Dispose();
                    _container = null;
                }
            }
            finally
            {
                lock (_lock)
                {
                    _hasBeenStopped = true;
                }
            }
        }
    }
}
