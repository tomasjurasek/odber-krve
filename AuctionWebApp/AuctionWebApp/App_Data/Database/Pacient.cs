using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace AuctionWebApp.Database
{
    public class Pacient
    {
        public int IdPacient { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public int Vek { get; set; }
        public string Mesto { get; set; }
        public string Adresa { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
        public int Bonus { get; set; }
        public int IdKrve { get; set; }
        public int IdPojistovna { get; set; }

        //public Collection<ZdravotniZaznam> zaznamy = null;


        public KrevniSkupina Krev { get; set; }
        public Pojistovna Pojistovna { get; set; }
    }
}