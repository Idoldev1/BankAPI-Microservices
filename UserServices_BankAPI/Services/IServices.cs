using UserServices_BankAPI.Services;

namespace UserServices_BankAPI;


public interface IServices
{
    IAccountServices AccountServices { get; set; }
}