using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace GridMvcPOC
{
    public static class GridHelper
    {
        public static MvcHtmlString NewLabel(this HtmlHelper html, string text)
        {
            var finalString = text + "From Helper";
            return new MvcHtmlString(finalString);
        }

        public static MvcHtmlString Grid(this HtmlHelper html, IEnumerable<dynamic> Modal)
        {
            var grid = new WebGrid(Modal, canPage: true, rowsPerPage: 10, selectionFieldName: "selectedRow", ajaxUpdateContainerId: "gridContent"); 
            var gridHtml = grid.GetHtml();
            return new MvcHtmlString(gridHtml.ToHtmlString());
        }

        public static MvcHtmlString Grid(this HtmlHelper html, IEnumerable<dynamic> Modal, IEnumerable<WebGridColumn> columns)
        {
            var grid = new WebGrid(Modal, canPage: true, rowsPerPage: 10, selectionFieldName: "selectedRow", ajaxUpdateContainerId: "gridContent");
            var gridHtml = grid.GetHtml(columns: columns);
            return new MvcHtmlString(gridHtml.ToHtmlString());                                
        }
    }
}