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
    prodInfo product;
    public Interpartor(prodInfo prod)
    {
        product = new prodInfo(prod);
    }

    //will return the answer 
    public int getAns()
    {
       
        return product.calculate();
    }

    

}