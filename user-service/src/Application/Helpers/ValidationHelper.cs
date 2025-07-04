using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper.Configuration;

namespace Application.Helpers
{
    public class ValidationHelper
    {
        public static IList<ValidationResult> ValidateModel(object model)
        {
            var result = new List<ValidationResult>();
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(model, null, null);
            Validator.TryValidateObject(model, context, result, true);
            return result;
        }
    }
}