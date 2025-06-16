using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    String constr = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=true;";

    protected void Page_Load(object sender, EventArgs e)
    {   
            Show();    
    }

    public void Show()
    {
        using (SqlConnection conn = new SqlConnection(constr))
        {
            SqlCommand cmd = new SqlCommand("GetAllStudents", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            grid.DataSource = ds;
            grid.DataBind();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Name = txtName.Text;
        string Age = txtAge.Text;

        using (SqlConnection conn = new SqlConnection(constr))
        {
            conn.Open();

            SqlCommand cmd;

            //Check if we are updating or inserting
            if (btnsave.Text == "Update")
            {
                cmd = new SqlCommand("UpdateStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", hdn.Value);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Age", Age);
                cmd.ExecuteNonQuery();

                btnsave.Text = "submit";
            }
            else
            {
                cmd = new SqlCommand("InsertStudents", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Age", Age);
                cmd.ExecuteNonQuery();
            }
        }

        txtName.Text = txtAge.Text = "";
        hdn.Value = "";
        Show();
    }

    protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteData")
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DeleteStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", e.CommandArgument);
                cmd.ExecuteNonQuery();
            }

            Show();
        }

        //Edit functionality
        else if (e.CommandName == "EditRecord")
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Students WHERE ID = @ID", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", e.CommandArgument);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["Name"].ToString();
                    txtAge.Text = dt.Rows[0]["Age"].ToString();
                    hdn.Value = dt.Rows[0]["ID"].ToString();
                    btnsave.Text = "Update";
                }
            }
        }
    }
}

