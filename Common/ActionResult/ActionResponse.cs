using Common.Utilities;


namespace Common.ActionResult
{
    public class ActionResponse
    {
        public bool IsSuccess { get; set; }
        public ActionResultStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public ActionResponse(bool isSuccess, ActionResultStatusCode status, String? message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = status;
            Message = message ?? status.ToDisplay();
        }
    }


    public class ActionResponse<T> : ActionResponse
    {
        public T Data { get; set; }

        public ActionResponse(bool isSuccess, ActionResultStatusCode status, T data, String? message = null)
                : base(isSuccess, status, message)
        {
            Data = data;
        }
    }
}
