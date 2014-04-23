using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AuctionWebApp.Database
{
    public class CategoryTable
    {
        public static String TABLE_NAME = "Category";

        public String SQL_SELECT = "SELECT * FROM Category";
        public String SQL_SELECT_ID = "SELECT * FROM Category WHERE idCategory=@idCategory";
        public String SQL_INSERT = "INSERT INTO Category VALUES (@name, @description)";
        public String SQL_DELETE_ID = "DELETE FROM Category WHERE idCategory=@idCategory";
        public String SQL_UPDATE = "UPDATE Category SET name=@name, description=@description WHERE idCategory=@idCategory";

        public CategoryTable()
        {
        }

        /**
         * Insert the record.
         **/
        public int Insert(Category Category)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, Category);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /**
         * Update the record.
         **/
        public int Update(Category Category)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, Category);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /**
         * Prepare a command.
         **/
        private void PrepareCommand(SqlCommand command, Category Category)
        {
            command.Parameters.Add(new SqlParameter("@idCategory", SqlDbType.Int));
            command.Parameters["@idCategory"].Value = Category.IdCategory;

            command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, Category.Name.Length));
            command.Parameters["@name"].Value = Category.Name;

            command.Parameters.Add(new SqlParameter("@description", SqlDbType.VarChar, Category.Description.Length));
            command.Parameters["@description"].Value = Category.Description;
        }

        /**
         * Select records.
         **/
        public Collection<Category> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Category> Categorys = Read(reader);
            reader.Close();
            db.Close();
            return Categorys;
        }

        /**
         * Select the record.
         **/
        public Category Select(int idCategory)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.Add(new SqlParameter("@idCategory", SqlDbType.Int));
            command.Parameters["@idCategory"].Value = idCategory;
            SqlDataReader reader = db.Select(command);

            Collection<Category> categories = Read(reader);
            Category category = null;
            if (categories.Count == 1)
            {
                category = categories[0];
            }
            reader.Close();
            db.Close();
            return category;
        }

        private Collection<Category> Read(SqlDataReader reader)
        {
            Collection<Category> categories = new Collection<Category>();

            while (reader.Read())
            {
                Category category = new Category();
                category.IdCategory = reader.GetInt32(0);
                category.Name = reader.GetString(1);
                if (!reader.IsDBNull(2))
                {
                    category.Description = reader.GetString(2);
                }
                categories.Add(category);
            }
            return categories;
        }

        /**
         * Delete the record.
         */
        public int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.Add(new SqlParameter("@idCategory", SqlDbType.Int));
            command.Parameters["@idCategory"].Value = id;
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }
    }
}