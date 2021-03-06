﻿//-----------------------------------------------------------------------
// <copyright company="Metamorphic">
// Copyright (c) Metamorphic. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENCE.md file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------

using Nuclei;

namespace Metamorphic.Core
{
    /// <summary>
    /// Defines an interface for objects that have an identity.
    /// </summary>
    /// <typeparam name="TId">The type of the ID instance that is used to identity the current instance.</typeparam>
    public interface IHaveIdentity<TId>
        where TId : IIsId<TId>
    {
        /// <summary>
        /// Gets the ID for the current instance.
        /// </summary>
        IIsId<TId> Id
        {
            get;
        }

        /// <summary>
        /// Returns the ID of the current instance as a human readable string.
        /// </summary>
        /// <returns>The ID as a human readable string.</returns>
        string IdAsText();
    }
}
