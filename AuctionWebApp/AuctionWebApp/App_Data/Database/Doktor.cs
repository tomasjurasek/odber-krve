using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionWebApp.Database
{
    public class Doktor
    {

        public int IdDoktor {get;set;}
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public bool Primar { get; set; }

        public string Email { get; set; }
        public int Telefon { get; set; }
        public int Bonus { get; set; }

    }
}