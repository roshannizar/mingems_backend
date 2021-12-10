using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Mingems.Shared.Api.Models;
using Mingems.Shared.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mingems.Api.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger logger;

        public ErrorMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            this.logger = logger.CreateLogger("ErrorLog");
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new ErrorModel { Succeeded = false, Message = ex?.Message };
                logger.LogError(ex.Message);

                switch (ex)
                {
                    case SecurityTokenExpiredException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = ex.Message;
                        break;
                    case ExpiredTokenException e:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        responseModel.Errors = ex.Message;
                        break;
                    case UserNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        responseModel.Errors = ex.Message;
                        break;
                    case AccountVerificationFailedException e:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        responseModel.Errors = ex.Message;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case NullReferenceException e:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.Errors = "Something went wrong in the server";
                        break;
                    default:
                        if (ex.InnerException == null)
                        {
                            response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            responseModel.Errors = ex.Message;
                        }
                        else
                        {
                            response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            responseModel.Errors = ex.InnerException.Message;
                        }
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
