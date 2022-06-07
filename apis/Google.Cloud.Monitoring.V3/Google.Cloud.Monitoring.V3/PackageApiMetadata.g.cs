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

namespace Google.Cloud.Monitoring.V3
{
    /// <summary>Static class to provide common access to package-wide API metadata.</summary>
    internal static class PackageApiMetadata
    {
        /// <summary>The <see cref="gaxgrpc::ApiMetadata"/> for services in this package.</summary>
        internal static gaxgrpc::ApiMetadata ApiMetadata { get; } = new gaxgrpc::ApiMetadata("Google.Cloud.Monitoring.V3", GetFileDescriptors);

        private static scg::IEnumerable<gpr::FileDescriptor> GetFileDescriptors()
        {
            yield return CommonReflection.Descriptor;
            yield return MutationRecordReflection.Descriptor;
            yield return AlertReflection.Descriptor;
            yield return AlertServiceReflection.Descriptor;
            yield return DroppedLabelsReflection.Descriptor;
            yield return GroupReflection.Descriptor;
            yield return GroupServiceReflection.Descriptor;
            yield return MetricReflection.Descriptor;
            yield return MetricServiceReflection.Descriptor;
            yield return NotificationReflection.Descriptor;
            yield return NotificationServiceReflection.Descriptor;
            yield return QueryServiceReflection.Descriptor;
            yield return ServiceReflection.Descriptor;
            yield return ServiceServiceReflection.Descriptor;
            yield return SpanContextReflection.Descriptor;
            yield return UptimeReflection.Descriptor;
            yield return UptimeServiceReflection.Descriptor;
        }
    }
}