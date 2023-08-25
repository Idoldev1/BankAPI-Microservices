using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserServices_BankAPI.Models;


public class Account
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
    public string AccountNumberGenerated { get; set; }


    //This will store the hash and salt of the Account transaction pin
    [JsonIgnore]
    public byte[] PinHash { get; set; }
    [JsonIgnore]
    public byte[] PinSalt { get; set; }
    public DateTime DateCreatred { get; set; }
    public DateTime DateLastUpdated { get; set; }

    //We generate the acct number using the constructor
    //Lets create a random obj
    Random rand = new Random();

    public Account()
    {
        AccountNumberGenerated = Convert.ToString((long) Math.Floor(rand.NextDouble() *9_000_000_000L + 1_000_000_000L)); //This will generate a new random 10 digits number

        //Also the AccountName property

        AccountName = $"{FirstName} {LastName}";
    }
}


public enum AccountType
{
    Savings,
    Current,
    Corperate,
    Government
}