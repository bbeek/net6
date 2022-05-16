﻿using System;

using Microsoft.AspNetCore.Http;

namespace NewStyle;

public static class IResultExtensions 
{
    public static T? GetOkObjectResult<T>(this IResult result) 
    { 
        return (T?)Type.GetType("Microsoft.AspNetCore.Http.Result.OkObjectResult, Microsoft.AspNetCore.Http.Results")?
            .GetProperty("Value", 
                System.Reflection.BindingFlags.Instance | 
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Public)?
            .GetValue(result);
    }

    public static int? GetOkObjectResultStatusCode(this IResult result)
    {
        return (int?)Type.GetType("Microsoft.AspNetCore.Http.Result.OkObjectResult, Microsoft.AspNetCore.Http.Results")?
            .GetProperty("StatusCode",
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Public)?
            .GetValue(result);
    }
}