using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPracticeProject1._17
{
    public partial class Student1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SmtBtn_Click(object sender, EventArgs e)
        {
            // Generate a unique Student ID (You might have your own logic for this)
            string studentID = Guid.NewGuid().ToString();

            // Retrieve connection string from web.config
            string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;

            // SQL query to insert a new student into the database
            string query = "INSERT INTO Students (StudentID, FirstName, LastName, DateOfBirth) VALUES (@StudentID, @FirstName, @LastName, @DateOfBirth)";

            // Parameters for the SQL query
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@StudentID", studentID);
            parameters[1] = new SqlParameter("@FirstName", TxtBx2.Text);
            parameters[2] = new SqlParameter("@LastName",TxtBx3.Text);
            parameters[3] = new SqlParameter("@DateOfBirth", Convert.ToDateTime(TxtBx4.Text)); // Assuming txtDateOfBirth is a TextBox control

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters);

                        connection.Open();

                        command.ExecuteNonQuery();

                        Response.Write("<script>alert('Student added successfully');</script>");
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred while adding the student: " + ex.Message + "');</script>");
            }
        }
    }
}


