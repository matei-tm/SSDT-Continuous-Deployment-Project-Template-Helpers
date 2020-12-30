// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace SsdtProjectHelper.Common
{
    public class ProcessingResult
    {
        public ProcessingResult(ResultType resultType, string content)
        {
            ResultType = resultType;
            Content = content;
        }

        public ResultType ResultType { get; }
        public string Content { get; }
    }
}
