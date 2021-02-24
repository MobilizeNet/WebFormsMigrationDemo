namespace HiringTrackingSite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Mobilize.WebMap.Common.Attributes;

    [Observable]
    public partial class PositionsList : Mobilize.Web.UI.Page
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            PositionsDataSource.SelectCommand = "SELECT Positions.*, Clients.Name as ClientName FROM Positions left join Clients on positions.idclient = clients.id";
            this.DataList1.DataBind();
        }

        protected void Details_ClickHandler(object sender, EventArgs e)
        {
            Session["PositionId"] = CommandArgument;
            this.ExtApp().NavigateTo(new PositionDetailsForm());
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            List<string> filters = new List<string>();
            if (!string.IsNullOrWhiteSpace(IdFilter.Text))
            {
                filters.Add("Id=" + IdFilter.Text);
            }

            string filter = string.Join(" AND ", filters.ToArray());

            if (!string.IsNullOrWhiteSpace(filter))
            {
                filter = " WHERE " + filter;
            }

            PositionsDataSource.SelectCommand += filter;
            DataList1.DataBind();

        }

        protected void AddNewButton_Click(object sender, EventArgs e)
        {
            Session["PositionId"] = null;
            this.ExtApp().NavigateTo(new PositionDetailsForm());
        }

    }
}