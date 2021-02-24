namespace HiringTrackingSite
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using Mobilize.WebMap.Common.Attributes;

    [Observable]
    public partial class PositionDetailsForm : Mobilize.Web.UI.Page
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            LoadClientsList();
            if (!IsPostBack)
            {
                if (Session["PositionId"] != null)
                {
                    LoadPositionsInformation(Convert.ToInt32(Session["PositionId"]));
                }
                else
                {
                    UpdateButton.Visible = false;
                    InsertButton.Visible = true;
                }
            }
        }

        private void LoadClientsList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HiringConnectionString"].ToString().DataDirectory();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Name FROM Clients", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ClientCombo.DataSource = dt;
                ClientCombo.DisplayMember = "Name";
            }
        }

        private void LoadPositionsInformation(int v)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HiringConnectionString"].ToString().DataDirectory();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Name, Description, StartDate, Deadline, Hired, IdClient, ClientContactName, ClientContactPhone,ClientContactEmail from Positions Where Id = @Id", conn);
                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = v;
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    IdLabel1.Text = reader.GetInt32(0).ToString();
                    NameTextBox.Text = reader.GetString(1);
                    DescriptionTextBox.Text = reader.GetString(2);
                    StartDateTextBox.Text = reader.GetDateTime(3).ToString("yyyy-MM-dd");
                    DeadlineTextBox.Text = reader.GetDateTime(4).ToString("yyyy-MM-dd");
                    HiredCheckbox.Checked = reader.GetBoolean(5);
                    ClientCombo.SelectedValue = reader.GetInt32(6).ToString();
                    ClientContactNameTextBox.Text = reader.GetString(7);
                    ClientContactPhoneTextBox.Text = reader.GetString(8);
                    ClientContactEmailTextBox.Text = reader.GetString(9);
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
            string connectionString = ConfigurationManager.ConnectionStrings["HiringConnectionString"].ToString().DataDirectory();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Positions set Name=@Name, Description=@Description, StartDate=@StartDate, Deadline=@Deadline, Hired=@Hired, ClientContactName=@ClientContactName, ClientContactPhone=@ClientContactPhone, ClientContactEmail=@ClientContactEmail where id = @id", conn);
                cmd.AddNewParameter("@Name", SqlDbType.VarChar, NameTextBox.Text);
                cmd.AddNewParameter("@Description", SqlDbType.VarChar, DescriptionTextBox.Text);
                cmd.AddNewParameter("@StartDate", SqlDbType.Date, StartDateTextBox.Text);
                cmd.AddNewParameter("@Deadline", SqlDbType.Date, DeadlineTextBox.Text);
                cmd.AddNewParameter("@Hired", SqlDbType.Bit, HiredCheckbox.Checked);
                cmd.AddNewParameter("@ClientContactName", SqlDbType.VarChar, ClientContactNameTextBox.Text);
                cmd.AddNewParameter("@ClientContactPhone", SqlDbType.VarChar, ClientContactPhoneTextBox.Text);
                cmd.AddNewParameter("@ClientContactEmail", SqlDbType.VarChar, ClientContactEmailTextBox.Text);
                cmd.AddNewParameter("@id", SqlDbType.Int, IdLabel1.Text);
                var affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows == 1)
                {
                    ClientScript.SendScript("alert('Position updated succesfully');");
                }
            }
        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HiringConnectionString"].ToString().DataDirectory();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Insert into Positions(Name, Description, StartDate, Deadline, Hired, ClientContactName, ClientContactPhone, ClientContactEmail, IdClient) OUTPUT INSERTED.ID " +
                "  values (@Name, @Description, @StartDate, @Deadline, @Hired, @ClientContactName, @ClientContactPhone, @ClientContactEmail, @IdClient)", conn);
                cmd.AddNewParameter("@Name", SqlDbType.VarChar, NameTextBox.Text);
                cmd.AddNewParameter("@Description", SqlDbType.VarChar, DescriptionTextBox.Text);
                cmd.AddNewParameter("@StartDate", SqlDbType.Date, StartDateTextBox.Text);
                cmd.AddNewParameter("@Deadline", SqlDbType.Date, DeadlineTextBox.Text);
                cmd.AddNewParameter("@Hired", SqlDbType.Bit, HiredCheckbox.Checked);
                cmd.AddNewParameter("@ClientContactName", SqlDbType.VarChar, ClientContactNameTextBox.Text);
                cmd.AddNewParameter("@ClientContactPhone", SqlDbType.VarChar, ClientContactPhoneTextBox.Text);
                cmd.AddNewParameter("@ClientContactEmail", SqlDbType.VarChar, ClientContactEmailTextBox.Text);
                cmd.AddNewParameter("@IdClient", SqlDbType.Int, ClientCombo.SelectedValue);
                var id = cmd.ExecuteScalar();
                IdLabel1.Text = id.ToString();
                ClientScript.SendScript($"alert('Position added succesfully');");
            }
        }

    }
}