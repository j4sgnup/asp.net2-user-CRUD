# User Management System (ASP.NET 2.0)

## Prerequisites

To run this project on Windows 11 Home Edition, you need:

- **.NET Framework 2.0**
- **Visual Studio (any edition that supports ASP.NET 2.0 projects)**
- **IIS Express** (or full IIS)
- **SQL Server Express 2019**
- **SQL Server Management Studio (SSMS)**
- (Optional) **HeidiSQL** for database management

## Setup Instructions

1. **Clone the repository:**
   ```
   git clone https://github.com/yourusername/your-repo-name.git
   ```
2. **Open the solution in Visual Studio.**
3. **Restore any missing NuGet packages** (if prompted).
4. **Install SQL Server Express 2019** and create a database named `UserManagement`.
5. **Update the connection string** in `Web.config` to match your SQL Server setup:
   ```xml
   <connectionStrings>
     <add name="DefaultConnection" 
          connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=UserManagement;Integrated Security=True" 
          providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```
6. **Run the SQL scripts** (if provided) to create the required tables.
7. **Build and run the project** using Visual Studio or IIS Express.

## Notes

- Make sure SQL Server Express is running and accessible.
- Use SSMS or HeidiSQL to manage your database.
- If you need to change the database user/password, update `Web.config`.
- For troubleshooting, check firewall settings and SQL Server configuration (TCP/IP enabled).

## Optional Tools

- [HeidiSQL](https://www.heidisql.com/download.php) for easy database management
- [SSMS](https://aka.ms/ssms) for advanced SQL Server administration

---

Feel free to open issues or contribute to this project!
