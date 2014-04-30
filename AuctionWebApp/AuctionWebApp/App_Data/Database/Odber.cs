using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionWebApp.Database
{
    public class Odber
    {
        public int IdOdber { get; set; }
        public int IdDoktor { get; set; }
        public int IdPacient { get; set; }
        public int IdStav { get; set; }
        public int IdUskladneni { get; set; }
        public DateTime Datum { get; set; }
        //public string mDatum { get; set; }
        //public string Poznamka { get; set; }
        public int CisloUschovna { get; set; }


        public Pacient pacient { get; set; }
        public Doktor doktor { get; set; }
        public Stav stav { get; set; }
    }
}