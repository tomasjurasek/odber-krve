using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AuctionWebApp.Database
{
    public class OdberTable
    {

        public String SQL_SELECT = @"SELECT * FROM odber join uskladneni on odber.id_uskladneni = uskladneni.id_uskladneni";

        public String SQL_DELETE_ID = @"DELETE FROM zdravotni_zaznam WHERE id_zaznam =@IdZaznam";

        public String SQL_SELECT_ID = @"SELECT * FROM odber join uskladneni on odber.id_uskladneni = uskladneni.id_uskladneni where id_odberu = @IdOdber";
        public String SQL_INSERT = @"INSERT INTO zdravotni_zaznam VALUES(@popis,@datum,@IdPacient)";


        public String SQL_UPDATE = @"UPDATE odber SET id_stavu=@IdStav where id_odberu = @IdOdber";
        public string SQL_SELECT_ODBER = @"SELECT * FROM odber join uskladneni on odber.id_uskladneni=uskladneni.id_uskladneni WHERE id_pacient = @IdPacient";



        public string Insert(Odber odber)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand("VytvorOdber");
            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.Add(new SqlParameter("@id_doktor", SqlDbType.Int));
            command.Parameters["@id_doktor"].Value = odber.IdDoktor;

            command.Parameters.Add(new SqlParameter("@id_pacient", SqlDbType.Int));
            command.Parameters["@id_pacient"].Value = odber.IdPacient;

            



            command.Parameters.Add(new SqlParameter("@id_stav", SqlDbType.Int));
            command.Parameters["@id_stav"].Value = odber.IdStav;



            //command.Parameters.Add(new SqlParameter("@poznamka", SqlDbType.VarChar, odber.Poznamka.Length));
            //command.Parameters["@poznamka"].Value = odber.Poznamka;

            command.Parameters.Add(new SqlParameter("@cislouschovna", SqlDbType.Int));
            command.Parameters["@cislouschovna"].Value = odber.CisloUschovna;


            command.Parameters.Add(new SqlParameter("@out", SqlDbType.VarChar, 1000));
            command.Parameters["@out"].Value = 0;
            command.Parameters["@out"].Direction = ParameterDirection.Output;
           

            command.ExecuteNonQuery();
            //string ret =command.Parameters["@out"].Value.ToString();
            db.Close();
            return command.Parameters["@out"].Value.ToString();
        }



        public int Update(Odber odber)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, odber);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }


        private void PrepareCommand(SqlCommand command, Odber odber)
        {
            command.Parameters.Add(new SqlParameter("@idodber", SqlDbType.Int));
            command.Parameters["@idodber"].Value = odber.IdOdber;

            command.Parameters.Add(new SqlParameter("@iddoktor", SqlDbType.Int));
            command.Parameters["@iddoktor"].Value = odber.IdDoktor;

            command.Parameters.Add(new SqlParameter("@idpacient", SqlDbType.Int));
            command.Parameters["@idpacient"].Value = odber.IdPacient;

            command.Parameters.Add(new SqlParameter("@iduskladneni", SqlDbType.Int));
            command.Parameters["@iduskladneni"].Value = odber.IdUskladneni;

 

            command.Parameters.Add(new SqlParameter("@idstav", SqlDbType.Int));
            command.Parameters["@idstav"].Value = odber.IdStav;

            //command.Parameters.Add(new SqlParameter("@datum", SqlDbType.DateTime));
            //command.Parameters["@datum"].Value = odber.Datum;

            //command.Parameters.Add(new SqlParameter("@poznamka", SqlDbType.VarChar, odber.Poznamka.Length));
            //command.Parameters["@poznamka"].Value = odber.Poznamka;

            command.Parameters.Add(new SqlParameter("@cislouschovna", SqlDbType.Int));
            command.Parameters["@cislouschovna"].Value = odber.CisloUschovna;




        }


        public Collection<Odber> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Odber> Odbery = Read(reader);
            reader.Close();
            db.Close();
            return Odbery;
        }


        private Collection<Odber> Read(SqlDataReader reader)
        {
            Collection<Odber> Odbery = new Collection<Odber>();

            while (reader.Read())
            {
                Odber odber = new Odber();
                odber.IdOdber = reader.GetInt32(0);
                odber.IdDoktor = reader.GetInt32(1);
                odber.IdPacient = reader.GetInt32(2);
                odber.IdUskladneni = reader.GetInt32(3);
                odber.IdStav = reader.GetInt32(4);
                odber.Datum = reader.GetDateTime(6);
               
                odber.CisloUschovna = reader.GetInt32(7);

                odber.pacient = new PacientTable().Select(odber.IdPacient);
                odber.doktor = new DoktorTable().Select(odber.IdDoktor);
                odber.stav = new StavTable().Select(odber.IdStav);

                

                Odbery.Add(odber);
            }
            //reader.Close();
            return Odbery;
        }


        public Odber Select(int idodber)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);
            command.Parameters.Add(new SqlParameter("@IdOdber", SqlDbType.Int));
            command.Parameters["@IdOdber"].Value = idodber;
            SqlDataReader reader = db.Select(command);

            Collection<Odber> odbery = Read(reader);
            Odber odber = null;
            if (odbery.Count == 1)
            {
                odber = odbery[0];
            }
            reader.Close();
            db.Close();

            return odber;
        }


        public void ZkontrolujOdbery()
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand("KontrolaTrvanlivostiOdberu");
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
        }

        public void NakazeneOdbery()
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand("OdstranNeplatneOdbery");
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
        }

        public Collection<Odber> Selectodber(int idpacient)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_ODBER);
            command.Parameters.Add(new SqlParameter("@IdPacient", SqlDbType.Int));
            command.Parameters["@idpacient"].Value = idpacient;
            SqlDataReader reader = db.Select(command);

            Collection<Odber> odbery = Read(reader);
            //ZdravotniZaznam zaznam = null;

            reader.Close();
            db.Close();

            return odbery;
        }

    }
}