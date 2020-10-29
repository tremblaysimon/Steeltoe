// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information.

using Microsoft.Extensions.Logging;
using Steeltoe.Common;
using Steeltoe.Discovery;
using System;
using System.Threading.Tasks;

namespace Steeltoe.Management.Endpoint.ServiceRegistry
{
    public class ServiceRegistryEndpoint : AbstractEndpoint<string, string>
    {
        private readonly IServiceRegistryClient _registryClient;
        private readonly ILogger<ServiceRegistryEndpoint> _logger;

        public ServiceRegistryEndpoint(IServiceRegistryOptions options, IServiceRegistryClient registryClient, ILogger<ServiceRegistryEndpoint> logger = null)
            : base(options)
        {
            _registryClient = registryClient ?? throw new ArgumentNullException(nameof(registryClient));
            _logger = logger;
        }

        public override string Invoke(string arg)
        {
            _logger?.LogDebug("Invoke({0})", SecurityUtilities.SanitizeInput(arg));

            return DoInvoke(arg).GetAwaiter().GetResult();
        }

        public async virtual Task<string> DoInvoke(string instanceStatus)
        {
            var result = InstanceStatus.UNKNOWN;
            if (instanceStatus is object)
            {
                if (Enum.TryParse<InstanceStatus>(instanceStatus, out var parsedStatus))
                {
                    await _registryClient.SetStatusAsync(parsedStatus);
                }
                else
                {
                    throw new ArgumentException(nameof(instanceStatus));
                }
            }
            else
            {
                result = _registryClient.GetCurrentStatus();
            }

            return result.ToString();
        }
    }
}
