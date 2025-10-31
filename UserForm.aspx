<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="UserForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Form</title>
    <style type="text/css">
        body { font-family: Arial, sans-serif; margin: 20px; background-color: #f5f5f5; }
        .header { background-color: #003366; color: white; padding: 15px; margin-bottom: 20px; }
        .header h1 { margin: 0; font-size: 24px; }
        .content { background-color: white; padding: 20px; border: 1px solid #ccc; }
        .form-table { border-collapse: collapse; }
        .form-table td { padding: 8px; vertical-align: top; }
        .form-table .label { font-weight: bold; width: 120px; }
        .textbox { width: 200px; padding: 4px; border: 1px solid #ccc; }
        .button { padding: 8px 15px; margin: 5px; background-color: #003366; color: white; border: none; cursor: pointer; }
        .button:hover { background-color: #004080; }
        .message { padding: 10px; margin: 10px 0; border-radius: 4px; }
        .success { background-color: #d4edda; color: #155724; border: 1px solid #c3e6cb; }
        .error { background-color: #f8d7da; color: #721c24; border: 1px solid #f5c6cb; }
        .validator { color: #721c24; font-size: 12px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h1><asp:Label ID="lblTitle" runat="server" Text="Add New User"></asp:Label></h1>
        </div>
        
        <div class="content">
            <asp:Label ID="lblMessage" runat="server" CssClass="message" Visible="false"></asp:Label>
            
            <table class="form-table">
                <tr>
                    <td class="label">User Name:</td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" 
                            ControlToValidate="txtUserName" ErrorMessage="User Name is required" 
                            CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cvUserName" runat="server" 
                            ControlToValidate="txtUserName" ErrorMessage="User Name already exists" 
                            CssClass="validator" Display="Dynamic"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td class="label">First Name:</td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" 
                            ControlToValidate="txtFirstName" ErrorMessage="First Name is required" 
                            CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="label">Last Name:</td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" 
                            ControlToValidate="txtLastName" ErrorMessage="Last Name is required" 
                            CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="label">Email:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                            ControlToValidate="txtEmail" ErrorMessage="Email is required" 
                            CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server"                
                            ControlToValidate="txtEmail" ErrorMessage="Invalid email format" 
                            CssClass="validator" Display="dynamic" 
                            ValidationExpression="^[\w\.-]+@[\w\.-]+\.\w{2,}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="label">Active:</td>
                    <td>
                        <asp:CheckBox ID="chkIsActive" runat="server" Checked="true" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top: 20px;">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                            CssClass="button" CausesValidation="false" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
            
            <asp:HiddenField ID="hfUserId" runat="server" Value="0" />
        </div>
    </form>
</body>
</html>