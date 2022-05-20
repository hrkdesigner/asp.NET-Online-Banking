using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Withdraw : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!this.IsPostBack)
        {
            List<Account> listOfUsers = (List<Account>)Session["user"];
            int index = 0;

            if (listOfUsers != null)
            {
                foreach (Account user in listOfUsers)
                {
                    drpAccount.Items.Add(user.ToString());
                    index++;

                    // update checbox
                    drpAccount.Items[index].Value = user.AccountNumber.ToString();
                }
            }else
            {
                Response.Redirect("AccountManage.aspx");
            }

        }

    }
    protected void drpAccount_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (drpAccount.SelectedItem.Value != "-1")
        {
            List<Account> listOfUsers = (List<Account>)Session["user"];
            foreach (Account s in listOfUsers)
            {
                if (s.AccountNumber == drpAccount.SelectedItem.Value)
                {
                    txtCurrentBalance.Text = s.Balance.ToString();
                    if (s.GetWithdrawPenaltyAmount() > 0)
                    {
                        lblInfo.Text = $"${s.GetWithdrawPenaltyAmount()} penalty will apply.";
                    }
                }

            }

        }
    }
    protected void btnWithdraw_Click(object sender, EventArgs e)
    {

       
        List<Account> selectedAccount = new List<Account>();
        List<Account> result = (List<Account>)Session["user"];
        foreach (ListItem listItem in drpAccount.Items)
        {
            if (listItem.Selected == true)
            {
               
                foreach (Account s in result)
                {
                    if (listItem.Value.ToString() == s.AccountNumber)
                    {
                            s.Withdraw(double.Parse(txtWithdrawAmount.Text));
                            txtCurrentBalance.Text = s.Balance.ToString();
                            lblInfo.Text = $"TRANSACTION COMPLETED, ${txtWithdrawAmount.Text} Deducted from your account.";
                            txtWithdrawAmount.Text = "";
                            selectedAccount.Add(s);
                            Session["user"] = selectedAccount;

                            
                    }

                }
            }
        }


    }

}