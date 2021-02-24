using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HiringTrackingSite
{
    public partial class PositionsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PositionsDataSource.SelectCommand = "SELECT Positions.*, Clients.Name as ClientName FROM Positions left join Clients on positions.idclient = clients.id";
        }

        protected void Details_Click(object sender, EventArgs e)
        {
            Session["PositionId"] = ((LinkButton)sender).CommandArgument;

            Response.Redirect("PositionDetails.aspx", true);
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
            Response.Redirect("PositionDetails", true);
        }
    }
}