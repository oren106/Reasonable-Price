using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;




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
        SqlConnection cs;
        SqlDataAdapter ad;
        basicConnection(out cs, out ad);
        ad.InsertCommand = new SqlCommand("INSERT INTO raw VALUES(@name, @place,@city,@price,@amount,@currency,@messurmant)", cs);
        ad.InsertCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = get_name();
        ad.InsertCommand.Parameters.Add("@price", SqlDbType.Int).Value = get_price();
        ad.InsertCommand.Parameters.Add("@place", SqlDbType.VarChar).Value = get_place();
        ad.InsertCommand.Parameters.Add("@city", SqlDbType.VarChar).Value = get_city();
        ad.InsertCommand.Parameters.Add("@amount", SqlDbType.Int).Value = get_amount();
        ad.InsertCommand.Parameters.Add("@currency", SqlDbType.Int).Value = get_currency();
        ad.InsertCommand.Parameters.Add("@messurmant", SqlDbType.Int).Value = get_messurment();
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
        SqlConnection cs= new SqlConnection("Data Source=JOW-E76F4B0F945;Initial Catalog=dbrps;Integrated Security=True;Pooling=False");
        string queryString = "SELECT * FROM raw WHERE (name = '" + get_name() + "')";
        SqlCommand command = new SqlCommand(queryString, cs);
        cs.Open();
        SqlDataReader reader = command.ExecuteReader();
        double a, b;
        b = (get_price() * get_currency()) / (get_amount() * forCalc(get_messurment())); 
        try
        {
            while (reader.Read())
            {
                a = (((int)reader[5] * (int)reader[7]) / ((int)reader[6] * forCalc((int)reader[8])));
                if (a < b)
                    i++;
                else
                    i--;
            }
        }
        finally
        {
            // Always call Close when done reading.
            cs.Close();
        }

        return i;
    }

    private static void basicConnection(out SqlConnection cs, out SqlDataAdapter ad)
    {
        cs = new SqlConnection("Data Source=JOW-E76F4B0F945;Initial Catalog=dbrps;Integrated Security=True;Pooling=False");
        ad = new SqlDataAdapter();
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