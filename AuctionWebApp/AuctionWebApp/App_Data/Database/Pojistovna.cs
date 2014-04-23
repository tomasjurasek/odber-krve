using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionWebApp.Database
{
    public class Pojistovna
    {
        private int mIdPojistovna;
        private int mCisloPojistovna;

        public int IdPojistovna
        {
            get
            {
                return mIdPojistovna;
            }
            set
            {
                mIdPojistovna = value;
            }

        }

        public int CisloPojistovna
        {
            get
            {
                return mCisloPojistovna;
            }
            set
            {

                mCisloPojistovna = value;
            }

        }
    }
}