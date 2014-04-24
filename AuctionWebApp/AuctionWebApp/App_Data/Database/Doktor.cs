using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionWebApp.Database
{
    public class Doktor
    {

        private int mIdDoktor;
        private string mJmeno;
        private string mPrijmeni;
        private bool mPrimar;
        private string mEmail;
        private int mTelefon;
        private int mBonus;


        public int IdDoktor
        {
            get
            {
                return mIdDoktor;
            }
            set
            {
                mIdDoktor = value;
            }
        }

        public string Jmeno
        {
            get
            {
                return mJmeno;
            }
            set
            {
                mJmeno = value;
            }

        }

        public string Prijmeni
        {
            get
            {
                return mPrijmeni;
            }
            set
            {
                mPrijmeni = value;
            }

        }

        public bool Primar
        {
            get 
            {
                return mPrimar;
            }
            set
            {
                mPrimar = value;
            }
        }

        public string Email
        {
            get
            {
                return mEmail;
            }
            set
            {
                mEmail = value;
            }
        }

        public int Telefon
        {
            get
            {
                return mTelefon;
            }
            set
            {
                mTelefon = value;
            }
        }
        public int Bonus
        {
            get
            {
                return mBonus;
            }
            set
            {
                mBonus = value;
            }

        }
    }
}