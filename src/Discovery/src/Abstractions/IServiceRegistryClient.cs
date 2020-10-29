// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;

namespace Steeltoe.Discovery
{
    public interface IServiceRegistryClient
    {
        /// <summary>
        /// Sets the status of the registration. The status values are determined by the individual implementations.
        /// </summary>
        /// <param name="status">The status to set</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task SetStatusAsync(InstanceStatus status);

        /// <summary>
        /// Gets the status of this service's registration.
        /// </summary>
        /// <returns>The current status of the registration.</returns>
        InstanceStatus GetCurrentStatus();
    }
}
