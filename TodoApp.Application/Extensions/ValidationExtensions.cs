using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Responses;

namespace TodoApp.Application.Extensions
{
    public static class ValidationExtensions
    {
        public static void SetValidationsWhenValidationsAreNotOk(this BaseResponse response, ValidationResult result)
        {
            response.Success = false;
            response.ValidationErrors = new List<string>();
            foreach (var error in result.Errors)
            {
                response.ValidationErrors.Add(error.ErrorMessage);
            }
        }


    }
}
