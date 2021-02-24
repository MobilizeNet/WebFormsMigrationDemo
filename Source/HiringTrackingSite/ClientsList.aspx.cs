using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HiringTrackingSite
{
    public partial class ClientsListForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientsDataSource.SelectCommand = "Select * from Clients";
        }

        protected void Details_Click(object sender, EventArgs e)
        {
            Session["ClientId"] = ((LinkButton)sender).CommandArgument;

            Response.Redirect("ClientDetails.aspx", true);
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            List<string> filters = new List<string>();
            if (!string.IsNullOrWhiteSpace(IdFilter.Text))
            {
                filters.Add("Id=" + IdFilter.Text);
            }
            if (!string.IsNullOrWhiteSpace(NameFilter.Text))
            {
                filters.Add($"Name like '%{NameFilter.Text}%'");
            }
            if (!string.IsNullOrWhiteSpace(PhoneFilter.Text))
            {
                filters.Add($"Phone like '%{PhoneFilter.Text}%'");
            }
            if (!string.IsNullOrWhiteSpace(EmailFilter.Text))
            {
                filters.Add($"Email like '%{EmailFilter.Text}%'");
            }
            if (!string.IsNullOrWhiteSpace(ContactNameFilter.Text))
            {
                filters.Add($"ContactName like '%{ContactNameFilter.Text}%'");
            }
            if (!string.IsNullOrWhiteSpace(WebsiteFilter.Text))
            {
                filters.Add($"Website like '%{WebsiteFilter.Text}%'");
            }

            string filter = string.Join(" AND ", filters.ToArray());

            if (!string.IsNullOrWhiteSpace(filter))
            {
                filter = " WHERE " + filter;
            }

            ClientsDataSource.SelectCommand += filter;
            DataList1.DataBind();

        }

        protected void AddNewButton_Click(object sender, EventArgs e)
        {
            Session["ClientId"] = null;
            Response.Redirect("ClientDetails", true);
        }
    }
}