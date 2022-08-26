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

namespace Google.Cloud.Retail.V2.Snippets
{
    // [START retail_v2_generated_CatalogService_AddCatalogAttribute_async]
    using Google.Cloud.Retail.V2;
    using System.Threading.Tasks;

    public sealed partial class GeneratedCatalogServiceClientSnippets
    {
        /// <summary>Snippet for AddCatalogAttributeAsync</summary>
        /// <remarks>
        /// This snippet has been automatically generated for illustrative purposes only.
        /// It may require modifications to work in your environment.
        /// </remarks>
        public async Task AddCatalogAttributeRequestObjectAsync()
        {
            // Create client
            CatalogServiceClient catalogServiceClient = await CatalogServiceClient.CreateAsync();
            // Initialize request argument(s)
            AddCatalogAttributeRequest request = new AddCatalogAttributeRequest
            {
                AttributesConfigAsAttributesConfigName = AttributesConfigName.FromProjectLocationCatalog("[PROJECT]", "[LOCATION]", "[CATALOG]"),
                CatalogAttribute = new CatalogAttribute(),
            };
            // Make the request
            AttributesConfig response = await catalogServiceClient.AddCatalogAttributeAsync(request);
        }
    }
    // [END retail_v2_generated_CatalogService_AddCatalogAttribute_async]
}