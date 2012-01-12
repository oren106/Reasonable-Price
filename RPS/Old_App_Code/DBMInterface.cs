using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rps.Old_App_Code
{
    public interface DBMInterface
    {
        void set_connection();
        void close_connection();
        void open_connection();
        void dispose();
        void save(string values, string tableName, string clm);
        System.Data.Common.DbDataReader retriveData(string prod_name, string tableName);

    }
}