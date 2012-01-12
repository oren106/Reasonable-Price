//The code for the main page
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using rps.Old_App_Code;
    public partial class main : System.Web.UI.Page
    {
        private prodInfo product;
        private Interpartor inter;
        protected string text;
        DateTime start;
        protected void Page_Load(object sender, EventArgs e)
        {
            start = DateTime.Now;
        }
        //what to do when the user clicks the ask button 
        protected void send_Click(object sender, EventArgs e)
        {
            int timeSpan = GetTimeSpan(start);
            product = new prodInfo(TextName.Text, TextPlace.Text, TextCity.Text, Convert.ToInt32(TextPrice.Text), Convert.ToInt16(DropDownCurrncy.SelectedValue), Convert.ToInt16(DropDownMessurment.SelectedValue), Convert.ToInt32(TextAmount.Text),timeSpan);
            inter = new Interpartor(product);
            Response.Redirect("Answer.aspx?" + inter.getAns());
        }
        private static int GetTimeSpan(DateTime value)
        {
            return DateTime.Now.Subtract(value).Milliseconds;
        }
}
