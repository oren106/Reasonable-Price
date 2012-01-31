//Authors Oren adler, Yossi Eden
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
//Authors Oren adler, Yossi Eden
using System.Text;
using System.Data.SQLite;
using NUnit.Framework;


namespace rps.Old_App_Code
{
    /// <summary>
    /// The class that describes a product
    /// </summary>
    public class prodInfo
    {
        private string prod_name;
        private string prod_place;
        private string prod_city;
        private int prod_price;
        private int prod_amount;
        private short prod_currency; //1=shekel, 2=dollar
        private short prod_messurment;// 1=kg, 2=gr, 3=Liter, 4=mililiter
        private int timeSpan;

        /// <summary>
        ///The product constructor
        /// </summary>
        /// <param name="name">The product name</param>
        /// <param name="place">The place where the product was bought</param>
        /// <param name="city">the city where the product was bought</param>
        /// <param name="price">The product price</param>
        /// <param name="currency">The local currency</param>
        /// <param name="messurment">The product measurment</param>
        /// <param name="amount">The amount bought</param>
        /// <param name="_timeSpan">The time took for the user to submit</param>
        public prodInfo(string name, string place, string city, int price, short currency, short messurment, int amount, int _timeSpan)
        {
            prod_name = name;
            prod_place = place;
            prod_price = price;
            prod_city = city;
            prod_amount = amount;
            prod_currency = currency;
            prod_messurment = messurment;
            timeSpan = _timeSpan;
        }
        /// <summary>
        /// The product constructor
        /// </summary>
        /// <param name="prod">the product to copy</param>
        public prodInfo(prodInfo prod)
        {
            prod_name = prod.get_name();
            prod_place = prod.get_place();
            prod_city = prod.get_city();
            prod_amount = prod.get_amount();
            prod_currency = prod.get_currency();
            prod_messurment = prod.get_messurment();
            prod_price = prod.get_price();
            timeSpan = prod.timeSpan;
        }
        /// <summary>
        /// Returns the products name
        /// </summary>
        /// <returns>string with the products name</returns>
        public string get_name()
        {
            return prod_name;
        }

        /// <summary>
        /// returns the products place
        /// </summary>
        /// <returns>string with the products place</returns>
        public string get_place()
        {
            return prod_place;
        }

        /// <summary>
        /// Returns the time took to submit
        /// </summary>
        /// <returns>int with the time took to submit</returns>
        public int get_timeSpan()
        {
            return timeSpan;
        }

        /// <summary>
        /// Returns the city the product was bought
        /// </summary>
        /// <returns>string with the city the product was bought</returns>
        public string get_city()
        {
            return prod_city;
        }

        /// <summary>
        /// Returns the amount bought
        /// </summary>
        /// <returns>int wiht the  amount bought</returns>
        public int get_amount()
        {
            return prod_amount;
        }

        /// <summary>
        /// Returns the product price
        /// </summary>
        /// <returns>int wiht the products price</returns>
        public int get_price()
        {
            return prod_price;
        }

        /// <summary>
        /// Returns the measurments
        /// </summary>
        /// <returns>short with the measurments 1=kg, 2=gr, 3=Liter, 4=mililiter</returns>
        public short get_messurment()
        {
            return prod_messurment;
        }

        /// <summary>
        /// Returns the local currency
        /// </summary>
        /// <returns>short with the local currency 1=shekel, 2=dollar</returns>
        public short get_currency()
        {
            return prod_currency;
        }

        /// <summary>
        /// Returns the products information as a sql string
        /// </summary>
        /// <returns>string with the  sql string of the products information</returns>
        public string sqlToString()
        {
            string text;
            text = "'" + get_name() + "'" + "," + "'" + get_place() + "'" + "," + "'" + get_city() + "'" + "," + "'" + get_price() + "'" + "," + "'" + get_amount() + "'" +
                   "," + "'" + get_currency() + "'" + "," + "'" + get_messurment() + "'" + "," + "'" + timeSpan + "'";
            return text;
        }

    }
}