﻿//Authors Oren adler, Yossi Eden
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Data.SQLite;


namespace rps.Old_App_Code
{
    /// <summary>
    /// The class which is in charge of doing the calculation and interperting the user input
    /// </summary>
    public class Interpartor
    {
        private prodInfo product;
        private DBMInterface dbm;
        /// <summary>
        /// The data base path
        /// </summary>
        private string DBPath = @"data source=C:\rps\rpsDB";
        /// <summary>
        /// The coulmn names in the database in the order they are placed in the database
        /// </summary>
        private string clm = "name,place,city,price,amount,currency,messurmant,timeSpan";

        /// <summary>
        /// Then interperter constructor
        /// </summary>
        /// <param name="prod">The product the user entered</param>
        public Interpartor(prodInfo prod)
        {
            product = new prodInfo(prod);
            dbm = new DBM(DBPath);
        }

        /// <summary>
        /// Calculates if the products price is reasonable 
        /// </summary>
        /// <returns>int with the  calculated number</returns>
        public int getAns()
        {
            SQLiteDataReader rd;
            double crt, sumPrice = 0, sumAmount = 0, dstnce = 0, avg = 0, x;
            dbm.save(product.sqlToString(), "raw", clm);
            rd = (SQLiteDataReader) dbm.retriveData(product.get_name(), "raw");
            crt = (product.get_price() * product.get_currency()) / (product.get_amount() * forCalc(product.get_messurment()));
            try
            {
                double aPrice, aCurrency, aAmount, aMessurment;
                while (rd.Read())
                {
                    aPrice = rd.GetDouble(4);
                    aCurrency = rd.GetInt16(6);
                    aAmount = rd.GetDouble(5);
                    aMessurment = forCalc(rd.GetInt32(7));
                    sumPrice = sumPrice + (aPrice * aCurrency);
                    sumAmount = sumAmount + (aAmount * aMessurment);
                    x = (aPrice * aCurrency) / (aAmount * aMessurment);
                    avg = sumPrice / sumAmount;
                    dstnce = dstnce + (Math.Abs(x - avg) * (aAmount * aMessurment));
                }
            }
            finally
            {
                rd.Close();
                dbm.close_connection();
            }
            dbm.dispose();
            rd.Dispose();
            dstnce = dstnce / sumAmount;
            return (int)ansCalc(crt, avg, dstnce);
        }

        private int ansCalc(double price, double avg, double dstnce)
        {
            double arrow, unit;
            arrow = price - avg;
            unit = dstnce / 3;
            arrow = arrow / unit;
            if (arrow > 4)
                arrow = 4;
            if (-3 > arrow)
                arrow = -3;
            arrow = arrow + 4;
            return (int)arrow;

        }

        private int aCalc(double price, double avg, double dstnce)
        {
            double arrow, unit;
            arrow = price - avg;
            unit = arrow / 3;
            arrow = arrow / unit;
            if (arrow > 4)
                arrow = 4;
            if (-3 > arrow)
                arrow = -3;
            arrow = +4;
            return (int)arrow;

        }
        private int forCalc(int i)
        {
               switch (i)
            {
                case 1: return 1000;
                case 2: return 1;
                case 3: return 1000;
                case 4: return 1;
                default: return 1;
            }
        }

            
    }




    }
