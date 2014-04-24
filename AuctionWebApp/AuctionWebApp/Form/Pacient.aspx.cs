using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuctionWebApp.Form
{
    public partial class Pacient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Pacient p = new Pacient();
            //GridView2.DataBind = p.zaznamy;
            
        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {

            //FindControl("krev").ToString();
        }

        protected void krev1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //String SelectedValue = (sender as DropDownList).SelectedValue;
            
            //Label lblResult = ((Label)FindControl("krev"));
            //lblResult.Text = SelectedValue;
        }

        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // GridView2.DataBind = 
        }
    }
}