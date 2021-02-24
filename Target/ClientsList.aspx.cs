namespace HiringTrackingSite
{
    using System;
    using System.Collections.Generic;
    using Mobilize.WebMap.Common.Attributes;

    [Observable]
    public partial class ClientsListForm : Mobilize.Web.UI.Page
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            ClientsDataSource.SelectCommand = "Select * from Clients";
            this.DataList1.DataBind();
        }

        protected void Details_ClickHandler(object sender, EventArgs e)
        {
            Session["ClientId"] = CommandArgument;
            this.ExtApp().NavigateTo(new ClientDetails());
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
            this.ExtApp().NavigateTo(new ClientDetails());
        }

    }
}