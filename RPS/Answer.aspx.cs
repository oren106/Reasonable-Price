//The code for the answer  page
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


    public partial class _Default : System.Web.UI.Page
    {
        // what to do when the page loads
        protected void Page_Load(object sender, EventArgs e)
        {
            int num;
            string text = Request.QueryString.ToString();
            answer.Text = text;
            num = Convert.ToInt32(text);
            num = Math.Abs(num);
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
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
