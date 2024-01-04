using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvoiceSystem.Common.Extensions
{
    public static class ModelStateExtension
    {
        /// <summary>
        /// در صورتی که 
        /// ModelState
        /// دارای خطا باشد
        /// پیغام های خطا را برگردانده و آنها را در المان مربوطه نمایش می دهد
        /// </summary>
        /// <param name="modelState"></param>
        public static string AddModelErrors(this ModelStateDictionary modelState)
        {
            var returnValue = string.Empty;
            foreach (var modelStateKey in modelState.Keys)
            {
                var modelStateVal = modelState[modelStateKey];
                foreach (var error in modelStateVal?.Errors.ToList())
                {
                    var key = modelStateKey;
                    var errorMessage = error.ErrorMessage;
                    var exception = error.Exception;

                    modelState.AddModelError(key, errorMessage);

                    returnValue += $"{key}, {errorMessage}";
                }
            }

            return returnValue;
        }

        public static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
        {
            var attrType = typeof(T);
            var property = instance.GetType().GetProperty(propertyName);
            return (T)property.GetCustomAttributes(attrType, false).First();
        }
    }
}
