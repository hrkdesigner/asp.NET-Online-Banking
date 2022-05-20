using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Account
{
    public double Balance { get; private set; }
    public string OwnerName { get; }
    public string AccountNumber { get; }

    protected Account() { }
    protected Account(string name)
    {
        OwnerName = name;

        Random rand = new Random();
        AccountNumber = "A" + rand.Next(1000, 9999);
    }
    public virtual void Withdraw(double amount)
    {
        if (Balance < amount)
            throw new Exception($"Insufficient Fund: current balance ${Balance}, withdraw amount ${amount}.");

        Balance -= amount;
    }
    public virtual double GetWithdrawPenaltyAmount()
    {
        return 0.0;
    }
    public virtual void Deposit(double amount)
    {
        Balance += amount;
    }
    public string AccountType
    {
        get
        {
            if (this.GetType().Name == "SavingAccount")
            {
                return "Saving Account";
            }
            else if (this.GetType().Name == "CheckingAccount")
            {
                return "Checking Account";
            }
            else
            {
                throw new Exception("Unsupported Account Type");
            }
        }
    }
    public override string ToString()
    {
        return $"{AccountNumber} - {OwnerName} ({AccountType})";
    }
}

