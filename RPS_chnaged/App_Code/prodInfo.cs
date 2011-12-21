﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

    public prodInfo(string name, string place, string city, int price,short currency, short messurment, int amount)
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
        string text = (prod_name + space + prod_price + translate_currency() + space +  prod_amount + translate_messurment() + space +  prod_place + space +  prod_city);
        return text;
    }

}