// Copyright 2017 the original author or authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.IO;

namespace Steeltoe.CloudFoundry.Connector.Test
{
    public class TestHelpers
    {
        public static string CreateTempFile(string contents)
        {
            var tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, contents);
            return tempFile;
        }

        public static Stream StringToStream(string str)
        {
            var memStream = new MemoryStream();
            var textWriter = new StreamWriter(memStream);
            textWriter.Write(str);
            textWriter.Flush();
            memStream.Seek(0, SeekOrigin.Begin);

            return memStream;
        }

        public static string StreamToString(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }

        public static string VCAP_APPLICATION =
            @"{
                ""application_id"": ""fa05c1a9-0fc1-4fbd-bae1-139850dec7a3"",
                ""application_name"": ""my-app"",
                ""application_uris"": [ ""my-app.10.244.0.34.xip.io""],
                ""application_version"": ""fb8fbcc6-8d58-479e-bcc7-3b4ce5a7f0ca"",
                ""limits"": {
                    ""disk"": 1024,
                    ""fds"": 16384,
                    ""mem"": 256
                },
                ""name"": ""my-app"",
                ""space_id"": ""06450c72-4669-4dc6-8096-45f9777db68a"",
                ""space_name"": ""my-space"",
                ""uris"": [
                    ""my-app.10.244.0.34.xip.io"",
                    ""my-app2.10.244.0.34.xip.io""
                ],
                ""users"": null,
                ""version"": ""fb8fbcc6-8d58-479e-bcc7-3b4ce5a7f0ca""
            }";
    }
}
