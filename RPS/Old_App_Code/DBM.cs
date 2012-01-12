using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace rps.Old_App_Code
{

    public class DBM : DBMInterface 
    {
        private SQLiteConnection cs;
        string dbPath;


        public DBM(string DBPath)
        {
            dbPath = DBPath;
        }
        
        public void set_connection()
            {
                cs = new SQLiteConnection(dbPath);
            }
        public void close_connection()
        {
            cs.Close();
        }

        public void open_connection()
        {
            cs.Open();
        }

        public void dispose()
        {
            cs.Dispose();
        }
            
        
         
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