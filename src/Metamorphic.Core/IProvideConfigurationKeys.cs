﻿//-----------------------------------------------------------------------
// <copyright company="Metamorphic">
// Copyright (c) Metamorphic. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENCE.md file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Nuclei.Configuration;

namespace Metamorphic.Core
{
    /// <summary>
    /// Defines the interface for objects that provide a collection of configuration keys.
    /// </summary>
    public interface IProvideConfigurationKeys
    {
        /// <summary>
        /// Returns a collection containing all the configuration keys for the application.
        /// </summary>
        /// <returns>A collection containing all the configuration keys for the application.</returns>
        IEnumerable<ConfigurationKey> ToCollection();
    }
}
