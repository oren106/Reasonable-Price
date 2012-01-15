//Authors Yossi Eden, Naftali Herskovitz
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace rps.Old_App_Code
{
    /// <summary>
    /// The class which manges the database (saving and retriving)
    /// </summary>
    public class DBM : DBMInterface 
    {
        private SQLiteConnection cs;
        string dbPath;

        /// <summary>
        /// The DBM constructor
        /// </summary>
        /// <param name="DBPath">The database path</param>
        public DBM(string DBPath)
        {
            dbPath = DBPath;
        }
        
        /// <summary>
        /// Sets a connection with the database
        /// </summary>
        public void set_connection()
            {
                cs = new SQLiteConnection(dbPath);
            }

        /// <summary>
        /// Closes the connection with the database
        /// </summary>
        public void close_connection()
        {
            cs.Close();
        }

        /// <summary>
        /// Opens a connection with the database
        /// </summary>
        public void open_connection()
        {
            cs.Open();
        }

        /// <summary>
        /// Disposes the database connection
        /// </summary>
        public void dispose()
        {
            cs.Dispose();
        }
            
        
         /// <summary>
         /// Saves the data into the database
         /// </summary>
         /// <param name="values">The values to be saved</param>
         /// <param name="tableName">The table where to save</param>
         /// <param name="clm">The coulmn names as they appear in the table</param>
        public void save(string values, string tableName, string clm)
        {
            set_connection();
            SQLiteDataAdapter ad = new SQLiteDataAdapter();
            string command;
            command = "INSERT INTO " +"\"" + tableName + "\"" + " (" + clm + ") " + "VALUES" + "(" + values + ");";

            ad.InsertCommand = new SQLiteCommand(command, cs);
            open_connection();
            ad.InsertCommand.ExecuteNonQuery();
            close_connection();
        }

        /// <summary>
        /// Retrives the relevnt data from the database
        /// </summary>
        /// <param name="prod_name">The product name we want to retrive</param>
        /// <param name="tableName">The table name where we want to retrive</param>
        /// <returns>DbDataReader containing all the entries with the products name</returns>
        public System.Data.Common.DbDataReader retriveData(string prod_name,string tableName)
        {
            SQLiteCommand cmd;
            SQLiteDataReader dataReader;
            string command = "SELECT * from " + tableName + " WHERE (name = '" + prod_name + "')";
            set_connection();
            cmd = new SQLiteCommand(command, cs);
            open_connection();
            dataReader = cmd.ExecuteReader();
            cmd.Dispose();
            if (!dataReader.HasRows)
                return null;
            else return dataReader;
        }
    }
}