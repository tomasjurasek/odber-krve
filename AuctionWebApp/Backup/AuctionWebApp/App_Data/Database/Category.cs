using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionWebApp.Database
{
    public class Category
    {
        private int mIdCategory;
        private String mName;
        private String mDescription;

        public static int LEN_ATTR_name = 30;
        public static int LEN_ATTR_description = 100;

        public int IdCategory
        {
            get
            {
                return mIdCategory;
            }
            set
            {
                mIdCategory = value;
            }
        }

        public String Name
        {
            get
            {
                return mName;
            }
            set
            {
                mName = value;
            }
        }

        public String Description
        {
            get
            {
                return mDescription;
            }
            set
            {
                mDescription = value;
            }
        }
    }
}