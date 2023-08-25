using System.ComponentModel.DataAnnotations;
using UserServices_BankAPI.Models;

namespace UserServices_BankAPI.Dtos;


public class GetAccountModel
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AccountName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public decimal CurrentAccountBalance { get; set; }
    public AccountType AccountType { get; set; } //This is an enum to show the differnt account types available

    public DateTime DateCreatred { get; set; }
    public DateTime DateLastUpdated { get; set; }
}