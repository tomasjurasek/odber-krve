using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuctionWebApp.Database;

namespace AuctionWebApp.Form
{
    public partial class Doktor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DoktorTable table = new DoktorTable();
            table.PridejBonusy(Int32.Parse(ListCategory.SelectedValue.ToString()));
            GridView1.DataBind();
            
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            GridView1.DataBind();
        }

        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string s = e.Row.Cells[4].Text;
                e.Row.Cells[7].Text += " Kč";
                if (s == "True")
                    e.Row.Cells[4].Text = "Ano";
                else
                    e.Row.Cells[4].Text = "Ne";
            }
        }
    }
}