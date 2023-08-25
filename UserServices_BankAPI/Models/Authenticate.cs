using System.ComponentModel.DataAnnotations;

namespace UserServices_BankAPI.Models;


public class Authenticate
{
    [Required]
    [RegularExpression(@"^[0][1-9]\d{9}$|^[1-9]\d{9}$", ErrorMessage = "Pin must not be more than 4 digits")]
    public string AccountNumber { get; set; }

    [Required]
    public string Pin { get; set; }
}