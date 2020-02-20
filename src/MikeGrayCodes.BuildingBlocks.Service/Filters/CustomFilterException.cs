using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MikeGrayCodes.BuildingBlocks.Service.Errors;
using System;
using System.Linq;
using System.Net;

namespace MikeGrayCodes.BuildingBlocks.Service.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException)
            {
                var ex = (ValidationException)context.Exception;

                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;


                var error = new ErrorResponse
                {
                    Error = new Error
                    {
                        Message = "A bad request was received.",
                        Details = ex.Errors.Select(e => new ErrorDetail
                        {
                            Message = e.ErrorMessage,
                            Target = e.PropertyName
                        }).ToArray()
                    }
                };

                context.Result = new JsonResult(error);

                return;
            }

            var code = HttpStatusCode.InternalServerError;

            //if (context.Exception is NotFoundException)
            //{
            //    code = HttpStatusCode.NotFound;
            //}

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = new JsonResult(new
            {
                error = new[] { context.Exception.Message },
                stackTrace = context.Exception.StackTrace
            });
        }
    }
}
