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

using Microsoft.Extensions.Configuration;
using Owin;
using Steeltoe.Management.EndpointOwin.Hypermedia;
using Steeltoe.Management.EndpointOwin.Info;
using Steeltoe.Management.EndpointOwin.Test;
using System.Collections.Generic;

namespace Steeltoe.Management.EndpointOwin.Security.Test
{
    public class Startup
    {
        public static IConfiguration Config { get; set; }

        public virtual void Configuration(IAppBuilder app)
        {
            var builder = new ConfigurationBuilder();

            var appSettings = new Dictionary<string, string>(OwinTestHelpers.Appsettings)
            {
                ["management:endpoints:enabled"] = "false",
                ["management:endpoints:path"] = "/",
                ["info:application:name"] = "foobar",
                ["info:application:version"] = "1.0.0",
                ["info:application:date"] = "5/1/2008",
                ["info:application:time"] = "8:30:52 AM",
                ["info:NET:type"] = "Core",
                ["info:NET:version"] = "2.0.0",
                ["info:NET:ASPNET:type"] = "Core",
                ["info:NET:ASPNET:version"] = "2.0.0"
            };

            builder
                .AddInMemoryCollection(appSettings);
            builder.AddEnvironmentVariables();
            var config = Config = builder.Build();

            app.UseHypermediaActuator(config);
            app.UseInfoActuator(config);
        }
    }
}
