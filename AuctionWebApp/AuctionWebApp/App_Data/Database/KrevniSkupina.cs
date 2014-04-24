using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionWebApp.Database
{
    public class KrevniSkupina
    {
        private int mIdKrve;
        private String mSkupina;

        public int IdKrve
        {
            get
            {
                return mIdKrve;
            }
            set
            {
                mIdKrve = value;
            }

        }

        public string Skupina
        {
            get
            {
                return mSkupina;
            }
            set
            {
                mSkupina = value;
            }
        }
    }
}