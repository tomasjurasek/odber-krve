using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AuctionWebApp.Database
{
    public class Database
    {
        // private static int TIMEOUT = 240;
        private SqlConnection mConnection;
        SqlTransaction mSqlTransaction = null;
        private String mLanguage = "en";
        // private static String CONNECTION_STRING = "server=dbsys.cs.vsb.cz\\STUDENT;database=dais;user=dais;password=tuo460DbEd;";

        public Database() 
        {
            mConnection = new SqlConnection();
        }

        /**
         * Connect.
         **/
        public bool Connect(String conString)
        {
            if (mConnection.State != System.Data.ConnectionState.Open)
            {
                mConnection.ConnectionString = conString;
                mConnection.Open();
            }
            return true;
        }

        /**
         * Connect.
         **/
        public bool Connect()
        {
            bool ret = true;

            if (mConnection.State != System.Data.ConnectionState.Open)
            {
                // ret = Connect(CONNECTION_STRING);
                ret = Connect(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            }

            return ret;
        }

        /**
         * Close.
         **/
        public void Close()
        {
            mConnection.Close();
        }

        /**
         * Begin a transaction.
         **/
        public void BeginTransaction()
        {
            mSqlTransaction = mConnection.BeginTransaction(IsolationLevel.Serializable);
        }

        /**
         * End a transaction.
         **/
        public void EndTransaction()
        {
            // command.Dispose()
            mSqlTransaction.Commit();
            Close();
        }

        /**
         * If a transaction is failed call it.
         **/
        public void Rollback()
        {
            mSqlTransaction.Rollback();
        }

        /**
         * Insert a record encapulated in the command.
         **/
        public int ExecuteNonQuery(SqlCommand command)
        {
            int rowNumber = 0;
            try
            {
                command.Prepare();
                rowNumber = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Close();
            }
            return rowNumber;
        }

        /**
         * Create command.
         **/
        public SqlCommand CreateCommand(string strCommand)
        {
            SqlCommand command = new SqlCommand(strCommand, mConnection);

            if (mSqlTransaction != null)
            {
                command.Transaction = mSqlTransaction;
            }
            return command;
        }

        /**
         * Select encapulated in the command.
         **/
        public SqlDataReader Select(SqlCommand command)
        {
            command.Prepare();
            SqlDataReader sqlReader = command.ExecuteReader();
            return sqlReader;
        }

        public String Language
        {
            get
            {
                return mLanguage;
            }
            set
            {
                mLanguage = value;
            }
        }
    }
}

