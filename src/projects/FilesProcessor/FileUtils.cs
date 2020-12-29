// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.Security.Cryptography;

namespace FilesProcessor
{
    public static class FileUtils
    {
        /// <summary>
        /// Temporary implementation until update to .net standard 2.1
        /// </summary>
        /// <param name="fromPath"></param>
        /// <param name="toPath"></param>
        /// <returns></returns>
        public static string GetRelativePath(this string fromPath, string toPath)
        {
            if (string.IsNullOrEmpty(fromPath)) throw new ArgumentNullException("fromPath");
            if (string.IsNullOrEmpty(toPath)) throw new ArgumentNullException("toPath");

            var fromUri = new Uri(fromPath);
            var toUri = new Uri(toPath);

            if (fromUri.Scheme != toUri.Scheme) { return toPath; }

            var relativeUri = fromUri.MakeRelativeUri(toUri);
            var relativePath = Uri.UnescapeDataString(relativeUri.ToString());

            if (toUri.Scheme.Equals("file", StringComparison.InvariantCultureIgnoreCase))
            {
                relativePath = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            }

            return relativePath;
        }

        public static string ComputeMD5HashString(this string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var fileStream = File.OpenRead(filePath))
                {
                    var hashByteArray = md5.ComputeHash(fileStream);
                    var result = BitConverter.ToString(hashByteArray).Replace("-", "").ToLowerInvariant();
                    return result;
                }
            }
        }
    }
}
