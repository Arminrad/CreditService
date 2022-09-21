using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using Common.ActionResult;


namespace CreditApi.Filters
{
    public class CallerIdAuthorization : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var callerId = Guid.Parse(context.HttpContext.Request.Headers["callerId"]);
            if ( callerId == new Guid("93fec9c7-8439-4fe9-98ba-d6a22c4cb65a") )
            {
                
            }
            else
            {
                context.Result = new BadRequestObjectResult(new ActionResponse(false, ActionResultStatusCode.Exist));
            }
            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

     
    }
}
