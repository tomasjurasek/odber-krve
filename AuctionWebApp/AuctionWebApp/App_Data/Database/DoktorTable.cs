using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AuctionWebApp.Database
{
    public class DoktorTable
    {
        public String SQL_SELECT = @"SELECT * FROM doktor";
        public String SQL_DELETE_ID = @"DELETE FROM doktor WHERE id_doktor =@IdDoktor";
        public String SQL_SELECT_ID = @"SELECT * FROM doktor WHERE id_doktor = @IdDoktor";
        public String SQL_INSERT = @"INSERT INTO doktor VALUES(@jmeno,@prijmeni,@primar,@email,@telefon,@bonus)";
        public String SQL_UPDATE = @"UPDATE doktor SET jmeno=@jmeno, prijmeni = @prijmeni, primar = @primar, email = @email, telefon = @telefon, bonus = @bonus  WHERE id_doktor=@IdDoktor";


        public int Update(Doktor doktor)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, doktor);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public int Insert(Doktor doktor)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, doktor);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        private void PrepareCommand(SqlCommand command, Doktor doktor)
        {
            command.Parameters.Add(new SqlParameter("@iddoktor", SqlDbType.Int));
            command.Parameters["@iddoktor"].Value = doktor.IdDoktor;

            command.Parameters.Add(new SqlParameter("@jmeno", SqlDbType.VarChar, doktor.Jmeno.Length));
            command.Parameters["@jmeno"].Value = doktor.Jmeno;

            command.Parameters.Add(new SqlParameter("@prijmeni", SqlDbType.VarChar, doktor.Prijmeni.Length));
            command.Parameters["@prijmeni"].Value = doktor.Prijmeni;

            command.Parameters.Add(new SqlParameter("@primar", SqlDbType.Bit));
            command.Parameters["@primar"].Value = doktor.Primar;

            command.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, doktor.Email.Length));
            command.Parameters["@email"].Value = doktor.Email;

            command.Parameters.Add(new SqlParameter("@telefon", SqlDbType.Int));
            command.Parameters["@telefon"].Value = doktor.Telefon;

            command.Parameters.Add(new SqlParameter("@bonus", SqlDbType.Int));
            command.Parameters["@bonus"].Value = doktor.Bonus;


        }

        public Collection<Doktor> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Doktor> Doktori = Read(reader);
            reader.Close();
            db.Close();
            return Doktori;
        }


        private Collection<Doktor> Read(SqlDataReader reader)
        {
            Collection<Doktor> Doktori = new Collection<Doktor>();

            while (reader.Read())
            {
                Doktor doktor = new Doktor();
                doktor.IdDoktor = reader.GetInt32(0);
                doktor.Jmeno = reader.GetString(1);
                doktor.Prijmeni = reader.GetString(2);
                doktor.Primar = reader.GetBoolean(3);
                doktor.Email = reader.GetString(4);
                doktor.Telefon = reader.GetInt32(5);
                doktor.Bonus = reader.GetInt32(6);



                Doktori.Add(doktor);
            }
            return Doktori;
        }

        public int Delete(int iddoktor)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.Add(new SqlParameter("@IdDoktor", SqlDbType.Int));
            command.Parameters["@IdDoktor"].Value = iddoktor;
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }


        public Doktor Select(int iddoktor)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);
            command.Parameters.Add(new SqlParameter("@IdDoktor", SqlDbType.Int));
            command.Parameters["@IdDoktor"].Value = iddoktor;
            SqlDataReader reader = db.Select(command);

            Collection<Doktor> Doktori = Read(reader);
            Doktor doktor = null;
            if (Doktori.Count == 1)
            {
                doktor = Doktori[0];
            }
            reader.Close();
            db.Close();

            return doktor;
        }

    }
}