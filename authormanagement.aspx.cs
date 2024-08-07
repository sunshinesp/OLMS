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
    public partial class WebForm1 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // Go button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            getAuthorByID();
        }

        // Add buttton click
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExist())
            {
                Response.Write("<Script>alert('Author with this ID already exist.');</Script>");
            }
            else
            {
                addNewAuthor();
            }
        }

        // Update button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExist())
            {
                updateAuthor();
            }
            else
            {
                Response.Write("<Script>alert('Author does not esist.');</Script>");
            }
        }

        // Delete button click
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExist())
            {
                deleteAuthor();
            }
            else
            {
                Response.Write("<Script>alert('Author does not esist.');</Script>");
            }
        }


        // User defined functions

        void getAuthorByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(" SELECT * FROM author_master_tbl WHERE author_id = '" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<Script>alert('Invalid Author ID.');</Script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<Script>alert('" + ex.Message + "');</Script>");
               
            }
        }


        bool checkIfAuthorExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(" SELECT * FROM author_master_tbl WHERE author_id = '" + TextBox1.Text.Trim() + "'", con);
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

        void addNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id,author_name) VALUES(@author_id,@author_name)", con);
                cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<Script>alert('Author added Successfully.');</Script>");
                clearform();
                GridView1.DataBind();
            }

            catch (Exception ex)
            {
                Response.Write("<Script>alert('" + ex.Message + "');</Script>");
            }

        }

        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name = @author_name WHERE author_id = '" + TextBox1.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<Script>alert('Author updated Successfully.');</Script>");
                clearform();
                GridView1.DataBind();
            }

            catch (Exception ex)
            {
                Response.Write("<Script>alert('" + ex.Message + "');</Script>");
            }
        }

        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM author_master_tbl WHERE author_id = '" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<Script>alert('Author deleted Successfully.');</Script>");
                clearform();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<Script>alert('" + ex.Message + "');</Script>");
            }
        }

        void clearform()
        {
            TextBox1.Text = " ";
            TextBox2.Text = " ";
        }

       
    }
}