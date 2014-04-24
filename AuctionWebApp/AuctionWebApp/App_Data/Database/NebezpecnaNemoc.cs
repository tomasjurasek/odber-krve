using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionWebApp.Database
{
    public class NebezpecnaNemoc
    {

        private int mIdNemoc;
        private string mNazev;

        public int IdNemoc
        {
            get
            {
                return mIdNemoc;
            }
            set
            {
                mIdNemoc = value;
            }
        }

        public string Nazev
        {

            get
            {
                return mNazev;
            }
            set
            {
                mNazev = value;
            }

        }
    }
}