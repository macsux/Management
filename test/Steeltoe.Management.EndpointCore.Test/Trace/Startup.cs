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

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Steeltoe.Management.Endpoint.CloudFoundry;

namespace Steeltoe.Management.Endpoint.Trace.Test
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCloudFoundryActuator(Configuration);
#pragma warning disable CS0612 // Type or member is obsolete
            services.AddTraceActuator(Configuration);
#pragma warning restore CS0612 // Type or member is obsolete
        }

        public void Configure(IApplicationBuilder app)
        {
#pragma warning disable CS0612 // Type or member is obsolete
            app.UseTraceActuator();
#pragma warning restore CS0612 // Type or member is obsolete
        }
    }
}
