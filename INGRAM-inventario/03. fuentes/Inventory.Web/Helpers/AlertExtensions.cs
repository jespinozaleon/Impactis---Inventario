using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Inventory.Web.Helpers
{
    public enum AlertType
    {
        Info,
        Success,
        Danger,
        Warning
    }

    public static class AlertExtensions
    {
        public static MvcHtmlString Alert(this HtmlHelper html, AlertType type, string text)
        {
            if (string.IsNullOrEmpty(text)) return MvcHtmlString.Create("");
            /*
             <div class="alert alert-danger fade in">
                                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                    <i class="glyphicon glyphicon-ban-circle alert-icon "></i>
                                    <strong>Oh snap!</strong> Change a few things up and try submitting again.
                                </div>
                                <div class="alert alert-success fade in">
                                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                    
                                    <strong>Well done!</strong> You successfully read this important alert message.
                                </div>
             <div class="alert alert-info fade in">
                                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                    <i class="glyphicon glyphicon-info-sign alert-icon "></i>
                                    <strong>Heads up!</strong> This alert needs your attention, but it's not super important.
                                </div>
             */
            var div = new TagBuilder("div");
            div.MergeAttribute("class", "alert alert-" + type.ToString().ToLower()+ " fade in");
            div.InnerHtml = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

            switch (type)
            {
                case AlertType.Success:
                    div.InnerHtml = div.InnerHtml + "<i class=\"fa fa-check alert-icon \"></i>";
                    div.InnerHtml = div.InnerHtml + "<strong >¡Éxito!</strong>";
                    break;
                case AlertType.Danger:
                    div.InnerHtml = div.InnerHtml + "<i class=\"glyphicon glyphicon-ban-circle alert-icon \"></i>";
                    div.InnerHtml = div.InnerHtml + "<strong >Error!</strong>";
                    break;
                case AlertType.Info:
                    div.InnerHtml = div.InnerHtml + "<i class=\"glyphicon glyphicon-info-sign alert-icon \"></i>";
                    div.InnerHtml = "<strong >Información</strong>";
                    break;
            }

            div.InnerHtml = div.InnerHtml + "</br>" + text;

            string alertHtml = div.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(alertHtml);
        }

        public static MvcHtmlString Alert(this HtmlHelper html, AlertType type, List<string> errors)
        {

            if (errors.Count == 0) return MvcHtmlString.Create("");
            /*
             <div class="alert alert-danger fade in">
                                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                    <i class="glyphicon glyphicon-ban-circle alert-icon "></i>
                                    <strong>Oh snap!</strong> Change a few things up and try submitting again.
                                </div>
                                <div class="alert alert-success fade in">
                                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                    
                                    <strong>Well done!</strong> You successfully read this important alert message.
                                </div>
             <div class="alert alert-info fade in">
                                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                    <i class="glyphicon glyphicon-info-sign alert-icon "></i>
                                    <strong>Heads up!</strong> This alert needs your attention, but it's not super important.
                                </div>
             */
            var div = new TagBuilder("div");
            div.MergeAttribute("class", "alert alert-" + type.ToString().ToLower() + " fade in");
            div.InnerHtml = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

            switch (type)
            {
                case AlertType.Success:
                    div.InnerHtml = div.InnerHtml + "<i class=\"fa fa-check alert-icon \"></i>";
                    div.InnerHtml = div.InnerHtml + "<strong >Bien Hecho!</strong>";
                    break;
                case AlertType.Danger:
                    div.InnerHtml = div.InnerHtml + "<i class=\"glyphicon glyphicon-ban-circle alert-icon \"></i>";
                    div.InnerHtml = div.InnerHtml + "<strong >Error!</strong>";
                    break;
                case AlertType.Info:
                    div.InnerHtml = div.InnerHtml + "<i class=\"glyphicon glyphicon-info-sign alert-icon \"></i>";
                    div.InnerHtml = "<strong >Información</strong>";
                    break;
            }

            foreach (var err in errors)
            {
                div.InnerHtml = div.InnerHtml + "<li><p class='note-txt'>" + err + "</p></li>";
            }

            string alertHtml = div.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(alertHtml);
        }

        //        public static MvcHtmlString Alert(this HtmlHelper html, AlertType type, string[] text)
        //        {
        //            if (text == null || !text.Any()) return MvcHtmlString.Create("");
        //
        //            var div = new TagBuilder("div");
        //            div.MergeAttribute("class", "alert alert-dismissable alert-" + type.ToString().ToLower());
        //            switch (type)
        //            {
        //                case AlertType.success :
        //                    div.InnerHtml = "<button type='button' class='close' data-dismiss='alert'>&times;</button></br><strong>Bien Hecho!</strong>";
        //                    break;
        //                case AlertType.danger:
        //                    div.InnerHtml = "<button type='button' class='close' data-dismiss='alert'>&times;</button></br><strong>Error!</strong>";
        //                    break;
        //                case AlertType.warning:
        //                    div.InnerHtml = "<button type='button' class='close' data-dismiss='alert'>&times;</button></br><strong>Error!</strong>";
        //                    break;
        //                case AlertType.info:
        //                    div.InnerHtml = "<button type='button' class='close' data-dismiss='alert'>&times;</button></br><strong>Información</strong>";
        //                    break;
        //            }
        //
        //            div.InnerHtml = div.InnerHtml + "<ul>";
        //
        //            foreach (var value in text)
        //            {
        //                div.InnerHtml = div.InnerHtml + "<li><p class='note-txt'>" + value + "</p></li>";
        //            }
        //
        //            div.InnerHtml = div.InnerHtml + "</ul>";
        //
        //            var alertHtml = div.ToString(TagRenderMode.Normal);
        //
        //            return MvcHtmlString.Create(alertHtml);
        //        }

        public static MvcHtmlString Alert(this HtmlHelper html, ModelStateDictionary state)
        {
            if (state == null || state.Keys.Count <= 0) return MvcHtmlString.Create("");

            var div = new TagBuilder("div");
            div.MergeAttribute("class", "alert-holder");

            var div1 = new TagBuilder("div");
            div1.MergeAttribute("class", "alert alert-warning");

            div1.InnerHtml = div1.InnerHtml + "<span class='icon-warning-sign'></span>";
            //div.MergeAttribute("class", "alert alert-dismissable alert-warning");
            div1.InnerHtml = "<strong font-size: smaller; font-family: 'Arial', serif;'>Error Validación !</strong><button type='button' class='close' data-dismiss='alert'>&times;</button></br>";
            //            switch (type)
            //            {
            //                case AlertType.success:
            //                    div.InnerHtml = "<button type='button' class='close' data-dismiss='alert'>&times;</button></br><strong>Bien Hecho!</strong>&nbsp;";
            //                    break;
            //                case AlertType.danger:
            //                    div.InnerHtml = "<button type='button' class='close' data-dismiss='alert'>&times;</button></br><strong>Error!</strong>&nbsp;";
            //                    break;
            //                case AlertType.warning:
            //                    div.InnerHtml = "<button type='button' class='close' data-dismiss='alert'>&times;</button></br><strong>Error!</strong>&nbsp;";
            //                    break;
            //                case AlertType.info:
            //                    div.InnerHtml = "<button type='button' class='close' data-dismiss='alert'>&times;</button></br><strong>Información</strong>&nbsp;";
            //                    break;
            //            }
            div1.InnerHtml = div1.InnerHtml + "<ul style='font-size: smaller; font-family: 'Arial', serif;'>";

            foreach (var err in state.Keys.SelectMany(key => state[key].Errors))
            {
                div1.InnerHtml = div1.InnerHtml + "<li><p class='note-txt'>" + err.ErrorMessage + "</p></li>";
            }

            div1.InnerHtml = div1.InnerHtml + "</ul>";

            div.InnerHtml = div.InnerHtml + div1;
            var alertHtml = div.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(alertHtml);
        }
    }
}