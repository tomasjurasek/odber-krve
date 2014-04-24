using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AuctionWebApp.Database
{
    public class KrevniSkupinaTable
    {

        public String SQL_SELECT = @"SELECT * FROM Krevni_skupina";
        public String SQL_DELETE_ID = @"DELETE FROM Krevni_skupina WHERE id_krve =@IdKrve";
        public String SQL_SELECT_ID = @"SELECT * FROM Krevni_skupina WHERE id_krve = @IdKrve";
        public String SQL_INSERT = @"INSERT INTO Krevni_skupina VALUES(@skupina)";
        public String SQL_UPDATE = @"UPDATE Krevni_skupina SET skupina=@skupina  WHERE id_krve=@IdKrve";

        public int Update(KrevniSkupina krevniskupina)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, krevniskupina);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public int Insert(KrevniSkupina krevniskupina)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, krevniskupina);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        private void PrepareCommand(SqlCommand command, KrevniSkupina krevniskupina)
        {
            command.Parameters.Add(new SqlParameter("@idkrve", SqlDbType.Int));
            command.Parameters["@idkrve"].Value = krevniskupina.IdKrve;

            command.Parameters.Add(new SqlParameter("@skupina", SqlDbType.VarChar,krevniskupina.Skupina.Length));
            command.Parameters["@skupina"].Value = krevniskupina.Skupina;

        }

        public Collection<KrevniSkupina> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<KrevniSkupina> Skupiny = Read(reader);
            reader.Close();
            db.Close();
            return Skupiny;
        }


        private Collection<KrevniSkupina> Read(SqlDataReader reader)
        {
            Collection<KrevniSkupina> Skupiny = new Collection<KrevniSkupina>();

            while (reader.Read())
            {
                KrevniSkupina skupina = new KrevniSkupina();
                skupina.IdKrve = reader.GetInt32(0);
                skupina.Skupina = reader.GetString(1);


                Skupiny.Add(skupina);
            }
            return Skupiny;
        }

        public int Delete(int idkrve)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.Add(new SqlParameter("@IdKrve", SqlDbType.Int));
            command.Parameters["@IdKrve"].Value = idkrve;
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }


        public KrevniSkupina Select(int idkrve)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);
            command.Parameters.Add(new SqlParameter("@IdKrve", SqlDbType.Int));
            command.Parameters["@IdKrve"].Value = idkrve;
            SqlDataReader reader = db.Select(command);

            Collection<KrevniSkupina> Skupiny = Read(reader);
            KrevniSkupina krev = null;
            if (Skupiny.Count == 1)
            {
                krev = Skupiny[0];
            }
            reader.Close();
            db.Close();

            return krev;
        }
    }
}