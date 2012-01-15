//Authors Yossi Eden, Naftali Herskovitz
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rps.Old_App_Code
{
    /// <summary>
    /// An interface that describes what should a DBM class implement
    /// </summary>
    public interface DBMInterface
    {
        /// <summary>
        /// Sets a connection with the database
        /// </summary>
        void set_connection();

        /// <summary>
        /// Closes the connection with the database
        /// </summary>
        void close_connection();

        /// <summary>
        /// Opens a connection with the database
        /// </summary>
        void open_connection();


        /// <summary>
        /// Disposes the database connection
        /// </summary>
        void dispose();

        /// <summary>
        /// Saves the data into the database
        /// </summary>
        /// <param name="values">The values to be saved</param>
        /// <param name="tableName">The table where to save</param>
        /// <param name="clm">The coulmn names as they appear in the table</param>
        void save(string values, string tableName, string clm);

        /// <summary>
        /// Retrives the relevnt data from the database
        /// </summary>
        /// <param name="prod_name">The product name we want to retrive</param>
        /// <param name="tableName">The table name where we want to retrive</param>
        /// <returns>DbDataReader containing all the entries with the products name</returns>
        System.Data.Common.DbDataReader retriveData(string prod_name, string tableName);

    }
}