using Common.ActionResult;
using Common.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Repository.Connection;
using Repository.UnitOfWorks;


namespace CreditApi.Filters
{
    public class CallerIdAuthorization : IActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;

        public CallerIdAuthorization(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var callerId = Guid.Parse(context.HttpContext.Request.Headers["callerId"]);
            var SellingModuleId = _unitOfWork.CallerRepository.TableNoTracking.SingleOrDefault(x => x.CallerName == CallerNames.SellingModule).Id;
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
