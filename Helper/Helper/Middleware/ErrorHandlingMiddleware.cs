﻿using System;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            } 
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ErrorHandlingMiddleware> logger)
        {
            var errors = new { Status = 0, Message = "" };
            var Status = 0;
            var Message = "";

            switch (ex)
            {
                //case RestException re:
                //    logger.LogError(ex, "REST ERROR");
                //    errors = re.Errors;
                //    context.Response.StatusCode = (int)re.Code;
                //    break;
                case Exception e:
                    logger.LogError(ex, "SERVER ERROR");
                    Message = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";
            if (errors != null)
            {
                var result = JsonConvert.SerializeObject(new 
                {
                    Message=Message,
                    Status=Status
                });

                await context.Response.WriteAsync(result);
            }
        }
    }
}