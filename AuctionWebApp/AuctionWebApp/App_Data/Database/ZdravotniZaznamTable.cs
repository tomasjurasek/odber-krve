using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AuctionWebApp.Database
{
    public class ZdravotniZaznamTable
    {

        public String SQL_SELECT = @"SELECT * FROM zdravotni_zaznam";
        public String SQL_DELETE_ID = @"DELETE FROM zdravotni_zaznam WHERE id_zaznam =@IdZaznam";
        public String SQL_SELECT_ID = @"SELECT * FROM zdravotni_zaznam WHERE id_zaznam = @IdZaznam";
        public String SQL_INSERT = @"INSERT INTO zdravotni_zaznam VALUES(@popis,@datum,@IdPacient)";
        public String SQL_UPDATE = @"UPDATE zdravotni_zaznam SET popis=@popis, datum= @datum, id_pacient = @IdPacient  WHERE id_zaznam=@IdZaznam";
        public string SQL_SELECT_PACIENT = @"SELECT * FROM zdravotni_zaznam WHERE id_pacient = @IdPacient";


        public int Update(ZdravotniZaznam zaznam)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, zaznam);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public int Insert(ZdravotniZaznam zaznam)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, zaznam);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        private void PrepareCommand(SqlCommand command, ZdravotniZaznam zaznam)
        {
            command.Parameters.Add(new SqlParameter("@idzaznam", SqlDbType.Int));
            command.Parameters["@idzaznam"].Value = zaznam.IdZaznam;

            command.Parameters.Add(new SqlParameter("@popis", SqlDbType.VarChar,zaznam.Popis.Length));
            command.Parameters["@popis"].Value = zaznam.Popis;

            command.Parameters.Add(new SqlParameter("@datum", SqlDbType.DateTime));
            command.Parameters["@datum"].Value = DateTime.Parse(zaznam.mDatum);

            command.Parameters.Add(new SqlParameter("@idpacient", SqlDbType.Int));
            command.Parameters["@idpacient"].Value = zaznam.IdPacient;

        }

        public Collection<ZdravotniZaznam> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<ZdravotniZaznam> Zaznamy = Read(reader);
            reader.Close();
            db.Close();
            return Zaznamy;
        }


        private Collection<ZdravotniZaznam> Read(SqlDataReader reader)
        {
            Collection<ZdravotniZaznam> Zaznamy = new Collection<ZdravotniZaznam>();

            while (reader.Read())
            {
                ZdravotniZaznam Zaznam = new ZdravotniZaznam();
                Zaznam.IdZaznam = reader.GetInt32(0);
                Zaznam.Popis = reader.GetString(1);
                Zaznam.Datum = reader.GetDateTime(2);
                Zaznam.IdPacient = reader.GetInt32(3);
                Zaznam.Pacient = new PacientTable().Select(Zaznam.IdPacient);


                Zaznamy.Add(Zaznam);
            }
            //reader.Close();
            return Zaznamy;
        }

        public int Delete(int idzaznam)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.Add(new SqlParameter("@IdZaznam", SqlDbType.Int));
            command.Parameters["@IdZaznam"].Value = idzaznam;
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }


        public ZdravotniZaznam Select(int idzaznam)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);
            command.Parameters.Add(new SqlParameter("@IdZaznam", SqlDbType.Int));
            command.Parameters["@IdZaznam"].Value = idzaznam;
            SqlDataReader reader = db.Select(command);

            Collection<ZdravotniZaznam> Zaznamy = Read(reader);
            ZdravotniZaznam zaznam = null;
            if (Zaznamy.Count == 1)
            {
                zaznam = Zaznamy[0];
            }
            reader.Close();
            db.Close();

            return zaznam;
        }


        public Collection<ZdravotniZaznam> SelectPacient(int idpacient)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_PACIENT);
            command.Parameters.Add(new SqlParameter("@IdPacient", SqlDbType.Int));
            command.Parameters["@idpacient"].Value = idpacient;
            SqlDataReader reader = db.Select(command);

            Collection<ZdravotniZaznam> Zaznamy = Read(reader);
            //ZdravotniZaznam zaznam = null;
           
            reader.Close();
            db.Close();

            return Zaznamy;
        }

    }
}