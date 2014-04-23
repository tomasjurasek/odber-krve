using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuctionWebApp.Form
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void DetailsViewCategory_OnDataBound(object sender, EventArgs e)
        {
            // DetailsViewCategory.Rows[0].Visible = false;
            DetailsViewCategory.Rows[0].Enabled = false;
        }
    }
}