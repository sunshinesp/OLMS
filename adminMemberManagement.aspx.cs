using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace olms
{
    public partial class adminMemberManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // Go button click
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getMemberByID();
        }

        //Active button click
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateMemberStatus("active");
        }

        // Pending button click
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateMemberStatus("pending");
        }

        // Deactivate button click
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateMemberStatus("deactive");
        }

        // Permanently delete button click
        protected void Button2_Click(object sender, EventArgs e)
        {

        }


        // User defined functions

        void getMemberByID()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(" SELECT * FROM member_master_tbl WHERE member_id = '" + TextBox1.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while(dr.Read())
                    {
                        TextBox2.Text = dr.GetValue(0).ToString();
                        TextBox7.Text = dr.GetValue(10).ToString();
                        TextBox8.Text = dr.GetValue(1).ToString();
                        TextBox3.Text = dr.GetValue(2).ToString();
                        TextBox4.Text = dr.GetValue(3).ToString();
                        TextBox9.Text = dr.GetValue(4).ToString();
                        TextBox10.Text = dr.GetValue(5).ToString();
                        TextBox11.Text = dr.GetValue(6).ToString();
                        TextBox6.Text = dr.GetValue(7).ToString();
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Response.Write("<Script>alert('" + ex.Message + "');</Script>");
            }   
        }

        void updateMemberStatus(string status)
        {
            if(checkIfMemberExist())
            {
                try
                {
                    System.Data.SqlClient.SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand(" UPDATE member_master_tbl SET account_status = '" + status + "' WHERE member_id = '" + TextBox1.Text.Trim() + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<Script>alert('Member status updated.');</Script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<Script>alert('" + ex.Message + "');</Script>");
                }
            }
            else
            {
                Response.Write("<Script>alert('Invalid Member ID.');</Script>");
            }

        }

        void deleteMember()
        {
            if(checkIfMemberExist())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("DELETE FROM member_master_tbl WHERE member_id = '" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<Script>alert('Member deleted Successfully.');</Script>");
                    clearForm();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<Script>alert('" + ex.Message + "');</Script>");
                }
               
            }
            else
            {
                Response.Write("<Script>alert('Invalid Member ID.');</Script>");
            }
            
        }

        bool checkIfMemberExist()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(" SELECT * FROM member_master_tbl WHERE member_id = '" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<Script>alert('" + ex.Message + "');</Script>");
                return false;
            }
        }

        void clearForm()
        {
            TextBox2.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox4.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox6.Text = "";
        }
    }
}