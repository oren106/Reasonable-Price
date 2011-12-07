//The code for the main page
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
    public partial class _Default : System.Web.UI.Page
    {
        private Interpartor inter;
        protected string text;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        //what to do when the user clicks the ask button 
        protected void Ask_Click(object sender, EventArgs e)
        {
            text = QuestionEntry.Text;
            inter = new Interpartor(text);
            //QuestionEntry.Text = inter.getAns().ToString();
            Response.Redirect("Answer.aspx?" + inter.getAns());
            //Response.Redirect("Answer.aspx?" + QuestionEntry.Text);
        }
      


    }
