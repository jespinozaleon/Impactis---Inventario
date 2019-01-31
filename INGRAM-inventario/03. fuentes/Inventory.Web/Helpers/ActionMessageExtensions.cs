using System.Collections.Generic;
using System.Web.Mvc;

namespace Inventory.Web.Helpers
{
    public static class ActionMessageExtensions
    {
        public static MvcHtmlString ActionSuccess(this HtmlHelper html, string message)
        {
            return message != null ? AlertExtensions.Alert(html, AlertType.Success, message) : MvcHtmlString.Create("");
        }

        public static MvcHtmlString ActionError(this HtmlHelper html, string message)
        {
            return message != null ? AlertExtensions.Alert(html, AlertType.Danger, message) : MvcHtmlString.Create("");
        }

        public static MvcHtmlString ActionInfo(this HtmlHelper html, string message)
        {
            return message != null ? AlertExtensions.Alert(html, AlertType.Info, message) : MvcHtmlString.Create("");
        }

        public static MvcHtmlString ActionValidation(this HtmlHelper html, List<string> messages)
        {
            return (messages != null && messages.Count > 0) ? AlertExtensions.Alert(html, AlertType.Warning, messages) : MvcHtmlString.Create("");
        }
    }
}