using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SQLite;
using NUnit.Framework;


/// <summary>
/// Summary description for Class1
/// </summary>
namespace rps.Old_App_Code
{
    public class prodInfo : ProdInterface
    {
        private string prod_name;
        private string prod_place;
        private string prod_city;
        private int prod_price;
        private int prod_amount;
        private short prod_currency; //1=shekel, 2=dollar
        private short prod_messurment;// 1=kg, 2=gr, 3=Liter, 4=mililiter
        private int timeSpan;

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
  
        public string get_name()
        {
            return prod_name;
        }
        public string get_place()
        {
            return prod_place;
        }

        public int get_timeSpan()
        {
            return timeSpan;
        }
        public string get_city()
        {
            return prod_city;
        }
        public int get_amount()
        {
            return prod_amount;
        }
        public int get_price()
        {
            return prod_price;
        }
        public short get_messurment()
        {
            return prod_messurment;
        }
        public short get_currency()
        {
            return prod_currency;
        }

   
        public string sqlToString()
        {
            string text;
            text = "'"+ get_name() +"'" + ","+ "'" + get_place() + "'" + "," + "'" + get_city() + "'" + "," + "'" + get_price() + "'" + "," + "'" + get_amount() + "'" +
                   "," + "'" + get_currency() + "'" + "," + "'" + get_messurment() + "'" + "," + "'" + timeSpan + "'";
            return text;
        }

    }
}