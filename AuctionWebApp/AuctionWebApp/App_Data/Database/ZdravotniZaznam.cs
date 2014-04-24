using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionWebApp.Database
{
    public class ZdravotniZaznam
    {
        public int IdZaznam { get; set; }
        public string Popis { get; set; }
        public string mDatum { get; set; }
        public DateTime Datum { get; set; }
        public int IdPacient { get; set; }
        public Pacient Pacient { get; set; }
    }
}