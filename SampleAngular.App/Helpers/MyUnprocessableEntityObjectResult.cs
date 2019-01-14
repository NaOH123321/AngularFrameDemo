using System;
using SampleAngular.App.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SampleAngular.App.Helpers
{
    public class MyUnprocessableEntityObjectResult: UnprocessableEntityObjectResult
    {
        public MyUnprocessableEntityObjectResult(ModelStateDictionary modelState) : base(modelState)
        {
            if (modelState == null)
            {
                throw new ArgumentNullException(nameof(modelState));
            }
            StatusCode = 422;
            Value = new UnprocessableEntityMessage(){
                Msg = new ResourceValidationResult(modelState),
            };
        }
    }
}
