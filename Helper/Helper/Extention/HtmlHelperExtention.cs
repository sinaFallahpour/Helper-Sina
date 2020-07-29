using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Extention
{
    public static class HtmlHelperExtention
    {



        public static string IsSelected(this IHtmlHelper htmlHelper, string controllers, string actions,string areas, string cssClass = "active")
        {
            controllers = controllers.ToLower();
            actions = actions.ToLower();
            areas = areas.ToLower();

            string currentAction = htmlHelper.ViewContext.RouteData.Values["action"] as string;
            currentAction = currentAction.ToLower();

            string currentController = htmlHelper.ViewContext.RouteData.Values["controller"] as string;
            currentController = currentController.ToLower();
         
            string currentArea = htmlHelper.ViewContext.RouteData.Values["area"] as string;
            currentArea = currentArea.ToLower();

            IEnumerable<string> acceptedActions = (actions ?? currentAction).Split(',');
            IEnumerable<string> acceptedControllers = (controllers ?? currentController).Split(',');
            IEnumerable<string> acceptedAreas = (areas ?? currentArea).Split(',');

            //acceptedAreas.Contains(acceptedAreas)
            var actionResult = acceptedActions.Contains(currentAction);
            var controllerResult = acceptedControllers.Contains(currentController);
            var arearResult = acceptedAreas.Contains(currentArea);

            var res = actionResult && controllerResult && arearResult ?
                cssClass : String.Empty;
            return res;
        }




      
            //public static string IsActive(this HtmlHelper html,
            //                              string control,
            //                              string action)
            //{
            //    var routeData = html.ViewContext.RouteData;

            //    var routeAction = (string)routeData.Values["action"];
            //    var routeControl = (string)routeData.Values["controller"];

            //    // both must match
            //    var returnActive = control == routeControl &&
            //                       action == routeAction;

            //    return returnActive ? "active" : "";
            //}
        

    }
}
