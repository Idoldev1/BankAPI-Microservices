using System.ComponentModel.DataAnnotations;

namespace UserServices_BankAPI.Dtos;


public class UpdateAccountModel
{
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    [Required]
    [RegularExpression(@"^[0-9]/d{4}$", ErrorMessage = "Pin must not be more than 4 digits")]  //This makes it a 4-digit string
    public string Pin { get; set; }
    [Required]
    [Compare("Pin", ErrorMessage = "Pin and ConfirmPin do not match")]
    public string ConfirmPin { get; set; } //We are comparing both property and returning an error message incase of a mismatch

    public DateTime DateLastUpdated { get; set; }
}