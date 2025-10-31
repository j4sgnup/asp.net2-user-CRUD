using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private UserDAL userDAL = new UserDAL();
    // protected GridView gvUsers;
    // protected Label lblMessage;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        try
        {
            DataTable dt = userDAL.GetAllUsers();
            gvUsers.DataSource = dt;
            gvUsers.DataBind();
        }
        catch (Exception ex)
        {
            ShowMessage("Error loading users: " + ex.Message, false);
        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserForm.aspx");
    }

    protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int userId = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "EditUser")
        {
            Response.Redirect("UserForm.aspx?id=" + userId);
        }
        else if (e.CommandName == "DeleteUser")
        {
            try
            {
                bool success = userDAL.DeleteUser(userId);
                if (success)
                {
                    ShowMessage("User deleted successfully.", true);
                    BindGrid();
                }
                else
                {
                    ShowMessage("Error deleting user.", false);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error deleting user: " + ex.Message, false);
            }
        }
    }

    private void ShowMessage(string message, bool isSuccess)
    {
        lblMessage.Text = message;
        lblMessage.CssClass = isSuccess ? "message success" : "message error";
        lblMessage.Visible = true;
    }
}