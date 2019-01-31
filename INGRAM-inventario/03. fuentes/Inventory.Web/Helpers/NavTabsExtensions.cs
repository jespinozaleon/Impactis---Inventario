using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Inventory.Web.Helpers
{
    public static class NavTabsExtensions
    {
        public static MvcHtmlString NavTab(this HtmlHelper helper, string linkText, string actionName,
            string controllerName, params string[] selectedActions)
        {
            var li = new TagBuilder("li");
            var routeData = helper.ViewContext.RouteData;
            var currentAction = routeData.GetRequiredString("action");

            if (selectedActions != null && selectedActions.Contains(currentAction))
            {
                li.AddCssClass("active");
            }
            else if (currentAction.ToLower() == actionName.ToLower())
            {
                li.AddCssClass("active");
            }

            li.InnerHtml = helper.ActionLink(linkText, actionName, controllerName).ToHtmlString();
            return MvcHtmlString.Create(li.ToString());
        }
    }
}