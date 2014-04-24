using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionWebApp.Database
{
    public class Stav
    {
        private int mIdStav;
        private string mStav;

        public int IdStav
        {
            get
            {
                return mIdStav;
            }
            set
            {
                mIdStav = value;
            }

        }

        public string NazevStavu
        {
            get
            {
                return mStav;
            }
            set
            {
                mStav = value;
            }

        }
    }
}