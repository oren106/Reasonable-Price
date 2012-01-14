using System;
using System.IO;
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
public partial class prodInfo
{
    private string DBPath = @"data source=c:/app_data/rpsDB";


    private string prod_name;
    private string prod_place;
    private string prod_city;
    private int prod_price;
    private int prod_amount;
    private short prod_currency; //1=shekel, 2=dollar
    private short prod_messurment;// 1=kg, 2=gr, 3=Liter, 4=mililiter
    public int timeSpan { get; set; }
    private static string findDB()
    {
        return Environment.CurrentDirectory;
    }
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
    public int save()
    {
        SQLiteConnection cs = new SQLiteConnection(DBPath);
        SQLiteDataAdapter ad = new SQLiteDataAdapter();
        //SQLiteDateFormats date = (SQLiteDateFormats)DateTime.Now;
        ad.InsertCommand = new SQLiteCommand("INSERT INTO \"raw\" (name,place,city,price,amount,currency,messurmant,timeSpan) " +
                                                                 " VALUES ('" + get_name() +
                                                                        "', '" + get_place() +
                                                                        "', '" + get_city() +
                                                                        "', " + get_price() +
                                                                        ", " + get_amount() +
                                                                        ", " + get_currency() +
                                                                        ", " + get_messurment() +
                                                                        ", " + timeSpan +
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
        SQLiteConnection cs = new SQLiteConnection(DBPath);
        string qStrGetdata = "SELECT * FROM raw WHERE (name = '" + get_name() + "')";
        SQLiteCommand command = new SQLiteCommand(qStrGetdata, cs);
        cs.Open();
        SQLiteDataReader rd = command.ExecuteReader();
        if (!rd.HasRows)
            return 4;
        double crt, sumPrice = 0, sumAmount = 0, dstnce = 0, avg = 0, x;
        crt = (prod_price * prod_currency) / (prod_amount * forCalc(prod_messurment));
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
            cs.Close();
        }
        cs.Dispose();
        rd.Dispose();
        command.Dispose();
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
    public double kCalc()
    {
        double d = (get_price() * get_currency()) / (get_amount() * forCalc(get_messurment()));
        int i = get_messurment();
        switch (i)
        {
            case 1: return d;
            case 2: return 1000 * d;
            case 3: return d;
            case 4: return 1000 * d;
            default: return d;
        }
    }
    private int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
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
        string text;
        if (get_messurment() == 3 || get_messurment() == 4)
            text = "1 liter = ";
        else if (get_messurment() == 1 || get_messurment() == 2)
            text = "1 Kg = ";
        else
            text = "1 Unit = ";
        text = text + kCalc() + " " + translate_currency();
        return text;
    }
}