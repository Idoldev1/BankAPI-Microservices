using UserServices_BankAPI.Dtos;
using UserServices_BankAPI.Models;

namespace UserServices_BankAPI.Services;


public interface IAccountServices
{
    GetAccountModel Create(RegisterNewAccountModel newAccount);
    GetAccountModel GetAllAccount(GetAccountModel getAccount);
    Account Authenticate(Authenticate model);
    GetAccountModel GetByAccountNumber(string AccountNumber);
    GetAccountModel GetById(int Id);
    void UpdateAccount(UpdateAccountModel model, string Pin);

}