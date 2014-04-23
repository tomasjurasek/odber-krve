using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AuctionWebApp.Database
{
    public class UserTable
    {
        public String SQL_SELECT = "SELECT * FROM \"User\"";
        public String SQL_SELECT_ID = "SELECT * FROM \"User\" WHERE idUser=@id";
        public String SQL_INSERT = "INSERT INTO \"User\" VALUES (@id, @login, @name, @surname, @address, @telephone," +
            "@maximum_unfinisfed_auctions, @last_visit, @type)";
        public String SQL_DELETE_ID = "DELETE FROM \"User\" WHERE idUser=@id";
        public String SQL_UPDATE = "UPDATE \"User\" SET login=@login, name=@name, surname=@surname," +
            "address=@address, telephone=@telephone, maximum_unfinisfed_auctions=@maximum_unfinisfed_auctions," +
            "last_visit=@last_visit, type=@type WHERE idUser=@id";

        public UserTable()
        {
        }

        /**
         * Insert the record.
         **/
        public int Insert(User User)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, User);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /**
         * Update the record.
         **/
        public int Update(User User)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, User);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /**
         * Prepare a command.
         **/
        private void PrepareCommand(SqlCommand command, User User)
        {
            command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
            command.Parameters["@id"].Value = User.Id;

            command.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar, User.Login.Length));
            command.Parameters["@login"].Value = User.Login;

            command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, User.Name.Length));
            command.Parameters["@name"].Value = User.Name;

            command.Parameters.Add(new SqlParameter("@surname", SqlDbType.VarChar, User.Surname.Length));
            command.Parameters["@surname"].Value = User.Surname;

            command.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar, User.Address.Length));
            command.Parameters["@address"].Value = User.Address;

            command.Parameters.Add(new SqlParameter("@telephone", SqlDbType.VarChar, User.Telephone.Length));
            command.Parameters["@telephone"].Value = User.Telephone;

            command.Parameters.Add(new SqlParameter("@maximum_unfinisfed_auctions", SqlDbType.Int));
            command.Parameters["@maximum_unfinisfed_auctions"].Value = User.MaximumUnfinisfedAuctions;

            command.Parameters.Add(new SqlParameter("@last_visit", SqlDbType.DateTime));
            command.Parameters["@last_visit"].Value = User.LastVisit;

            command.Parameters.Add(new SqlParameter("@type", SqlDbType.VarChar, User.Type.Length));
            command.Parameters["@type"].Value = User.Type;
        }

        /**
         * Select records.
         **/
        public Collection<User> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<User> Users = Read(reader);
            reader.Close();
            db.Close();
            return Users;
        }

        /**
         * Select the record.
         **/
        public User Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
            command.Parameters["@id"].Value = id;
            SqlDataReader reader = db.Select(command);

            Collection<User> Users = Read(reader);
            User User = null;
            if (Users.Count == 1)
            {
                User = Users[0];
            }
            reader.Close();
            db.Close();
            return User;
        }

        private Collection<User> Read(SqlDataReader reader)
        {
            Collection<User> Users = new Collection<User>();

            while (reader.Read())
            {
                User User = new User();
                User.Id = reader.GetInt32(0);
                User.Login = reader.GetString(1);
                User.Name = reader.GetString(2);
                User.Surname = reader.GetString(3);
                User.Address = reader.GetString(4);
                User.Telephone = reader.GetString(5);
                User.MaximumUnfinisfedAuctions = reader.GetInt32(6);
                if (!reader.IsDBNull(7))
                {
                    User.LastVisit = reader.GetDateTime(7);
                }
                User.Type = reader.GetString(8);

                Users.Add(User);
            }
            return Users;
        }

        /**
         * Delete the record.
         */
        public int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
            command.Parameters["@id"].Value = id;
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }
    }
}