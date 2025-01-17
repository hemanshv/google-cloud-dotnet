// Copyright 2015 Google Inc. All Rights Reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Object = Google.Apis.Storage.v1.Data.Object;

namespace Google.Cloud.Storage.V1
{
    public abstract partial class StorageClient
    {
        /// <summary>
        /// Creates a copy of an object synchronously, potentially to a different bucket. This method uses the
        /// <c>rewriteObject</c> underlying API operation for more flexibility and reliability.
        /// </summary>
        /// <param name="sourceBucket">The name of the bucket containing the object to copy. Must not be null.</param>
        /// <param name="sourceObjectName">The name of the object to copy within the bucket. Must not be null.</param>
        /// <param name="destinationBucket">The name of the bucket to copy the object to. Must not be null.</param>
        /// <param name="destinationObjectName">The name of the object within the destination bucket. Must not be null.</param>
        /// <param name="options">Additional options for the copy operation. May be null, in which case appropriate
        /// defaults will be used.</param>
        /// <returns>The <see cref="Object"/> representation of the new storage object resulting from the copy.</returns>
        public virtual Object CopyObject(
            string sourceBucket,
            string sourceObjectName,
            string destinationBucket,
            string destinationObjectName,
            CopyObjectOptions options = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a copy of an object synchronously, potentially to a different bucket. This method uses the
        /// <c>rewriteObject</c> underlying API operation for more flexibility and reliability.
        /// </summary>
        /// <param name="sourceBucket">The name of the bucket containing the object to copy. Must not be null.</param>
        /// <param name="sourceObjectName">The name of the object to copy within the bucket. Must not be null.</param>
        /// <param name="destinationBucket">The name of the bucket to copy the object to. Must not be null.</param>
        /// <param name="destinationObjectName">The name of the object within the destination bucket. Must not be null.</param>
        /// <param name="options">Additional options for the copy operation. May be null, in which case appropriate
        /// defaults will be used.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <remarks>
        /// The fact that <paramref name="destinationBucket"/> and <paramref name="destinationObjectName"/> are
        /// optional is a mistake. The default value of null for these parameters is invalid for this method,
        /// meaning that any call which doesn't specify the parameters explicitly will fail. Making these parameters
        /// required would be a compile-time breaking change; this will be implemented in the next major version of this library.
        /// </remarks>
        /// <returns>A task representing the asynchronous operation, with a result returning the
        /// <see cref="Object"/> representation of the new storage object resulting from the copy.</returns>
        public virtual Task<Object> CopyObjectAsync(
            string sourceBucket,
            string sourceObjectName,
            string destinationBucket = null,
            string destinationObjectName = null,
            CopyObjectOptions options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }        
    }
}
