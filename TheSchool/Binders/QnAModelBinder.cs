
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TheSchool.Models;

namespace TheSchool.Binders
{
    public class QnAModelBinder : IModelBinder
    {
        public static object BindQnAModel(IFormCollection values, ModelStateDictionary modelState)
        {
            //TODO: Implement model binder for QuestionAndAnswerModel

            var model = new QuestionAndAnswerModel();
            model.Answer = values["txtAnswer"];
            model.Question = values["txtQuestion"];
            model.Tags = values["txtTags"];

            if (string.IsNullOrEmpty(model.Answer))
            {
                modelState.AddModelError("Answer", "Empty answer");
            }
            if (string.IsNullOrEmpty(model.Question))
            {
                modelState.AddModelError("Question", "Empty question");

            }
            if (string.IsNullOrEmpty(model.Tags))
            {
                modelState.AddModelError("Tags", "Empty tags");
            }

            return model;

        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            return Task.FromResult(BindQnAModel(bindingContext.HttpContext.Request.Form, bindingContext.ModelState));
        }
    }
}