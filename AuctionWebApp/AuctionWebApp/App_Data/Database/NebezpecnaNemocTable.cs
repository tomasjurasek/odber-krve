using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AuctionWebApp.Database
{
    public class NebezpecnaNemocTable
    {

        public String SQL_SELECT = @"SELECT * FROM nebezpecne_nemoci";
        public String SQL_DELETE_ID = @"DELETE FROM nebezpecne_nemoci WHERE id_nemoc =@IdNemoc";
        public String SQL_SELECT_ID = @"SELECT * FROM nebezpecne_nemoci WHERE id_nemoc = @IdNemoc";
        public String SQL_INSERT = @"INSERT INTO nebezpecne_nemoci VALUES(@nazev)";
        public String SQL_UPDATE = @"UPDATE nebezpecne_nemoci SET popis=@nazev  WHERE id_nemoc=@IdNemoc";


        public int Update(NebezpecnaNemoc nemoc)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, nemoc);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public int Insert(NebezpecnaNemoc nemoc)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, nemoc);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        private void PrepareCommand(SqlCommand command, NebezpecnaNemoc nemoc)
        {
            command.Parameters.Add(new SqlParameter("@idnemoc", SqlDbType.Int));
            command.Parameters["@idnemoc"].Value = nemoc.IdNemoc;

            command.Parameters.Add(new SqlParameter("@nazev", SqlDbType.VarChar, nemoc.Nazev.Length));
            command.Parameters["@nazev"].Value = nemoc.Nazev;

        }

        public Collection<NebezpecnaNemoc> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<NebezpecnaNemoc> Nemoci = Read(reader);
            reader.Close();
            db.Close();
            return Nemoci;
        }


        private Collection<NebezpecnaNemoc> Read(SqlDataReader reader)
        {
            Collection<NebezpecnaNemoc> Nemoci = new Collection<NebezpecnaNemoc>();

            while (reader.Read())
            {
                NebezpecnaNemoc nemoc = new NebezpecnaNemoc();
                nemoc.IdNemoc = reader.GetInt32(0);
                nemoc.Nazev = reader.GetString(1);


                Nemoci.Add(nemoc);
            }
            return Nemoci;
        }

        public int Delete(int idnemoc)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.Add(new SqlParameter("@IdNemoc", SqlDbType.Int));
            command.Parameters["@IdNemoc"].Value = idnemoc;
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }


        public NebezpecnaNemoc Select(int idnemoc)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);
            command.Parameters.Add(new SqlParameter("@IdNemoc", SqlDbType.Int));
            command.Parameters["@IdNemoc"].Value = idnemoc;
            SqlDataReader reader = db.Select(command);

            Collection<NebezpecnaNemoc> Nemoci = Read(reader);
            NebezpecnaNemoc nemoc = null;
            if (Nemoci.Count == 1)
            {
                nemoc = Nemoci[0];
            }
            reader.Close();
            db.Close();

            return nemoc;
        }
    }
}