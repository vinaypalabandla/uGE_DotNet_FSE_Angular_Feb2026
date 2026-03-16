using System.Net;
using System.Security.Cryptography.X509Certificates;


class BankAccount
{
    private long _accountNumber;
    private double _accountBalance;

    public long AccountNumber { get; set; }
    public double AccountBalance { get; private set; }

    public void Deposit(double amount)
    {
        if (amount < 0)
        {
            Console.WriteLine("Invalid deposit amount");
            return;
        }
        _accountBalance = _accountBalance + amount;
        Console.WriteLine("Current Deposit Balance = " + _accountBalance);
    }
    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid withDrawal amount");
            return;
        }
        if (amount > _accountBalance)
        {
            Console.WriteLine("InSufficient Balance in Account");
            return;
        }
        // Console.WriteLine("Withdrawl Amount: " +  (_accountBalance - amount));
        _accountBalance = _accountBalance - amount;
        Console.WriteLine("Current Balance = " + _accountBalance);


    }
}

internal class Person
{
    static void Main(string[] args)
    {
        BankAccount acc = new BankAccount();
        acc.AccountNumber = 4875634;
        acc.Deposit(5000);
        acc.Withdraw(2000);
    }
}
