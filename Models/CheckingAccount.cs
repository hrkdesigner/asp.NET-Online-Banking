using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CheckingAccount : Account
{
    public static double MaxWithdrawAmount { get; set; }

 
    public CheckingAccount(string name) : base(name)
    {

    }
    public override void Withdraw(double amount)
    {
        if (MaxWithdrawAmount < amount)
            throw new Exception($"Exceed Max Withdraw Amount: ${MaxWithdrawAmount}.");

        base.Withdraw(amount);
        return;
    }

}

