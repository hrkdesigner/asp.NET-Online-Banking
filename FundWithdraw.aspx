<%@ Page Language="C#"  MasterPageFile="~/Shared/ACMasterPage.master" AutoEventWireup="True" CodeBehind="FundWithdraw.aspx.cs" Inherits="Withdraw" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
         <div class="col-md-6 col-md-offset-1">
             <h1>Withdraw Fund</h1>
         </div>
    </div>
    <br />
    <div class="row form-group">
        <div class="col-md-2 col-md-offset-1">
            <label for="drpAccount" id="lblAccount">Account: </label>
        </div>
        <div class="col-md-5">
            <asp:DropDownList runat="server" ID="drpAccount" CssClass="form-control width-75" OnSelectedIndexChanged="drpAccount_SelectedIndexChanged" AutoPostBack="true">
                 <asp:ListItem Text="Select ..." Value="-1" />
            </asp:DropDownList>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="drpAccount" InitialValue="-1" CssClass="error" Display="Dynamic" ErrorMessage="Required!" runat="server"/>
        </div>
    </div>
    <div class="row  form-group">
        <div class="col-md-2 col-md-offset-1">
            <label for="lblCheckingBalance">Current Balance: </label>
        </div>
        <div class="col-md-5">
            <asp:TextBox runat="server" ID="txtCurrentBalance" CssClass="form-control width-75" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
    <div class="row vertical-margin form-group">
        <div class="col-md-2 col-md-offset-1">
            <label id="lblAmount" for="txtWithdrawAmount">Withdraw Amount:</label>
        </div>
        <div class="col-md-5">
            <asp:TextBox runat="server" ID="txtWithdrawAmount" CssClass="form-control width-75"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtWithdrawAmount"  CssClass="error" Display="Dynamic" ErrorMessage="Required!" runat="server"/>
            <asp:CompareValidator ID="cprVldAmount" ControlToValidate="txtWithdrawAmount" Type="Currency" CssClass="error" Operator="GreaterThan" ValueToCompare="0" Display="Dynamic" ErrorMessage="Must be greater than 0!" runat="server" />   
        </div>
    </div>
    <br />
    <div class="row vertical-margin">
         <div class="col-md-10 col-md-offset-1">
            <asp:Button ID="btnWithdraw" runat="server" onclick="btnWithdraw_Click" Text="Withdraw" cssClass="btn btn-primary" /> 
            &nbsp;<asp:Label ID="lblInfo" runat="server" CssClass="alert-info"></asp:Label>
         </div>
    </div>
</asp:Content>
