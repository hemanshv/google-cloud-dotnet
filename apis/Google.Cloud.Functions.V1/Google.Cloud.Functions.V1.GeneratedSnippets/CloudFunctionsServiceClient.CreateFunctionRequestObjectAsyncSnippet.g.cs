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

namespace Google.Cloud.Functions.V1.Snippets
{
    // [START cloudfunctions_v1_generated_CloudFunctionsService_CreateFunction_async]
    using Google.Api.Gax.ResourceNames;
    using Google.Cloud.Functions.V1;
    using Google.LongRunning;
    using System.Threading.Tasks;

    public sealed partial class GeneratedCloudFunctionsServiceClientSnippets
    {
        /// <summary>Snippet for CreateFunctionAsync</summary>
        /// <remarks>
        /// This snippet has been automatically generated for illustrative purposes only.
        /// It may require modifications to work in your environment.
        /// </remarks>
        public async Task CreateFunctionRequestObjectAsync()
        {
            // Create client
            CloudFunctionsServiceClient cloudFunctionsServiceClient = await CloudFunctionsServiceClient.CreateAsync();
            // Initialize request argument(s)
            CreateFunctionRequest request = new CreateFunctionRequest
            {
                LocationAsLocationName = LocationName.FromProjectLocation("[PROJECT]", "[LOCATION]"),
                Function = new CloudFunction(),
            };
            // Make the request
            Operation<CloudFunction, OperationMetadataV1> response = await cloudFunctionsServiceClient.CreateFunctionAsync(request);

            // Poll until the returned long-running operation is complete
            Operation<CloudFunction, OperationMetadataV1> completedResponse = await response.PollUntilCompletedAsync();
            // Retrieve the operation result
            CloudFunction result = completedResponse.Result;

            // Or get the name of the operation
            string operationName = response.Name;
            // This name can be stored, then the long-running operation retrieved later by name
            Operation<CloudFunction, OperationMetadataV1> retrievedResponse = await cloudFunctionsServiceClient.PollOnceCreateFunctionAsync(operationName);
            // Check if the retrieved long-running operation has completed
            if (retrievedResponse.IsCompleted)
            {
                // If it has completed, then access the result
                CloudFunction retrievedResult = retrievedResponse.Result;
            }
        }
    }
    // [END cloudfunctions_v1_generated_CloudFunctionsService_CreateFunction_async]
}