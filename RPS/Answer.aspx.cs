﻿//Authors Sephora Ben-Israel, Erez Najar
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// The code of the answer page
/// </summary>
public partial class Answer : System.Web.UI.Page
{
    /// <summary>
    /// When the pages loads to show the rlevent picture depndent on the answer
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        int num;
        string text = Request.QueryString.ToString();
        answer.Text = Request.QueryString["text"];
        num = Convert.ToInt32(Request.QueryString["num"]);
        switch (num)
        {
            case 1:
                Image1.ImageUrl = "images/arrow1.jpg";
                break;
            case 2:
                Image1.ImageUrl = "images/arrow2.jpg";
                break;
            case 3:
                Image1.ImageUrl = "images/arrow3.jpg";
                break;
            case 4:
                Image1.ImageUrl = "images/arrow4.jpg";
                break;
            case 5:
                Image1.ImageUrl = "images/arrow5.jpg";
                break;
            case 6:
                Image1.ImageUrl = "images/arrow6.jpg";
                break;
            case 7:
                Image1.ImageUrl = "images/arrow7.jpg";
                break;
            case 8:
                Image1.ImageUrl = "images/arrow8.jpg";
                break;
            default:
                Image1.ImageUrl = "images/arrow8.jpg";
                break;
        }
    }

    /// <summary>
    /// Redricts the user to the main page when the back button is pressed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
}