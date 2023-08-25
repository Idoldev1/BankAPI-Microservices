using System.ComponentModel.DataAnnotations;
using UserServices_BankAPI.Models;

namespace UserServices_BankAPI.Dtos;

public class RegisterNewAccountModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    //public string AccountName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    //public decimal CurrentAccountBalance { get; set; }
    public AccountType AccountType { get; set; } //This is an enum to show the differnt account types available


    /*We will store the hash and salt of the Account transaction pin
    public byte[] PinHash { get; set; }
    public byte[] PinSalt { get; set; }*/
    public DateTime DateCreatred { get; set; }
    public DateTime DateLastUpdated { get; set; }


    //Added regular expression to the pi property
    [Required]
    [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Pin must not be more than 4 digits")]  //This makes it a 4 digit string pin
    public string Pin { get; set; }
    
    [Required]
    [Compare("Pin", ErrorMessage = "Pin and ConfirmPin do not match")]
    public string ConfirmPin { get; set; }
}