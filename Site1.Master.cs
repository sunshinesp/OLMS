using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace olms
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          /*  try
            {
                if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true;  // user login link button
                    LinkButton2.Visible = true;  // user sign up link button
                    LinkButton3.Visible = false;  // logout link button
                    LinkButton7.Visible = false;  // Hello User link button

                    LinkButton6.Visible = true;  // admin login link button
                    LinkButton11.Visible = false;  // author management link button
                    LinkButton12.Visible = false;  // publisher management link button
                    LinkButton8.Visible = false;  // book inventory link button
                    LinkButton9.Visible = false;  // book issuing link button
                    LinkButton10.Visible = false;  // member management link button  
                }

                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false;  // user login link button
                    LinkButton2.Visible = false;  // user sign up link button
                    LinkButton3.Visible = true;  // logout link button
                    LinkButton7.Visible = true;  // Hello User link button
                    LinkButton7.Text = "Hello" + Session["username"].ToString();

                    LinkButton6.Visible = true;  // admin login link button
                    LinkButton11.Visible = false;  // author management link button
                    LinkButton12.Visible = false;  // publisher management link button
                    LinkButton8.Visible = false;  // book inventory link button
                    LinkButton9.Visible = false;  // book issuing link button
                    LinkButton10.Visible = false;  // member management link button
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false;  // user login link button
                    LinkButton2.Visible = false;  // user sign up link button
                    LinkButton3.Visible = true;  // logout link button
                    LinkButton7.Visible = true;  // Hello User link button
                    LinkButton7.Text = "Hello Admin";

                    LinkButton6.Visible = false;  // admin login link button
                    LinkButton11.Visible = true;  // author management link button
                    LinkButton12.Visible = true;  // publisher management link button
                    LinkButton8.Visible = true;  // book inventory link button
                    LinkButton9.Visible = true;  // book issuing link button
                    LinkButton10.Visible = true;  // member management link button 

                } 
               
            }
            catch(Exception ex)
            {
                Response.Write("<Script>alert('" + ex.Message + "');</Script>");
            } */
        } 

        protected void LinkButton6_Click1(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("authormanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("publishermanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("bookinventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("bookissuingpage.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminMemberManagement.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["full_name"] = "";
            Session["role"] = "";
            Session["account_status"] = "";

            LinkButton1.Visible = true;  // user login link button
            LinkButton2.Visible = true;  // user sign up link button
            LinkButton3.Visible = false;  // logout link button
            LinkButton7.Visible = false;  // Hello User link button

            LinkButton6.Visible = true;  // admin login link button
            LinkButton11.Visible = false;  // author management link button
            LinkButton12.Visible = false;  // publisher management link button
            LinkButton8.Visible = false;  // book inventory link button
            LinkButton9.Visible = false;  // book issuing link button
            LinkButton10.Visible = false;  // member management link button

            Response.Redirect("homepage.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}