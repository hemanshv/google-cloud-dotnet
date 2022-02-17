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
    // [START dialogflow_v2_generated_Participants_AnalyzeContent_async_flattened1_resourceNames]
    using Google.Cloud.Dialogflow.V2;
    using System.Threading.Tasks;

    public sealed partial class GeneratedParticipantsClientSnippets
    {
        /// <summary>Snippet for AnalyzeContentAsync</summary>
        /// <remarks>
        /// This snippet has been automatically generated for illustrative purposes only.
        /// It may require modifications to work in your environment.
        /// </remarks>
        public async Task AnalyzeContent1ResourceNamesAsync()
        {
            // Create client
            ParticipantsClient participantsClient = await ParticipantsClient.CreateAsync();
            // Initialize request argument(s)
            ParticipantName participant = ParticipantName.FromProjectConversationParticipant("[PROJECT]", "[CONVERSATION]", "[PARTICIPANT]");
            TextInput textInput = new TextInput();
            // Make the request
            AnalyzeContentResponse response = await participantsClient.AnalyzeContentAsync(participant, textInput);
        }
    }
    // [END dialogflow_v2_generated_Participants_AnalyzeContent_async_flattened1_resourceNames]
}