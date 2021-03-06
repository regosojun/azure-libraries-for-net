// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Graph.RBAC.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Graph;
    using Microsoft.Azure.Management.Graph.RBAC;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Role Assignments filter
    /// </summary>
    public partial class RoleAssignmentFilterInner
    {
        /// <summary>
        /// Initializes a new instance of the RoleAssignmentFilterInner class.
        /// </summary>
        public RoleAssignmentFilterInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RoleAssignmentFilterInner class.
        /// </summary>
        /// <param name="principalId">Returns role assignment of the specific
        /// principal.</param>
        public RoleAssignmentFilterInner(string principalId = default(string))
        {
            PrincipalId = principalId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets returns role assignment of the specific principal.
        /// </summary>
        [JsonProperty(PropertyName = "principalId")]
        public string PrincipalId { get; set; }

    }
}
