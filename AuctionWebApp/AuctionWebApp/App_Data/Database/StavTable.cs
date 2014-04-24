using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AuctionWebApp.Database
{
    public class StavTable
    {
        public String SQL_SELECT = @"SELECT * FROM Stav";
        public String SQL_DELETE_ID = @"DELETE FROM Stav WHERE id_stavu =@IdStav";
        public String SQL_SELECT_ID = @"SELECT * FROM Stav WHERE id_stavu = @IdStav";
        public String SQL_INSERT = @"INSERT INTO Stav VALUES(@stav)";
        public String SQL_UPDATE = @"UPDATE Stav SET stav=@stav  WHERE id_stavu=@IdStav";


        public int Update(Stav stav)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, stav);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public int Insert(Stav stav)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, stav);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        private void PrepareCommand(SqlCommand command, Stav stav)
        {
            command.Parameters.Add(new SqlParameter("@idstav", SqlDbType.Int));
            command.Parameters["@idstav"].Value = stav.IdStav;

            command.Parameters.Add(new SqlParameter("@stav", SqlDbType.VarChar, stav.NazevStavu.Length));
            command.Parameters["@stav"].Value = stav.NazevStavu;

        }

        public Collection<Stav> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Stav> Stavy = Read(reader);
            reader.Close();
            db.Close();
            return Stavy;
        }


        private Collection<Stav> Read(SqlDataReader reader)
        {
            Collection<Stav> Stavy = new Collection<Stav>();

            while (reader.Read())
            {
                Stav stav = new Stav();
                stav.IdStav = reader.GetInt32(0);
                stav.NazevStavu = reader.GetString(1);


                Stavy.Add(stav);
            }
            return Stavy;
        }

        public int Delete(int idstav)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.Add(new SqlParameter("@IdStav", SqlDbType.Int));
            command.Parameters["@IdStav"].Value = idstav;
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }


        public Stav Select(int idstav)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);
            command.Parameters.Add(new SqlParameter("@IdStav", SqlDbType.Int));
            command.Parameters["@IdStav"].Value = idstav;
            SqlDataReader reader = db.Select(command);

            Collection<Stav> Stavy = Read(reader);
            Stav stav = null;
            if (Stavy.Count == 1)
            {
                stav = Stavy[0];
            }
            reader.Close();
            db.Close();

            return stav;
        }

    }
}