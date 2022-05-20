using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SavingAccount : Account
{
    public static double WithdrawPenaltyAmount { get; set; }
    public static double WithdrawPenaltyWaiverBalance { get; set; }

   
    public SavingAccount(string name) : base(name)
    {

    }
    public override double GetWithdrawPenaltyAmount()
    {
        if (WithdrawPenaltyWaiverBalance > Balance)
        {
            return WithdrawPenaltyAmount;
        }
        else
        {
            return 0;
        }
           
       
    }


}

