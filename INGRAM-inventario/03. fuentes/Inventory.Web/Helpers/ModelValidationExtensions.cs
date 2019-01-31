using System.Web.Mvc;

namespace Inventory.Web.Helpers
{
    public static class ModelValidationExtensions
    {
        public static MvcHtmlString ModelValidationSummary(this HtmlHelper html, ModelStateDictionary state)
        {
            return !state.IsValid ? AlertExtensions.Alert(html, state) : MvcHtmlString.Create("");
        }
    }
}