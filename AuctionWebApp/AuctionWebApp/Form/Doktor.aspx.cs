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
    }
}