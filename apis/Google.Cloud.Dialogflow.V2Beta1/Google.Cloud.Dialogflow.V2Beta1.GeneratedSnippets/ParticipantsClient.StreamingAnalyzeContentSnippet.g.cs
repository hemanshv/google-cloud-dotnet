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
    // [START dialogflow_v2beta1_generated_Participants_StreamingAnalyzeContent_sync]
    using Google.Api.Gax.Grpc;
    using Google.Cloud.Dialogflow.V2Beta1;
    using Google.Protobuf;
    using Google.Protobuf.WellKnownTypes;
    using System.Threading.Tasks;

    public sealed partial class GeneratedParticipantsClientSnippets
    {
        /// <summary>Snippet for StreamingAnalyzeContent</summary>
        /// <remarks>
        /// This snippet has been automatically generated for illustrative purposes only.
        /// It may require modifications to work in your environment.
        /// </remarks>
        public async Task StreamingAnalyzeContent()
        {
            // Create client
            ParticipantsClient participantsClient = ParticipantsClient.Create();
            // Initialize streaming call, retrieving the stream object
            ParticipantsClient.StreamingAnalyzeContentStream response = participantsClient.StreamingAnalyzeContent();

            // Sending requests and retrieving responses can be arbitrarily interleaved
            // Exact sequence will depend on client/server behavior

            // Create task to do something with responses from server
            Task responseHandlerTask = Task.Run(async () =>
            {
                // Note that C# 8 code can use await foreach
                AsyncResponseStream<StreamingAnalyzeContentResponse> responseStream = response.GetResponseStream();
                while (await responseStream.MoveNextAsync())
                {
                    StreamingAnalyzeContentResponse responseItem = responseStream.Current;
                    // Do something with streamed response
                }
                // The response stream has completed
            });

            // Send requests to the server
            bool done = false;
            while (!done)
            {
                // Initialize a request
                StreamingAnalyzeContentRequest request = new StreamingAnalyzeContentRequest
                {
                    ParticipantAsParticipantName = ParticipantName.FromProjectConversationParticipant("[PROJECT]", "[CONVERSATION]", "[PARTICIPANT]"),
                    AudioConfig = new InputAudioConfig(),
                    ReplyAudioConfig = new OutputAudioConfig(),
                    InputAudio = ByteString.Empty,
                    QueryParams = new QueryParameters(),
                    AssistQueryParams = new AssistQueryParameters(),
                    EnablePartialAutomatedAgentReply = false,
                    CxParameters = new Struct(),
                    CxCurrentPage = "",
                };
                // Stream a request to the server
                await response.WriteAsync(request);
                // Set "done" to true when sending requests is complete
            }

            // Complete writing requests to the stream
            await response.WriteCompleteAsync();
            // Await the response handler
            // This will complete once all server responses have been processed
            await responseHandlerTask;
        }
    }
    // [END dialogflow_v2beta1_generated_Participants_StreamingAnalyzeContent_sync]
}