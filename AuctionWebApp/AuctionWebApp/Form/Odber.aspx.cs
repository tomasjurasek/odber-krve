using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuctionWebApp.Database;

namespace AuctionWebApp.Form
{
    public partial class Odber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            OdberTable table = new OdberTable();
            table.ZkontrolujOdbery();
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            OdberTable table = new OdberTable();
            table.NakazeneOdbery();
            GridView1.DataBind();
        }

        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            GridView1.DataBind();
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            GridView1.DataBind();
            
        }

        protected void ObjectDataSource2_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            Label1.Text = e.ReturnValue.ToString();
        }
    }
}