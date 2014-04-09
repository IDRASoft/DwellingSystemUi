using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace DwellingSystemUi.Helpers
{
    public static class PartialHelper
    {
        public static MvcHtmlString PartialFor<TModel, TProperty>(HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string partialViewName, string altName = null)
        {
            var name = string.IsNullOrEmpty(altName) ? ExpressionHelper.GetExpressionText(expression) : altName;
            var model = ModelMetadata.FromLambdaExpression(expression, helper.ViewData).Model;
            var htmlFieldPrefix = new StringBuilder();
            if (!string.IsNullOrEmpty(helper.ViewData.TemplateInfo.HtmlFieldPrefix))
            {
                htmlFieldPrefix.Append(helper.ViewData.TemplateInfo.HtmlFieldPrefix);
                htmlFieldPrefix.Append(string.IsNullOrEmpty(name) ? "" : name.StartsWith("[") ? name : "." + name);
            }
            else
            {
                htmlFieldPrefix.Append(name);
            }
            var viewData = new ViewDataDictionary(helper.ViewData)
            {
                TemplateInfo = new TemplateInfo { HtmlFieldPrefix = htmlFieldPrefix.ToString() },
                Model = model
            };

            return helper.Partial(partialViewName, model, viewData);
        }

    }
}
