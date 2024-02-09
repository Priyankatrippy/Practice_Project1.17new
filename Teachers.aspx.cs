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
    public partial class Teachers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string teacherId = lblTeacherId.Text;
            string firstName = lblFirstName.Text;
            string lastName = lblLastName.Text;
            string email = lblEmail.Text;
            string phone = lblPhone.Text;

           
            string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Teachers (TeacherId, FirstName, LastName, Email, Phone) VALUES (@TeacherId, @FirstName, @LastName, @Email, @Phone)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TeacherId", teacherId);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Phone", phone);

                connection.Open();
                command.ExecuteNonQuery();
            }

            Response.Write("<script>alert('Teacher added successfully.');</script>");
        }

    }
}
