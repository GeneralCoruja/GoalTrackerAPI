using Microsoft.AspNetCore.Mvc.Filters;

namespace TestAPI.Filters
{
    public class UserFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var auth = context.HttpContext.Request.Headers.Authorization;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
