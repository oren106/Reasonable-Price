//Authors Sephora Ben-Israel, Erez Najar
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using rps.Old_App_Code;

/// <summary>
/// The code of the main page
/// </summary>
public partial class main : System.Web.UI.Page
{
    private prodInfo product;
    private Interpartor inter;
    protected string text;
    DateTime start;

    /// <summary>
    /// Gets the time the user entered the page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        start = DateTime.Now;
    }

    /// <summary>
    /// Rediriects the user to the answer page with an answer string
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void send_Click(object sender, EventArgs e)
    {
        int timeSpan = GetTimeSpan(start);
        product = new prodInfo(TextName.Text, TextPlace.Text, TextCity.Text, Convert.ToInt32(TextPrice.Text), Convert.ToInt16(DropDownCurrncy.SelectedValue), Convert.ToInt16(DropDownMessurment.SelectedValue), Convert.ToInt32(TextAmount.Text), timeSpan);
        inter = new Interpartor(product);
        Response.Redirect("Answer.aspx?" + inter.getAns());
        Response.Redirect("Answer.aspx?num=" + inter.getAns() + "&text=" + inter.noraml());
    }

    /// <summary>
    /// Gets the diffrance between the time the user entered till he submitted the page
    /// </summary>
    /// <param name="value">The value when entered the page</param>
    /// <returns>The diffrance between the value when entered the page till submited</returns>
    private static int GetTimeSpan(DateTime value)
    {
        return DateTime.Now.Subtract(value).Milliseconds;
    }
}
