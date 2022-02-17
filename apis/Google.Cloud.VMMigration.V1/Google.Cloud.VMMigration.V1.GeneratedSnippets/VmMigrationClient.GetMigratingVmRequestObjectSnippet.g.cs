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

namespace Google.Cloud.VMMigration.V1.Snippets
{
    // [START vmmigration_v1_generated_VmMigration_GetMigratingVm_sync]
    using Google.Cloud.VMMigration.V1;

    public sealed partial class GeneratedVmMigrationClientSnippets
    {
        /// <summary>Snippet for GetMigratingVm</summary>
        /// <remarks>
        /// This snippet has been automatically generated for illustrative purposes only.
        /// It may require modifications to work in your environment.
        /// </remarks>
        public void GetMigratingVmRequestObject()
        {
            // Create client
            VmMigrationClient vmMigrationClient = VmMigrationClient.Create();
            // Initialize request argument(s)
            GetMigratingVmRequest request = new GetMigratingVmRequest
            {
                MigratingVmName = MigratingVmName.FromProjectLocationSourceMigratingVm("[PROJECT]", "[LOCATION]", "[SOURCE]", "[MIGRATING_VM]"),
            };
            // Make the request
            MigratingVm response = vmMigrationClient.GetMigratingVm(request);
        }
    }
    // [END vmmigration_v1_generated_VmMigration_GetMigratingVm_sync]
}