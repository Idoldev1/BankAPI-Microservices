using AutoMapper;
using UserServices_BankAPI.Dtos;
using UserServices_BankAPI.Models;

namespace UserServices_BankAPI.Profiles;


public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<RegisterNewAccountModel, Account>();

        CreateMap<UpdateAccountModel, Account>();

        CreateMap<Account, GetAccountModel>();
        CreateMap<GetAccountModel, Account>();
    }
}