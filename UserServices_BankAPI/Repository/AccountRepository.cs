using System.Text;
using UserServices_BankAPI.Models;

namespace UserServices_BankAPI.Repository;


public class AccountRepository : IAccountRepository
{
    private readonly AppDbContext _context;

    public AccountRepository(AppDbContext context)
    {
        _context = context;
    }

    public Account Authenticate(string AccountNumber, string Pin)
    {
        var account = _context.Accounts.Where(c => c.AccountNumberGenerated == AccountNumber).SingleOrDefault();
        if(account == null)
            return null;

        //verify pinHash
        if (!VerifyPinHash(Pin, account.PinHash, account.PinSalt))
            return null;

        return account;
    }


    private static bool VerifyPinHash(string Pin, byte[] pinHash, byte[] pinSalt)
    {
        if (string.IsNullOrWhiteSpace(Pin)) throw new ArgumentNullException("Pin");
        //Let's verify pin
        using(var hmac = new System.Security.Cryptography.HMACSHA512(pinSalt))
        {
            var computedPinHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Pin));
            for (int i = 0; i < computedPinHash.Length; i++)
            {
                if (computedPinHash[i] != pinHash[i]) return false;
            }
        }
        return true;
    }

    public Account Create(Account account, string Pin, string ConfirmPin)
    {
        //This is to crete a new account
        if (_context.Accounts.Any(c => c.Email == account.Email)) 
            throw new ApplicationException("An account already exists with this email");
        
        //Validate pin
        if (!Pin.Equals(ConfirmPin))
            throw new ArgumentException("Pins do maatch", "Pin");

        // Let's harsh/encrypt the pin first
        byte[] pinHash, pinSalt;
        CreatePinHash(Pin, out pinHash, out pinSalt);

        account.PinHash = pinHash;
        account.PinSalt = pinSalt;

        //Let's add new account to db
        _context.Accounts.Add(account);
        _context.SaveChanges();

        return account;

    }

    private static void CreatePinHash(string pin, out byte[] pinHash, out byte[] pinSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            pinSalt = hmac.Key;
            pinHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pin));
        }
    }

    public void Delete(int Id)
    {
        var account = _context.Accounts.Find(Id);
        if (account != null)
        {
            _context.Accounts.Remove(account);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Account> GetAllAcount()
    {
        return _context.Accounts.ToList();
    }

    public Account GetByAccountNumber(string AccountNumber)
    {
        var account = _context.Accounts.Where(c => c.AccountNumberGenerated == AccountNumber).FirstOrDefault();
        if (account == null) return null;

        return account;
    }

    public Account GetById(int Id)
    {
        var account = _context.Accounts.Find(Id);
        if (account == null) return null;

        return account;
    }

    public void Update(Account account, string Pin = null)
    {
        var accountUpdate = _context.Accounts.Where(c => c.Id == account.Id).FirstOrDefault();
        if (accountUpdate == null) throw new ApplicationException("Account does not exist");

        //If it exists let's create the method
        if(!string.IsNullOrWhiteSpace(account.Email))
        {
            //Checks if the email is already in use
            if(_context.Accounts.Any(c => c.Email == account.Email)) throw new ApplicationException("This Email" + account.Email+ "already exists");

            accountUpdate.Email = account.Email;
        }

        //User should be able to change only Email, Phonenumber and Pin
        if(!string.IsNullOrWhiteSpace(account.PhoneNumber))
        {
            //Checks if the Phonenumber is already in use
            if(_context.Accounts.Any(c => c.PhoneNumber == account.PhoneNumber)) throw new ApplicationException("This Email" + account.Email+ "already exists");

            accountUpdate.PhoneNumber = account.PhoneNumber;
        }

        if(!string.IsNullOrWhiteSpace(Pin))
        {
            //Checks if the email is already in use

            byte[] pinHash, pinSalt;
            CreatePinHash(Pin, out pinHash, out pinSalt);

            accountUpdate.PinHash = pinHash;
            accountUpdate.PinSalt = pinSalt;

        }
        accountUpdate.DateLastUpdated = DateTime.Now;

        _context.Update(accountUpdate);
        _context.SaveChanges();
    }
}