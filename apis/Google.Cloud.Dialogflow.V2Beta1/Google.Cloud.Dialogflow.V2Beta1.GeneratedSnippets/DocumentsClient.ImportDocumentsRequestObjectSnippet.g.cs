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

namespace Google.Cloud.Dialogflow.V2Beta1.Snippets
{
    // [START dialogflow_v2beta1_generated_Documents_ImportDocuments_sync]
    using Google.Cloud.Dialogflow.V2Beta1;
    using Google.LongRunning;

    public sealed partial class GeneratedDocumentsClientSnippets
    {
        /// <summary>Snippet for ImportDocuments</summary>
        /// <remarks>
        /// This snippet has been automatically generated for illustrative purposes only.
        /// It may require modifications to work in your environment.
        /// </remarks>
        public void ImportDocumentsRequestObject()
        {
            // Create client
            DocumentsClient documentsClient = DocumentsClient.Create();
            // Initialize request argument(s)
            ImportDocumentsRequest request = new ImportDocumentsRequest
            {
                ParentAsKnowledgeBaseName = KnowledgeBaseName.FromProjectKnowledgeBase("[PROJECT]", "[KNOWLEDGE_BASE]"),
                GcsSource = new GcsSources(),
                DocumentTemplate = new ImportDocumentTemplate(),
                ImportGcsCustomMetadata = false,
            };
            // Make the request
            Operation<ImportDocumentsResponse, KnowledgeOperationMetadata> response = documentsClient.ImportDocuments(request);

            // Poll until the returned long-running operation is complete
            Operation<ImportDocumentsResponse, KnowledgeOperationMetadata> completedResponse = response.PollUntilCompleted();
            // Retrieve the operation result
            ImportDocumentsResponse result = completedResponse.Result;

            // Or get the name of the operation
            string operationName = response.Name;
            // This name can be stored, then the long-running operation retrieved later by name
            Operation<ImportDocumentsResponse, KnowledgeOperationMetadata> retrievedResponse = documentsClient.PollOnceImportDocuments(operationName);
            // Check if the retrieved long-running operation has completed
            if (retrievedResponse.IsCompleted)
            {
                // If it has completed, then access the result
                ImportDocumentsResponse retrievedResult = retrievedResponse.Result;
            }
        }
    }
    // [END dialogflow_v2beta1_generated_Documents_ImportDocuments_sync]
}