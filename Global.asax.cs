using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Lab8
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            SavingAccount.WithdrawPenaltyAmount = 10.0;
            SavingAccount.WithdrawPenaltyWaiverBalance = 2000.0;
            CheckingAccount.MaxWithdrawAmount = 200;
        }
    }
}