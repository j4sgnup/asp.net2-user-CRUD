using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Data Access Layer for User operations - Classic ASP.NET 2.0 style
/// </summary>
public class UserDAL
{
    private string connectionString;
    
    public UserDAL()
    {
        connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    }
    
    public DataTable GetAllUsers()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string sql = "SELECT Id, UserName, FirstName, LastName, Email, IsActive FROM Users ORDER BY LastName, FirstName";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(dt);
        }
        return dt;
    }
    
    public DataRow GetUserById(int userId)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string sql = "SELECT Id, UserName, FirstName, LastName, Email, IsActive FROM Users WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", userId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
        }
        
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0];
        }
        else
        {
            return null;
        }
    }
    
    public bool InsertUser(string userName, string firstName, string lastName, string email, bool isActive)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string sql = "INSERT INTO Users (UserName, FirstName, LastName, Email, IsActive) VALUES (@UserName, @FirstName, @LastName, @Email, @IsActive)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@IsActive", isActive);
            
            try
            {
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
    
    public bool UpdateUser(int id, string userName, string firstName, string lastName, string email, bool isActive)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string sql = "UPDATE Users SET UserName = @UserName, FirstName = @FirstName, LastName = @LastName, Email = @Email, IsActive = @IsActive WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@IsActive", isActive);
            
            try
            {
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
    
    public bool DeleteUser(int id)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string sql = "DELETE FROM Users WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            
            try
            {
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
    
    public bool UserNameExists(string userName, int excludeId = 0)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string sql = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName AND Id <> @ExcludeId";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@ExcludeId", excludeId);
            
            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
    }
}