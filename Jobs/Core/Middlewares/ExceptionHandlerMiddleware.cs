using System.Text.Json;
using FluentValidation;
using Jobs.Api.Common.Dtos;
using Jobs.Core.Exceptions;

namespace Jobs.Core.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly JsonSerializerOptions _jsonSeriealializerOptions;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
        _jsonSeriealializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        } 
        catch (ModelNotFoundException e)
        {
             await handleModelNotFoundExceptionAsync(context, e);
        }
        catch (ValidationException e)
        {
            await handleValidationException(context, e);
        }
    }

    private Task handleValidationException(HttpContext context, ValidationException e)
    {
        var body = new ValidationErrorResponse
        {
            Status = 400,
            Error = "Bad Request",
            Cause = e.GetType().Name,
            Message = "Validation Error",
            Timestamp = DateTime.Now,
            Errors = e.Errors.GroupBy(vf => vf.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(vf => vf.ErrorMessage).ToArray())
        };
        context.Response.StatusCode = body.Status;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(body, _jsonSeriealializerOptions));
    }

    private Task handleModelNotFoundExceptionAsync(HttpContext context, ModelNotFoundException e)
    {
        var body = new ErrorResponse
        {
            Status = 404,
            Error = "Not Found",
            Cause = e.GetType().Name,
            Message = e.Message,
            Timestamp = DateTime.Now
        };
        context.Response.StatusCode = body.Status;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(body, _jsonSeriealializerOptions));
    }
}