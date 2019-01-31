using System;
using System.Web.Mvc;

namespace Inventory.Web.Helpers
{
    public static class DatePickerExtensions
    {
        public static MvcHtmlString RegisterScriptDatePicker(this HtmlHelper html, string language)
        {
            var script = "<script type=\"text/javascript\">" +
                              "$(function() {" +
                                  "$('.date').datetimepicker({" +
                                      "language: '" + language + "'," +
                                      "pickTime: false" +
                                  "});" +
                              "});" +
                          "</script>";



            return MvcHtmlString.Create(script);
        }

        public static MvcHtmlString DatePicker(this HtmlHelper htmlHelper, string name, DateTime? date, string format)
        {
            //string html = "<div class=\"input-group input-group-sm date\" style=\"width:160px\" >" +
            //                    "<input class=\"form-control\" id=\"{0}\" name=\"{0}\" value=\"{1}\" data-format=\"{2}\" type=\"text\" style=\"width:130px\"></input>" +
            //                    "<span class=\"input-group-addon\"><i data-time-icon=\"icon-time\" data-date-icon=\"glyphicon glyphicon-calendar\"></i></span>" +
            //                "</div>";

            //            string html = "<div class=\"input-group input-group-sm date\" style=\"width:160px\" >" +
            //                            "<input class=\"form-control\" id=\"{0}\" name=\"{0}\" value=\"{1}\" data-format=\"{2}\" type=\"text\" style=\"width:130px\"></input>" +
            //                            "<span id=\"calendar_" + name + "\"  name=\"calendar_" + name + "\"  class=\"add-on\"><i data-time-icon=\"icon-time\" data-date-icon=\"glyphicon glyphicon-calendar\"></i></span>" +
            //                        "</div>";

            string html = "<div class=\"input-group input-group-sm datepicker date\" style=\"width:160px\" >" +
                            "<input class=\"form-control\" id=\"{0}\" name=\"{0}\" value=\"{1}\" data-format=\"{2}\" type=\"text\" style=\"width:130px\"></input>" +
                            "<span class=\"add-on input-group-addon\"><i data-time-icon=\"icon-time\" data-date-icon=\"glyphicon glyphicon-calendar\"></i></span>" +
                        "</div>";

            string value = date != null ? date.Value.ToString(format) : "";

            html = string.Format(html, name, value, format);

            return MvcHtmlString.Create(html);

        }

        public static MvcHtmlString DatePicker(this HtmlHelper htmlHelper, string name, DateTime? date, string format, string id)
        {
            //string html = "<div class=\"input-group input-group-sm date\" style=\"width:160px\" >" +
            //                    "<input class=\"form-control\" id=\"{0}\" name=\"{0}\" value=\"{1}\" data-format=\"{2}\" type=\"text\" style=\"width:130px\"></input>" +
            //                    "<span class=\"input-group-addon\"><i data-time-icon=\"icon-time\" data-date-icon=\"glyphicon glyphicon-calendar\"></i></span>" +
            //                "</div>";

            //            string html = "<div class=\"input-group input-group-sm date\" style=\"width:160px\" >" +
            //                            "<input class=\"form-control\" id=\"{0}\" name=\"{0}\" value=\"{1}\" data-format=\"{2}\" type=\"text\" style=\"width:130px\"></input>" +
            //                            "<span id=\"calendar_" + name + "\"  name=\"calendar_" + name + "\"  class=\"add-on\"><i data-time-icon=\"icon-time\" data-date-icon=\"glyphicon glyphicon-calendar\"></i></span>" +
            //                        "</div>";

            string html = "<div class=\"input-group input-group-sm date\" style=\"width:160px\" >" +
                            "<input class=\"form-control\" id=\"{3}\" name=\"{0}\" value=\"{1}\" data-format=\"{2}\" type=\"text\" style=\"width:130px\"></input>" +
                            "<span class=\"add-on input-group-addon\"><i data-time-icon=\"icon-time\" data-date-icon=\"glyphicon glyphicon-calendar\"></i></span>" +
                        "</div>";

            string value = date != null ? date.Value.ToString(format) : "";

            html = string.Format(html, name, value, format, id);

            return MvcHtmlString.Create(html);

        }

    }
}