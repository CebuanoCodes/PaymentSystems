using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using PaymentSystem.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem.Api.Middleware
{
    public class UserKeyValidatorMiddleware
    {
        private readonly RequestDelegate _next;
        private IUserRepository UserRepository { get; set; }

        public UserKeyValidatorMiddleware(RequestDelegate next, IUserRepository _repo)
        {
            _next = next;
            UserRepository = _repo;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.Keys.Contains("user-key"))
            {
                context.Response.StatusCode = 400; //Bad Request                
                await context.Response.WriteAsync("User Key is missing");
                return;
            }
            else
            {
                if (!UserRepository.CheckValidUserKey(context.Request.Headers["user-key"]))
                {
                    context.Response.StatusCode = 401; //UnAuthorized
                    await context.Response.WriteAsync("Invalid User Key");
                    return;
                }
            }

            await _next.Invoke(context);
        }

    }

    //#region ExtensionMethod
    public static class UserKeyValidatorsExtension
    {
        public static IApplicationBuilder ApplyUserKeyValidation(this IApplicationBuilder app)
        {
            app.UseMiddleware<UserKeyValidatorMiddleware>();
            return app;
        }
    }
}


