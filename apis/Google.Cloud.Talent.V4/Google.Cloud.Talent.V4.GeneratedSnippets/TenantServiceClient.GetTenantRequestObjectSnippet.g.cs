// Copyright 2022 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// Generated code. DO NOT EDIT!

namespace Google.Cloud.Talent.V4.Snippets
{
    // [START jobs_v4_generated_TenantService_GetTenant_sync]
    using Google.Cloud.Talent.V4;

    public sealed partial class GeneratedTenantServiceClientSnippets
    {
        /// <summary>Snippet for GetTenant</summary>
        /// <remarks>
        /// This snippet has been automatically generated for illustrative purposes only.
        /// It may require modifications to work in your environment.
        /// </remarks>
        public void GetTenantRequestObject()
        {
            // Create client
            TenantServiceClient tenantServiceClient = TenantServiceClient.Create();
            // Initialize request argument(s)
            GetTenantRequest request = new GetTenantRequest
            {
                TenantName = TenantName.FromProjectTenant("[PROJECT]", "[TENANT]"),
            };
            // Make the request
            Tenant response = tenantServiceClient.GetTenant(request);
        }
    }
    // [END jobs_v4_generated_TenantService_GetTenant_sync]
}