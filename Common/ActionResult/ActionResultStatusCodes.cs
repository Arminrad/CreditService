using System.ComponentModel.DataAnnotations;

namespace CreditService.Model.ApiResults;

public enum ActionResultStatusCode
{
    [Display(Description = "Account created for user")]
    Created = 0,

    [Display(Description = "The transaction was completed successfully")]
    Success = 1,

    [Display(Description = "The account balance is insufficient")]
    Insufficient = 2,
}

