namespace Bloodcraft.Web.Infrastructure.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    public class MapCreatingAttribute : ActionFilterAttribute
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //To do : after the action executes  
        }
    }
}
