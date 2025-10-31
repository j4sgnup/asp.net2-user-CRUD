using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserForm : System.Web.UI.Page
{
    private UserDAL userDAL = new UserDAL();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string userIdParam = Request.QueryString["id"];
            if (!String.IsNullOrEmpty(userIdParam))
            {
                int userId = Convert.ToInt32(userIdParam);
                LoadUser(userId);
                lblTitle.Text = "Edit User";
            }
        }
    }

    private void LoadUser(int userId)
    {
        try
        {
            DataRow userRow = userDAL.GetUserById(userId);
            if (userRow != null)
            {
                hfUserId.Value = userRow["Id"].ToString();
                txtUserName.Text = userRow["UserName"].ToString();
                txtFirstName.Text = userRow["FirstName"].ToString();
                txtLastName.Text = userRow["LastName"].ToString();
                txtEmail.Text = userRow["Email"].ToString();
                chkIsActive.Checked = Convert.ToBoolean(userRow["IsActive"]);
            }
            else
            {
                ShowMessage("User not found.", false);
            }
        }
        catch (Exception ex)
        {
            ShowMessage("Error loading user: " + ex.Message, false);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                int userId = Convert.ToInt32(hfUserId.Value);
                string userName = txtUserName.Text.Trim();
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                string email = txtEmail.Text.Trim();
                bool isActive = chkIsActive.Checked;

                bool success = false;

                if (userId == 0)
                {
                    // Add new user
                    success = userDAL.InsertUser(userName, firstName, lastName, email, isActive);
                }
                else
                {
                    // Update existing user
                    success = userDAL.UpdateUser(userId, userName, firstName, lastName, email, isActive);
                }

                if (success)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    ShowMessage("Error saving user. Please try again.", false);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error saving user: " + ex.Message, false);
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void cvUserName_ServerValidate(object source, ServerValidateEventArgs args)
    {
        int userId = Convert.ToInt32(hfUserId.Value);
        args.IsValid = !userDAL.UserNameExists(args.Value, userId);
    }

    private void ShowMessage(string message, bool isSuccess)
    {
        lblMessage.Text = message;
        lblMessage.CssClass = isSuccess ? "message success" : "message error";
        lblMessage.Visible = true;
    }
}