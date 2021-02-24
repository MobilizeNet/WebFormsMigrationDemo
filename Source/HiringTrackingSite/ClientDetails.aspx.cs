using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HiringTrackingSite
{
    public partial class ClientDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ClientId"] != null)
                {
                    LoadClientInformation(Convert.ToInt32(Session["ClientId"]));
                }
                else
                {
                    UpdateButton.Visible = false;
                    InsertButton.Visible = true;
                }
            }
        }

        private void LoadClientInformation(int v)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HiringConnectionString"].ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Name, Phone, Email, ContactName, Website FROM Clients Where Id = @Id", conn);
                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = v;
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    IdLabel1.Text = reader.GetInt32(0).ToString();
                    NameTextBox.Text = reader.GetString(1);
                    PhoneTextBox.Text = reader.GetString(2);
                    EmailTextBox.Text = reader.GetString(3);
                    ContactNameTextBox.Text = reader.GetString(4);
                    WebsiteTextBox.Text = reader.GetString(5);
                    UpdateButton.Visible = true;
                    InsertButton.Visible = false;
                }
                else
                {
                    UpdateButton.Visible = false;
                    InsertButton.Visible = true;
                }
            }

        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HiringConnectionString"].ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Clients set Name=@Name, Phone=@Phone, Email=@Email, ContactName=@ContactName, Website=@Website where id = @id", conn);
                cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                cmd.Parameters["@Name"].Value = NameTextBox.Text;
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar);
                cmd.Parameters["@Phone"].Value = PhoneTextBox.Text;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar);
                cmd.Parameters["@Email"].Value = EmailTextBox.Text;
                cmd.Parameters.Add("@ContactName", SqlDbType.VarChar);
                cmd.Parameters["@ContactName"].Value = ContactNameTextBox.Text;
                cmd.Parameters.Add("@Website", SqlDbType.VarChar);
                cmd.Parameters["@Website"].Value = WebsiteTextBox.Text;
                cmd.Parameters.Add("@id", SqlDbType.VarChar);
                cmd.Parameters["@id"].Value = IdLabel1.Text;
                var affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Message", $"<script>alert('Client updated succesfully');</script>");
                }
            }
        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HiringConnectionString"].ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Insert into Clients (Name, Phone, Email, ContactName, Website)  OUTPUT INSERTED.ID " +
                    "  values (@Name, @Phone, @Email, @ContactName, @Website)", conn);
                cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                cmd.Parameters["@Name"].Value = NameTextBox.Text;
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar);
                cmd.Parameters["@Phone"].Value = PhoneTextBox.Text;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar);
                cmd.Parameters["@Email"].Value = EmailTextBox.Text;
                cmd.Parameters.Add("@ContactName", SqlDbType.VarChar);
                cmd.Parameters["@ContactName"].Value = ContactNameTextBox.Text;
                cmd.Parameters.Add("@Website", SqlDbType.VarChar);
                cmd.Parameters["@Website"].Value = WebsiteTextBox.Text;
                var id = cmd.ExecuteScalar();
                IdLabel1.Text = id.ToString();

                ClientScript.RegisterStartupScript(this.GetType(), "Message", $"<script>alert('Client added succesfully');</script>");
            }
        }
    }
}