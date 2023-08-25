using UserServices_BankAPI.Models;

namespace UserServices_BankAPI.Repository;

public interface IAccountRepository
{
    Account Authenticate(string AccountNumber, string Pin);
    IEnumerable<Account> GetAllAcount();
    Account Create(Account account, string Pin, string ConfirmPin);
    void Update(Account account, string? Pin =null);
    void Delete(int Id);
    Account GetById(int Id);
    Account GetByAccountNumber(string AccountNumber);
}