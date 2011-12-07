using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Interpartor
/// </summary>
public class Interpartor
{
   //The interpartor recives the input from the user and split the string and then 
    //sends the plit string to the class inchsrge of retrivig the data from the data base.
    private string product;
    private int price;
    private string place;
    public Interpartor(string msg)
    {
        string middle;
        string[] matched;
        Regex reg = new Regex("[0-9]+[\\s]*kg[\\s]*"); //the regex to split the input 
        matched = reg.Split(msg);
        place = matched[0];
        middle = reg.Match(msg).ToString();
        place = matched[1];
        middle = Regex.Match(middle, "[0-9]*").ToString();
        price = Convert.ToInt32(middle);
        product = matched[0];
    }

    //will return the answer 
    public string getAns()
    {
        return price.ToString();
    }

    

}