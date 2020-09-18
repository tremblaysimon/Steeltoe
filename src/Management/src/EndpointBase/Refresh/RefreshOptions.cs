﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information.

using Microsoft.Extensions.Configuration;
using Steeltoe.Management.Endpoint.Security;
using System;

namespace Steeltoe.Management.Endpoint.Refresh
{
    [Obsolete("Use RefreshEndpointOptions instead")]
    public class RefreshOptions : AbstractOptions, IRefreshOptions
    {
        private const string MANAGEMENT_INFO_PREFIX = "management:endpoints:refresh";

        public RefreshOptions()
            : base()
        {
            Id = "refresh";
            RequiredPermissions = Permissions.RESTRICTED;
        }

        public RefreshOptions(IConfiguration config)
            : base(MANAGEMENT_INFO_PREFIX, config)
        {
            if (string.IsNullOrEmpty(Id))
            {
                Id = "refresh";
            }

            if (RequiredPermissions == Permissions.UNDEFINED)
            {
                RequiredPermissions = Permissions.RESTRICTED;
            }
        }
    }
}