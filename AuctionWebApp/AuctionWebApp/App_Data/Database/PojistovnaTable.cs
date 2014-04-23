using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AuctionWebApp.Database
{
    public class PojistovnaTable
    {
        public String SQL_SELECT = @"SELECT * FROM Pojistovna";
        public String SQL_DELETE_ID = @"DELETE FROM Pojistovna WHERE id_pojistovny =@IdPojistovna";
        public String SQL_SELECT_ID = @"SELECT * FROM POJISTOVNA WHERE id_pojistovny = @IdPojistovna";
        public String SQL_INSERT = @"INSERT INTO Pojistovna VALUES(@cislopojistovna)";
        public String SQL_UPDATE = @"UPDATE Pojistovna SET cislo_pojistovny=@cislopojistovna  WHERE id_pojistovny=@idpojistovna";



        public int Update(Pojistovna pojistovna)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, pojistovna);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public int Insert(Pojistovna pojistovna)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, pojistovna);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        private void PrepareCommand(SqlCommand command, Pojistovna pojistovna)
        {
            command.Parameters.Add(new SqlParameter("@idpojistovna", SqlDbType.Int));
            command.Parameters["@idpojistovna"].Value = pojistovna.IdPojistovna;

            command.Parameters.Add(new SqlParameter("@cislopojistovna", SqlDbType.Int));
            command.Parameters["@cislopojistovna"].Value = pojistovna.CisloPojistovna;

        }

        public Collection<Pojistovna> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Pojistovna> Pojistovny = Read(reader);
            reader.Close();
            db.Close();
            return Pojistovny;
        }


        private Collection<Pojistovna> Read(SqlDataReader reader)
        {
            Collection<Pojistovna> Pojistovny = new Collection<Pojistovna>();

            while (reader.Read())
            {
                Pojistovna Pojistovna = new Pojistovna();
                Pojistovna.IdPojistovna = reader.GetInt32(0);
                Pojistovna.CisloPojistovna = reader.GetInt32(1);


                Pojistovny.Add(Pojistovna);
            }
            return Pojistovny;
        }

        public int Delete(int idpojistovna)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.Add(new SqlParameter("@IdPojistovna", SqlDbType.Int));
            command.Parameters["@IdPojistovna"].Value = idpojistovna;
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }


        public Pojistovna Select(int idpojistovna)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);
            command.Parameters.Add(new SqlParameter("@IdPojistovna", SqlDbType.Int));
            command.Parameters["@IdPojistovna"].Value = idpojistovna;
            SqlDataReader reader = db.Select(command);

            Collection<Pojistovna> Pojistovny = Read(reader);
            Pojistovna pojis = null;
            if (Pojistovny.Count == 1)
            {
                pojis = Pojistovny[0];
            }
            reader.Close();
            db.Close();

            return pojis;
        }
    }
}