﻿// Copyright 2017 the original author or authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Steeltoe.Management.Endpoint.Test;
using System.Collections.Generic;
using Xunit;

namespace Steeltoe.Management.Endpoint.Metrics.Test
{
    public class MetricTagTest : BaseTest
    {
        [Fact]
        public void Constructor_SetsValues()
        {
            var tags = new HashSet<string>() { "tagValue" };
            var mtag = new MetricTag("tagname", tags);
            Assert.Equal("tagname", mtag.Tag);
            Assert.Same(tags, mtag.Values);
        }

        [Fact]
        public void JsonSerialization_ReturnsExpected()
        {
            var tags = new HashSet<string>() { "tagValue" };
            var mtag = new MetricTag("tagname", tags);
            var result = Serialize(mtag);
            Assert.Equal("{\"tag\":\"tagname\",\"values\":[\"tagValue\"]}", result);
        }
    }
}
