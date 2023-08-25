using AutoMapper;
using UserServices_BankAPI.Dtos;
using UserServices_BankAPI.Models;
using UserServices_BankAPI.Repository;

namespace UserServices_BankAPI.Services;


public class AccountServices : IAccountServices
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public AccountServices(IAccountRepository accountRepository
                           ,IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }



    

    public GetAccountModel Create(RegisterNewAccountModel newAccount)
    {
        var account = _mapper.Map<Account>(newAccount);
        
        _accountRepository.Create(account, newAccount.Pin, newAccount.ConfirmPin);

        var accountReturn = _mapper.Map<GetAccountModel>(account);
        return accountReturn;
    }

    public GetAccountModel GetAllAccount(GetAccountModel getAccount)
    {
        var accounts = _accountRepository.GetAllAcount();
        var cleanedAccounts = _mapper.Map<IList<GetAccountModel>>(accounts);

        return (GetAccountModel)cleanedAccounts;
    }


    public Account Authenticate(Authenticate model)
    {
        var authenticate = _accountRepository.Authenticate(model.AccountNumber, model.Pin);

        return authenticate;
    }



    public GetAccountModel GetByAccountNumber(string AccountNumber)
    {
        var account = _accountRepository.GetByAccountNumber(AccountNumber);
        var cleanedAccounts = _mapper.Map<GetAccountModel>(account);

        return cleanedAccounts;
    }

    public GetAccountModel GetById(int Id)
    {
        var account = _accountRepository.GetById(Id);
        var cleanedAccount = _mapper.Map<GetAccountModel>(account);

        return cleanedAccount;
    }

    public void UpdateAccount(UpdateAccountModel model, string Pin)
    {
        var account = _mapper.Map<Account>(model);
        _accountRepository.Update(account, model.Pin);
    }
}