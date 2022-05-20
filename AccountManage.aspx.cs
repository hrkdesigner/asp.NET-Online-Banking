using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerManage : System.Web.UI.Page
{
    List<Account> users = new List<Account>();
    protected void Page_Load(object sender, EventArgs e)
    {
        

        
        if (Session["user"] == null)
        {
            Session["user"] = new List<Account>();
            ShowAccounts((List<Account>)Session["user"]);

        }
        else
        {
            users = Session["user"] as List<Account>;
            if (!IsPostBack)
            {
                    users = Session["user"] as List<Account>;
                    ShowAccounts(users);
            }
        }

    }

    protected void btnAddAccount_Click(object sender, EventArgs e)
    {
       
        if (!IsValid) return;

        if (drpAccountType.SelectedValue == "CheckingAccount")
        {
            Account s = new CheckingAccount(txtCustomerName.Text);
            
            s.Deposit(double.Parse(txtInitialDeposit.Text));
            users.Add(s);
        }
        if (drpAccountType.SelectedValue == "SavingAccount")
        {
            Account s = new SavingAccount(txtCustomerName.Text);
            s.Deposit(double.Parse(txtInitialDeposit.Text));
            users.Add(s);
        }
        drpAccountType.SelectedValue = "-1";
        txtCustomerName.Text = "";
        txtInitialDeposit.Text = "";
        Session["user"] = users;

        if (users.Count != 0)
        {
            users = Session["user"] as List<Account>;
            ShowAccounts(users);
        }

    }


    private void ShowAccounts(List<Account> accounts)
    {
        if (accounts.Count == 0)
        {
            TableRow row = new TableRow();
            tblCourses.Rows.Add(row);

            TableCell cell = new TableCell();
            row.Cells.Add(cell);

            cell.Text = "No account in the system yet";
            cell.ForeColor = System.Drawing.Color.Red;
            cell.ColumnSpan = 4;   
        }
        else
        {
            foreach (Account ac in accounts)
            {
                TableRow row = new TableRow();
                tblCourses.Rows.Add(row);

                TableCell cell = new TableCell();
                cell.Text = ac.AccountNumber;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = ac.OwnerName;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = ac.AccountType;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = ac.Balance.ToString("C2");
                row.Cells.Add(cell);
            }
        }
    }

}