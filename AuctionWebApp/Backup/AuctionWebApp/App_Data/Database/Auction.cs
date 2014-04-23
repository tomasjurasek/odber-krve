using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionWebApp.Database
{
    public class Auction
    {
        private int mIdAuction;
        private int mIdOwner;
        private String mName;
        private String mDescription;
        private String mDescriptionDetail;
        private DateTime mCreation;
        private DateTime mEnd;
        private int mIdCategory;
        private Category mCategory;
        private int mMaxBidValue;
        private int mMinBidValue;
        private int mIdMaxBidUser;

        public static int LEN_ATTR_name = 20;
        public static int LEN_ATTR_description = 100;
        public static int LEN_ATTR_description_detail = 2000;

        public int IdAuction
        {
            get
            {
                return mIdAuction;
            }
            set
            {
                mIdAuction = value;
            }
        }


        public int IdOwner
        {
            get
            {
                return mIdOwner;
            }
            set
            {
                mIdOwner = value;
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

        public String DescriptionDetail
        {
            get
            {
                return mDescriptionDetail;
            }
            set
            {
                mDescriptionDetail = value;
            }
        }

        public DateTime Creation
        {
            get
            {
                return mCreation;
            }
            set
            {
                mCreation = value;
            }
        }

        public DateTime End
        {
            get
            {
                return mEnd;
            }
            set
            {
                mEnd = value;
            }
        }

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

        public Category Category
        {
            get
            {
                return mCategory;
            }
            set
            {
                mCategory = value;
            }
        }

        public int MinBidValue
        {
            get
            {
                return mMinBidValue;
            }
            set
            {
                mMinBidValue = value;
            }
        }

        public int MaxBidValue
        {
            get
            {
                return mMaxBidValue;
            }
            set
            {
                mMaxBidValue = value;
            }
        }

        public int IdMaxBidUser
        {
            get
            {
                return mIdMaxBidUser;
            }
            set
            {
                mIdMaxBidUser = value;
            }
        }
    }
}