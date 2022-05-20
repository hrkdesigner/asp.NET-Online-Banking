<%@ Page Title="Customer" Language="C#" MasterPageFile="~/Shared/ACMasterPage.master" AutoEventWireup="True" CodeBehind="AccountManage.aspx.cs" Inherits="CustomerManage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row vertical-margin">
         <div class="col-md-10 col-md-offset-1">
            <h1>Account Management</h1>
         </div>
    </div>
    <br />
    <div class="row form-group">
        <div class="col-md-3 col-md-offset-1">
            <label for="txtCustomerName" id="lblCustomerName">Customer Name: </label>
        </div>
        <div class="col-md-5">
            <asp:TextBox ID="txtCustomerName" runat="server" CssClass="form-control width-75"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtCustomerName" CssClass="error" Display="Static" ErrorMessage="Required!" runat="server"/>
        </div>
    </div>
    <div class="row form-group">
        <div class="col-md-3 col-md-offset-1">
            <label id="lblInitialDeposit" for="txtInitialDeposit">Initial Deposit:</label>
        </div>
        <div class="col-md-5">
            <asp:TextBox ID="txtInitialDeposit" runat="server" CssClass="form-control width-75" EnableViewState="false"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtInitialDeposit"  CssClass="error" Display="Static" ErrorMessage="Required!" runat="server"/>
            <asp:CompareValidator ID="CompareValidation1" ControlToValidate="txtInitialDeposit" Type="Currency" CssClass="error" Operator="GreaterThan" ValueToCompare="0" Display="Static" ErrorMessage="Must be greater than 0!" runat="server" />
        </div>
    </div>
    <div class="row form-group">
        <div class="col-md-3 col-md-offset-1">
            <label id="lblAccountType" for="drpAccountType">Account Type:</label>
        </div>
        <div class="col-md-5">
            <asp:DropDownList runat="server" ID="drpAccountType" CssClass="form-control width-75">
                <asp:ListItem Value="-1">Select ... </asp:ListItem>
                <asp:ListItem Value="CheckingAccount">Checking Account</asp:ListItem>
                <asp:ListItem Value="SavingAccount">Saving Account</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="drpAccountType"  CssClass="error" Display="Dynamic" ErrorMessage="Must select one!" runat="server" InitialValue="-1"/>
        </div>
    </div>
    <br />
    <div class="row vertical-margin">
         <div class="col-md-4 col-md-offset-1">
            <asp:Button ID="btnAddCustomer" runat="server" onclick="btnAddAccount_Click" Text="Add Account" cssClass="btn btn-primary" /> 
         </div>
    </div>
    <div class="row vertical-margin">
         <div class="col-md-10 col-md-offset-1">
            <h3>The following account(s) are currently in the system:</h3>
         </div>
    </div>
    <div class="row vertical-margin">
         <div class="col-md-10 col-md-offset-1">
            <asp:Table runat="server" ID="tblCourses" CssClass="table" EnableViewState="false">
            <asp:TableRow>
                <asp:TableHeaderCell>Account Number</asp:TableHeaderCell>
                <asp:TableHeaderCell>Owner Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Account Type</asp:TableHeaderCell>  
                <asp:TableHeaderCell>Account Balance</asp:TableHeaderCell>
            </asp:TableRow>
            </asp:Table>
        </div>
     </div>
</asp:Content>

