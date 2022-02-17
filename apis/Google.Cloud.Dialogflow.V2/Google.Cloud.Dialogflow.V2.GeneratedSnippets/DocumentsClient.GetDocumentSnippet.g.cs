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

namespace Google.Cloud.Dialogflow.V2.Snippets
{
    // [START dialogflow_v2_generated_Documents_GetDocument_sync_flattened]
    using Google.Cloud.Dialogflow.V2;

    public sealed partial class GeneratedDocumentsClientSnippets
    {
        /// <summary>Snippet for GetDocument</summary>
        /// <remarks>
        /// This snippet has been automatically generated for illustrative purposes only.
        /// It may require modifications to work in your environment.
        /// </remarks>
        public void GetDocument()
        {
            // Create client
            DocumentsClient documentsClient = DocumentsClient.Create();
            // Initialize request argument(s)
            string name = "projects/[PROJECT]/knowledgeBases/[KNOWLEDGE_BASE]/documents/[DOCUMENT]";
            // Make the request
            Document response = documentsClient.GetDocument(name);
        }
    }
    // [END dialogflow_v2_generated_Documents_GetDocument_sync_flattened]
}