using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AuctionWebApp.Database
{
    public class PacientTable
    {

        public String SQL_SELECT = @"SELECT * FROM pacient";
        public String SQL_DELETE_ID = @"DELETE FROM pacient WHERE id_pacient =@IdPacient";
        public String SQL_SELECT_ID = @"SELECT * FROM pacient WHERE id_pacient = @IdPacient";
        public String SQL_INSERT = @"INSERT INTO pacient VALUES(@jmeno,@prijmeni,@vek,@mesto,@adresa,@telefon,@email,@bonus,@krev,@pojistovna)";

        public String SQL_UPDATE = @"UPDATE pacient SET jmeno=@jmeno, prijmeni = @prijmeni, vek = @vek, mesto = @mesto, adresa = @adresa, telefon = @telefon, email = @email, bonus = @bonus, id_krve = @krev, id_pojistovny = @pojistovna  WHERE id_pacient=@IdPacient";



        public int Update(Pacient pacient)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, pacient);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public string Insert(Pacient pacient)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand("VytvorPacienta");
            command.CommandType = CommandType.StoredProcedure;
            //PrepareCommand(command, pacient);
            //int ret = db.ExecuteNonQuery(command);


            command.Parameters.Add(new SqlParameter("@jmeno", SqlDbType.VarChar, pacient.Jmeno.Length));
            command.Parameters["@jmeno"].Value = pacient.Jmeno;

            command.Parameters.Add(new SqlParameter("@prijmeni", SqlDbType.VarChar, pacient.Prijmeni.Length));
            command.Parameters["@prijmeni"].Value = pacient.Prijmeni;

            command.Parameters.Add(new SqlParameter("@vek", SqlDbType.Int));
            command.Parameters["@vek"].Value = pacient.Vek;

            command.Parameters.Add(new SqlParameter("@mesto", SqlDbType.VarChar, pacient.Mesto.Length));
            command.Parameters["@mesto"].Value = pacient.Mesto;

            command.Parameters.Add(new SqlParameter("@adresa", SqlDbType.VarChar, pacient.Adresa.Length));
            command.Parameters["@adresa"].Value = pacient.Adresa;

            command.Parameters.Add(new SqlParameter("@telefon", SqlDbType.Int));
            command.Parameters["@telefon"].Value = pacient.Telefon;

            command.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, pacient.Email.Length));
            command.Parameters["@email"].Value = pacient.Email;

            command.Parameters.Add(new SqlParameter("@id_krve", SqlDbType.Int));
            command.Parameters["@id_krve"].Value = pacient.IdKrve;

            command.Parameters.Add(new SqlParameter("@id_pojistovna", SqlDbType.Int));
            command.Parameters["@id_pojistovna"].Value = pacient.IdPojistovna;

            command.Parameters.Add(new SqlParameter("@out", SqlDbType.VarChar, 1000));
            command.Parameters["@out"].Value = 0;
            command.Parameters["@out"].Direction = ParameterDirection.Output;


            command.ExecuteNonQuery();
            //string ret =command.Parameters["@out"].Value.ToString();
            db.Close();
            return command.Parameters["@out"].Value.ToString();
        }

        private void PrepareCommand(SqlCommand command, Pacient pacient)
        {
            command.Parameters.Add(new SqlParameter("@idpacient", SqlDbType.Int));
            command.Parameters["@idpacient"].Value = pacient.IdPacient;

            command.Parameters.Add(new SqlParameter("@jmeno", SqlDbType.VarChar, pacient.Jmeno.Length));
            command.Parameters["@jmeno"].Value = pacient.Jmeno;

            command.Parameters.Add(new SqlParameter("@prijmeni", SqlDbType.VarChar, pacient.Prijmeni.Length));
            command.Parameters["@prijmeni"].Value = pacient.Prijmeni;

            command.Parameters.Add(new SqlParameter("@vek", SqlDbType.Int));
            command.Parameters["@vek"].Value = pacient.Vek;

            command.Parameters.Add(new SqlParameter("@mesto", SqlDbType.VarChar, pacient.Mesto.Length));
            command.Parameters["@mesto"].Value = pacient.Mesto;

            command.Parameters.Add(new SqlParameter("@adresa", SqlDbType.VarChar,pacient.Adresa.Length));
            command.Parameters["@adresa"].Value = pacient.Adresa;

            command.Parameters.Add(new SqlParameter("@telefon", SqlDbType.Int));
            command.Parameters["@telefon"].Value = pacient.Telefon;

            command.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, pacient.Email.Length));
            command.Parameters["@email"].Value = pacient.Email;

            command.Parameters.Add(new SqlParameter("@bonus", SqlDbType.Int));
            command.Parameters["@bonus"].Value = pacient.Bonus;

            command.Parameters.Add(new SqlParameter("@krev", SqlDbType.Int));
            command.Parameters["@krev"].Value = pacient.IdKrve;

            command.Parameters.Add(new SqlParameter("@pojistovna", SqlDbType.Int));
            command.Parameters["@pojistovna"].Value = pacient.IdPojistovna;

            command.Parameters.Add(new SqlParameter("@out", SqlDbType.VarChar, 1000));
            command.Parameters["@out"].Value = 0;
            command.Parameters["@out"].Direction = ParameterDirection.Output;
        }

        public Collection<Pacient> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Pacient> Pacienti = Read(reader);
            reader.Close();
            db.Close();
            return Pacienti;
        }


        private Collection<Pacient> Read(SqlDataReader reader)
        {
            Collection<Pacient> Pacienti = new Collection<Pacient>();

            while (reader.Read())
            {
                Pacient pacient = new Pacient();
                pacient.IdPacient = reader.GetInt32(0);
                pacient.Jmeno = reader.GetString(1);
                pacient.Prijmeni = reader.GetString(2);
                pacient.Vek = reader.GetInt32(3);
                pacient.Mesto = reader.GetString(4);
                pacient.Adresa = reader.GetString(5);
                pacient.Telefon = reader.GetInt32(6);
                pacient.Email = reader.GetString(7);
                pacient.Bonus = reader.GetInt32(8);
                pacient.IdKrve = reader.GetInt32(9);
                pacient.IdPojistovna = reader.GetInt32(10);
                pacient.Krev = new KrevniSkupinaTable().Select(pacient.IdKrve);
                pacient.Pojistovna = new PojistovnaTable().Select(pacient.IdPojistovna);

                //pacient.zaznamy = (new ZdravotniZaznamTable().SelectPacient(pacient.IdPacient));

                Pacienti.Add(pacient);
            }
            return Pacienti;
        }

        public int Delete(int idpacient)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.Add(new SqlParameter("@IdPacient", SqlDbType.Int));
            command.Parameters["@IdPacient"].Value = idpacient;
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }


        public Pacient Select(int idpacient)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);
            command.Parameters.Add(new SqlParameter("@IdPacient", SqlDbType.Int));
            command.Parameters["@IdPacient"].Value = idpacient;
            SqlDataReader reader = db.Select(command);

            Collection<Pacient> Pacienti = Read(reader);
            Pacient pacient = null;
            if (Pacienti.Count == 1)
            {
                pacient = Pacienti[0];
            }
            reader.Close();
            db.Close();

            return pacient;
        }

        public void BonusPacienti(int pojistovna)
        {

            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand("BonusPacient");
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@idpojistovna", SqlDbType.Int));
            command.Parameters["@idpojistovna"].Value = pojistovna;
            command.ExecuteNonQuery();
        }


    }
}