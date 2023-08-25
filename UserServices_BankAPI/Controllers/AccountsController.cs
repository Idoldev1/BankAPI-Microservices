using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using UserServices_BankAPI.Dtos;
using UserServices_BankAPI.Models;
using UserServices_BankAPI.Services;

namespace UserServices_BankAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private IServices _services;

    public AccountsController(IServices services)
    {
        _services = services;
    }



    [HttpPost]
    [Route("register_new_account")]
    public IActionResult Create([FromBody] RegisterNewAccountModel createAccount)
    {
        if (!ModelState.IsValid)
            return BadRequest(createAccount);

        return Ok("Successfully created an account");
    }


    [HttpGet]
    [Route("get_all_accounts")]
    public IActionResult GetAllAccount( GetAccountModel getAllAccount)
    {
        return (IActionResult)getAllAccount;
    }


    [HttpPost]
    [Route("authenticate")]
    public IActionResult Authenticate([FromBody] Authenticate model)
    {
        if (model == null)
            return BadRequest(ModelState);

        _services.AccountServices.Authenticate(model);
        return Ok();
    }



    [HttpGet]
    [Route("get_by_account_number")]
    public IActionResult GetByAccountNumber(string AccountNumber)
    {
        if (!Regex.IsMatch(AccountNumber, @"^[0][1-9]\d{9}$|^[1-9]\d{9}$"))
            return BadRequest("Account Number must be 10 digits only");

        var account = _services.AccountServices.GetByAccountNumber(AccountNumber);

        return Ok(account);
    }


    [HttpGet]
    [Route("get_account_by_Id")]
    public IActionResult GetAccountById(int Id)
    {
        var account = _services.AccountServices.GetById(Id);
        return Ok(account);
    }



    [HttpPut]
    [Route("update")]
    public IActionResult UpdateAccount([FromBody] UpdateAccountModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(model);
            
        //_services.AccountServices.UpdateAccount(model);
        return Ok();
    }
}