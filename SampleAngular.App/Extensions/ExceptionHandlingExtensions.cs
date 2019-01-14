using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleAngular.App.Helpers;
using SampleAngular.App.Messages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SampleAngular.App.Extensions
{
    public static class ExceptionHandlingExtensions
    {
        public static void UseMyExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        context.Response.ContentType = "application/json";

                        var ex = context.Features.Get<IExceptionHandlerFeature>();
                        if (ex != null)
                        {
                            var logger = loggerFactory.CreateLogger("Api.Extensions.ExceptionHandlingExtensions");
                            logger.LogError(500, ex.Error, ex.Error.Message);
                        }

                        await context.Response.WriteAsync(new InternalServerErrorMessage().ToJson());
                    });
            });
        }
    }
}
