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

using Steeltoe.Common.HealthChecks;

namespace Steeltoe.Management.Endpoint.Health.Test
{
    public class DownContributor : IHealthContributor
    {
        public string Id { get; } = "Down";

        public HealthCheckResult Health()
        {
            return new HealthCheckResult()
            {
                Status = HealthStatus.DOWN
            };
        }
    }
}
