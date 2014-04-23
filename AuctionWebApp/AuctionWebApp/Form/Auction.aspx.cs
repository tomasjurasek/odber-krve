using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuctionWebApp.Form
{
    public partial class Auction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DetailsViewAuction_OnDataBound(object sender, EventArgs e)
        {
            DetailsViewAuction.Rows[0].Enabled = false;   // idAuction
            DetailsViewAuction.Rows[9].Enabled = false;  // max_bid_value
            DetailsViewAuction.Rows[10].Enabled = false;  // max_bid_user
        }
    }
}