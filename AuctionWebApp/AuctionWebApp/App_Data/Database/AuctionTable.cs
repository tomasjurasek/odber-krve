using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace AuctionWebApp.Database
{
    public class AuctionTable
    {
        public static String TABLE_NAME = "Auction";

        public String SQL_SELECT = "SELECT a.idAuction,a.name,a.description,a.creation,a.\"end\",a.category,a.min_bid_value, " +
            "a.max_bid_value, a.max_bid_user,c.name FROM Auction a, Category c WHERE a.owner=@owner and a.category=c.idCategory";
        public String SQL_SELECT_ID = "SELECT a.*,c.name FROM Auction a, Category c WHERE a.idAuction=@idAuction and a.category=c.idCategory";
        public String SQL_INSERT = "INSERT INTO Auction VALUES (@owner, @name, @description, @description_detail, " + 
            "@creation, @end, @category, @min_bid_value, NULL, NULL)";
        public String SQL_DELETE_ID = "DELETE FROM Auction WHERE idAuction=@idAuction";

        public AuctionTable()
        {
        }

        /**
         * Insert the record.
         **/
        public int Insert(Auction Auction)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, Auction);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /**
         * Prepare a command.
         **/
        private void PrepareCommand(SqlCommand command, Auction Auction)
        {
            command.Parameters.Add(new SqlParameter("@owner", SqlDbType.Int));
            command.Parameters["@owner"].Value = Auction.IdOwner;

            command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, Auction.Name.Length));
            command.Parameters["@name"].Value = Auction.Name;

            command.Parameters.Add(new SqlParameter("@description", SqlDbType.VarChar, Auction.Description.Length));
            command.Parameters["@description"].Value = Auction.Description;

            SqlParameter descDetailParam = new SqlParameter("@description_detail", SqlDbType.VarChar);
            descDetailParam.IsNullable = true;
            descDetailParam.Value = (Auction.DescriptionDetail == null) ? SqlString.Null : Auction.DescriptionDetail;
            descDetailParam.Size = (Auction.DescriptionDetail == null) ? Auction.LEN_ATTR_description_detail : Auction.DescriptionDetail.Length;
            // if (Auction.DescriptionDetail != null) descDetailParam.Size = Auction.DescriptionDetail.Length;
            command.Parameters.Add(descDetailParam);

            command.Parameters.Add(new SqlParameter("@creation", SqlDbType.DateTime));
            command.Parameters["@creation"].Value = Auction.Creation;

            command.Parameters.Add(new SqlParameter("@end", SqlDbType.DateTime));
            command.Parameters["@end"].Value = Auction.End;

            command.Parameters.Add(new SqlParameter("@category", SqlDbType.Int));
            command.Parameters["@category"].Value = Auction.IdCategory;

            command.Parameters.Add(new SqlParameter("@min_bid_value", SqlDbType.Int));
            command.Parameters["@min_bid_value"].Value = Auction.MinBidValue;
        }

        /**
         * Select records. iduser -- owner of transactions.
         **/
        public Collection<Auction> Select(int iduser)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            command.Parameters.Add(new SqlParameter("@owner", SqlDbType.Int));
            command.Parameters["@owner"].Value = iduser;
            SqlDataReader reader = db.Select(command);

            Collection<Auction> auctions = Read(reader, false);
            reader.Close();
            db.Close();
            return auctions;
        }

        /**
         * Select the record.
         **/
        public Auction SelectOne(int idAuction)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.Add(new SqlParameter("@idAuction", SqlDbType.Int));
            command.Parameters["@idAuction"].Value = idAuction;
            SqlDataReader reader = db.Select(command);

            Collection<Auction> auctions = Read(reader, true);
            Auction auction = null;
            if (auctions.Count == 1)
            {
                auction = auctions[0];
            }
            reader.Close();
            db.Close();
            return auction;
        }

        /**
         * complete = true - all attribute values must be read
         */ 
        private Collection<Auction> Read(SqlDataReader reader, bool complete)
        {
            Collection<Auction> auctions = new Collection<Auction>();

            while (reader.Read())
            {
                Auction auction = new Auction();
                int i = 0;
                auction.IdAuction = reader.GetInt32(i++);
                if (complete)
                {
                    auction.IdOwner = reader.GetInt32(i++);
                }
                auction.Name = reader.GetString(i++);
                auction.Description = reader.GetString(i++);
                if (complete)
                {
                    if (!reader.IsDBNull(i++))
                    {
                        auction.DescriptionDetail = reader.GetString(i); // desc detail is not always read
                    }
                }
                auction.Creation = reader.GetDateTime(i++);
                auction.End = reader.GetDateTime(i++);
                auction.IdCategory = reader.GetInt32(i++);
                auction.Category = new Category();
                auction.Category.IdCategory = auction.IdCategory;

                // bad solution: 
                // auction.Category = new CategoryTable().Select(auction.IdCategory); // read the record with the 1:1 relationship

                auction.MinBidValue = reader.GetInt32(i++);
                if (!reader.IsDBNull(i++))
                {
                    auction.MaxBidValue = reader.GetInt32(i);
                }
                if (!reader.IsDBNull(i++))
                {
                    auction.IdMaxBidUser = reader.GetInt32(i);
                }

                auction.Category.Name = reader.GetString(i++);

                auctions.Add(auction);
            }
            return auctions;
        }

        /**
         * Delete the record.
         */
        public int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.Add(new SqlParameter("@idAuction", SqlDbType.Int));
            command.Parameters["@idAuction"].Value = id;
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }
    }
}