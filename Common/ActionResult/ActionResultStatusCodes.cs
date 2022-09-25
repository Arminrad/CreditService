using System.ComponentModel.DataAnnotations;

namespace Common.ActionResult
{
    public enum ActionResultStatusCode
    {
        [Display(Description = "Account created for user")]
        Created = 0,

        [Display(Description = "The transaction was completed successfully")]
        Success = 1,

        [Display(Description = "The account balance is insufficient")]
        Insufficient = 2,

        [Display(Description = "This user id does exist")]
        Exist = 3,

        [Display(Description = "The CallerId is invalid")]
        InvalidCallerId = 4,

        [Display(Description = "The UserId is invalid")]
        InvalidUserId = 5,

        [Display(Description = "Values fetched from database")]
        Fetched = 6,

        [Display(Description = "List is Empty ")]
        ListEmpty = 7,
    }
}

