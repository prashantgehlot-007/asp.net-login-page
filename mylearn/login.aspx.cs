using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace mylearn
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\mylearn\mylearn\App_Data\data1.mdf;Integrated Security=True");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //registration page
            Response.Redirect("Registration.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //login page
            try
            {
                cmd = new SqlCommand("Select * From Users Where UId = @UId and UPass = @UPass", conn);
                cmd.Parameters.AddWithValue("@UId", TextBox1.Text);
                cmd.Parameters.AddWithValue("@UPass", TextBox2.Text);
                conn.Open();
                dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    //Response.Redirect("Myhome.aspx");
                    string fname = dr["FName"].ToString();
                    Response.Redirect("Myhome.aspx?name="+fname);
                }
                else
                {
                    Response.Write("wromg id/passowrd");
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}