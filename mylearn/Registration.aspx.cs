using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace mylearn
{
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\mylearn\mylearn\App_Data\data1.mdf;Integrated Security=True");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Registration page
            try
            {
                cmd = new SqlCommand("Insert Into Users (UId,UPass,FName,Gender,City) values(@UId,@UPass,@FName,@Gender,@City)", conn);
                cmd.Parameters.AddWithValue("@UId", TextBox1.Text);
                cmd.Parameters.AddWithValue("@UPass", TextBox2.Text);
                cmd.Parameters.AddWithValue("@FName", TextBox3.Text);

                if(RadioButton1.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Gender", RadioButton1.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Gender", RadioButton2.Text);
                }
                cmd.Parameters.AddWithValue("@City", DropDownList1.SelectedItem.ToString());
                conn.Open();
                cmd.ExecuteNonQuery();
                Response.Write("Registration done");
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