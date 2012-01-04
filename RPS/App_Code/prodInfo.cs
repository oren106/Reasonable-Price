using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SQLite;



/// <summary>
/// Summary description for Class1
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

    public prodInfo(string name, string place, string city, int price, short currency, short messurment, int amount)
    {
        prod_name = name;
        prod_place = place;
        prod_price = price;
        prod_city = city;
        prod_amount = amount;
        prod_currency = currency;
        prod_messurment = messurment;
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
    }
    public int save()
    {
        SQLiteConnection cs;
        SQLiteDataAdapter ad;
        basicConnection(out cs, out ad);
        ad.InsertCommand = new SQLiteCommand("INSERT INTO \"raw\" (name,place,city,price,amount,currency,messurmant) "+
                                                                 " VALUES ('"+get_name() + 
                                                                        "', '"+get_place() + 
                                                                        "', '"+get_city() + 
                                                                        "', "+get_price() + 
                                                                        ", "+get_amount() + 
                                                                        ", "+get_currency() + 
                                                                        ", "+get_messurment()+
                                                                        ");", cs);
        cs.Open();
        ad.InsertCommand.ExecuteNonQuery();
        cs.Close();
        return 0;
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
    public int calculate()
    {
        int i = 0;
        SQLiteConnection cs= new SQLiteConnection("data source=C:\\Documents and Settings\\user\\My Documents\\Visual Studio 2010\\WebSites\\RPS1\\rpsDB");
        string queryString = "SELECT * FROM raw WHERE (name = '" + get_name() + "')";
        SQLiteCommand command = new SQLiteCommand(queryString, cs);
        cs.Open();
        SQLiteDataReader reader = command.ExecuteReader();
        if (reader.FieldCount == 0)
            return 0;
        double a=0, b=0;
        b = (get_price() * get_currency()) / (get_amount() * forCalc(get_messurment())); 
        try
        {
            while (reader.Read())
            {
                //a = (((int)reader[5] * (int)reader[7]) / ((int)reader[6] * forCalc((int)reader[8])));
                i =  RandomNumber(-100000,100000);
                if (a > b)
                    i++;
                else
                    i--;
            }
        }
        finally
        {
            cs.Close();
        }

        return i;
    }
    private int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
    private static void basicConnection(out SQLiteConnection cs, out SQLiteDataAdapter ad)
    {
        cs = new SQLiteConnection("data source=C:\\Documents and Settings\\user\\My Documents\\Visual Studio 2010\\WebSites\\RPS1\\rpsDB");
        ad = new SQLiteDataAdapter();
    }


    public string get_name()
    {
        return prod_name;
    }

    public string get_place()
    {
        return prod_place;
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

    private string translate_currency()
    {
        switch (prod_currency)
        {
            case 1: return "shekel";
            case 2: return "dollar";
            default: return null;
        }
    }

    private string translate_messurment()
    {
        switch (prod_messurment)
        {
            case 1: return "Kg";
            case 2: return "gr";
            case 3: return "Liter";
            case 4: return "mililiter";
            default: return null;
        }
    }

    public string toString()
    {
        string space = " ";
        string text = (prod_name + space + prod_price + translate_currency() + space + prod_amount + translate_messurment() + space + prod_place + space + prod_city);
        return text;
    }

}