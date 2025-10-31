<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Management System</title>
    <style type="text/css">
        body { font-family: Arial, sans-serif; margin: 20px; background-color: #f5f5f5; }
        .header { background-color: #003366; color: white; padding: 15px; margin-bottom: 20px; }
        .header h1 { margin: 0; font-size: 24px; }
        .content { background-color: white; padding: 20px; border: 1px solid #ccc; }
        .grid { border-collapse: collapse; width: 100%; margin-top: 10px; }
        .grid th, .grid td { border: 1px solid #ddd; padding: 8px; text-align: left; }
        .grid th { background-color: #f2f2f2; font-weight: bold; }
        .grid tr:nth-child(even) { background-color: #f9f9f9; }
        .button { padding: 5px 10px; margin: 2px; background-color: #003366; color: white; border: none; cursor: pointer; }
        .button:hover { background-color: #004080; }
        .message { padding: 10px; margin: 10px 0; border-radius: 4px; }
        .success { background-color: #d4edda; color: #155724; border: 1px solid #c3e6cb; }
        .error { background-color: #f8d7da; color: #721c24; border: 1px solid #f5c6cb; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h1>User Management System</h1>
            <asp:Button ID="btnAddNew" runat="server" Text="Add New User" CssClass="button" OnClick="btnAddNew_Click" />
        </div>
        
        <div class="content">
            <asp:Label ID="lblMessage" runat="server" CssClass="message" Visible="false"></asp:Label>
            
            <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" 
                CssClass="grid" DataKeyNames="Id" EmptyDataText="No users found." OnRowCommand="gvUsers_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="UserName" HeaderText="Userer Name" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:TemplateField HeaderText="Active">
                        <ItemTemplate>
                            <%# (bool)Eval("IsActive") ? "Yes" : "No" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" 
                                CommandName="EditUser" CommandArgument='<%# Eval("Id") %>' 
                                CssClass="button" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                                CommandName="DeleteUser" CommandArgument='<%# Eval("Id") %>' 
                                CssClass="button" OnClientClick="return confirm('Are you sure you want to delete this user?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>