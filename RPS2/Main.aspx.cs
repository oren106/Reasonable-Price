//The code for the main page
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
    public partial class _Default : System.Web.UI.Page
    {
        private prodInfo product;
        private Interpartor inter;
        protected string text;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        //what to do when the user clicks the ask button 
        protected void send_Click(object sender, EventArgs e)
        {

            product = new prodInfo(TextName.Text, TextPlace.Text, TextCity.Text, Convert.ToInt32(TextPrice.Text), Convert.ToInt16(DropDownCurrncy.SelectedValue), Convert.ToInt16(DropDownMessurment.SelectedValue), Convert.ToInt32(TextAmount.Text));
            inter = new Interpartor(product);
            Response.Redirect("Answer.aspx?" + inter.getAns());
        }
}
