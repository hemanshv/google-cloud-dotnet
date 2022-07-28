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

#pragma warning disable CS8981
using gaxgrpc = Google.Api.Gax.Grpc;
using gpr = Google.Protobuf.Reflection;
using scg = System.Collections.Generic;

namespace Google.Cloud.Dialogflow.Cx.V3
{
    /// <summary>Static class to provide common access to package-wide API metadata.</summary>
    internal static class PackageApiMetadata
    {
        /// <summary>The <see cref="gaxgrpc::ApiMetadata"/> for services in this package.</summary>
        internal static gaxgrpc::ApiMetadata ApiMetadata { get; } = new gaxgrpc::ApiMetadata("Google.Cloud.Dialogflow.Cx.V3", GetFileDescriptors);

        private static scg::IEnumerable<gpr::FileDescriptor> GetFileDescriptors()
        {
            yield return AdvancedSettingsReflection.Descriptor;
            yield return AgentReflection.Descriptor;
            yield return AudioConfigReflection.Descriptor;
            yield return ChangelogReflection.Descriptor;
            yield return DeploymentReflection.Descriptor;
            yield return EntityTypeReflection.Descriptor;
            yield return EnvironmentReflection.Descriptor;
            yield return ExperimentReflection.Descriptor;
            yield return FlowReflection.Descriptor;
            yield return FulfillmentReflection.Descriptor;
            yield return IntentReflection.Descriptor;
            yield return PageReflection.Descriptor;
            yield return ResponseMessageReflection.Descriptor;
            yield return SecuritySettingsReflection.Descriptor;
            yield return SessionReflection.Descriptor;
            yield return SessionEntityTypeReflection.Descriptor;
            yield return TestCaseReflection.Descriptor;
            yield return TransitionRouteGroupReflection.Descriptor;
            yield return ValidationMessageReflection.Descriptor;
            yield return VersionReflection.Descriptor;
            yield return WebhookReflection.Descriptor;
        }
    }
}
