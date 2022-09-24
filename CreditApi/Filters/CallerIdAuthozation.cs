using Common.ActionResult;
using Common.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Repository.Connection;


namespace CreditApi.Filters
{
    public class CallerIdAuthorization : IActionFilter
    {
        private readonly CreditContext _creditContext;

        public CallerIdAuthorization(CreditContext creditContext)
        {
            _creditContext = creditContext;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var callerId = Guid.Parse(context.HttpContext.Request.Headers["callerId"]);
            var SellingModuleId = _creditContext.callers.SingleOrDefault(x => x.CallerName == CallerNames.SellingModule).Id;
            if (callerId != SellingModuleId)
            {
                context.Result = new BadRequestObjectResult(new ActionResponse(false, ActionResultStatusCode.InvalidCallerId));
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
