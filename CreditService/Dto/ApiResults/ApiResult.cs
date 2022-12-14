using System.Runtime.InteropServices;
using CreditService.Common.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CreditService.Model.ApiResults
{
    public class ActionResponse 
    {
        public bool IsSuccess { get; set; }
        public ApiResultStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public ActionResponse(bool isSuccess, ApiResultStatusCode status, String message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = status;
            Message = message ?? status.ToDisplay();
        }
    }



    public class ActionResponse<T> : ActionResponse
    {
        public T Data { get; set; }

        public ActionResponse(bool isSuccess, ApiResultStatusCode status, T data, String message = null)
                : base(isSuccess, status, message)
        {
            Data = data;
        }
    }
        
}
