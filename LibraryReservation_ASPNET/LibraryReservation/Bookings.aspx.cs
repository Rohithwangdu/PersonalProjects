using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryReservation
{
    public partial class Bookings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                //GridView1.DataSource = GetData("SELECT id,roomno,floorno,timefrom,timeto from booking");
                GridView1.DataBind();
                FillGrid();
               // GridView1.DataBind();
            }
            
        }
        /*
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the DropDownList in the Row
                DropDownList ddlCountries = (e.Row.FindControl("ddlCountries") as DropDownList);
                ddlCountries.DataSource = GetData("SELECT * from numbers");
                ddlCountries.DataTextField = "timefromddl";
                ddlCountries.DataValueField = "timefromddl";
                ddlCountries.DataBind();

                //Add Default Item in the DropDownList
                ddlCountries.Items.Insert(0, new ListItem("Please select"));

                //Select the Country of Customer in DropDownList
                string country = (e.Row.FindControl("lbltimefrom") as Label).Text;
                ddlCountries.Items.FindByValue(country).Selected = true;
            }
        }
        */
        protected void grdContact_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ContactTableAdapter contact = new ContactTableAdapter();
            //bool flag = false;
            if (e.CommandName.Equals("Insert"))
            {
                //TextBox txtNewName =
                //  (TextBox)GridView1.FooterRow.FindControl("txtNewName");
                //CheckBox chkNewActive =
                //  (CheckBox)GridView1.FooterRow.FindControl("chkNewActive");
                //DropDownList cmbNewType =
                //  (DropDownList)GridView1.FooterRow.FindControl("cmbNewType");
                //DropDownList ddlNewSex =
                //  (DropDownList)GridView1.FooterRow.FindControl("ddlNewSex");
                //if (chkNewActive.Checked) flag = true; else flag = false;

                TextBox id = (TextBox)GridView1.FooterRow.FindControl("insertid");
                //TextBox roomno = (TextBox)GridView1.FooterRow.FindControl("insertroomno");
                DropDownList roomno = (DropDownList)GridView1.FooterRow.FindControl("insertroomno");
               // TextBox floorno = (TextBox)GridView1.FooterRow.FindControl("insertfloorno");
                DropDownList floorno = (DropDownList)GridView1.FooterRow.FindControl("insertfloorno");
                TextBox timefrom = (TextBox)GridView1.FooterRow.FindControl("inserttimefrom");
                TextBox timeto = (TextBox)GridView1.FooterRow.FindControl("inserttimeto");
                //TextBox txtName = (TextBox)GridView1.HeaderRow.FindControl("txtName");
                //contact.Insert(txtNewName.Text, ddlNewSex.SelectedValue,
                //               cmbNewType.SelectedValue, flag);
                contact.Insert(Convert.ToInt32(id.Text), Convert.ToInt32(roomno.SelectedValue.ToString()), Convert.ToInt32(floorno.SelectedValue.ToString()),
               Convert.ToInt32(timefrom.Text), Convert.ToInt32(timeto.Text));
                FillGrid();
            }
        }

        protected void grdContact_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ContactTableAdapter contact = new ContactTableAdapter();
            //bool flag = false;
            int index = GridView1.EditIndex;
            GridViewRow row = GridView1.Rows[index];

            TextBox id = row.FindControl("TextBox1") as TextBox;
            TextBox roomno = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2");
            TextBox floorno = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox3");
            TextBox timefrom = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox4");
            TextBox timeto = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox5");
            //TextBox txtName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtName");
            //CheckBox chkActive =
            //  (CheckBox)GridView1.Rows[e.RowIndex].FindControl("chkActive");
            //DropDownList cmbType =
            //  (DropDownList)GridView1.Rows[e.RowIndex].FindControl("cmbType");
            //DropDownList ddlSex =
            //  (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlSex");
            //if (chkActive.Checked) flag = true; else flag = false;
            contact.Update(Convert.ToInt32(id.Text), Convert.ToInt32(roomno.Text), Convert.ToInt32(floorno.Text),
                Convert.ToInt32(timefrom.Text), Convert.ToInt32(timeto.Text));
            GridView1.EditIndex = -1;
            FillGrid();

        }
        protected void grdContact_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            FillGrid();
        }
        protected void grdContact_RowCancelingEdit(object sender,
                                  GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            FillGrid();
        }

        protected void grdContact_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string bookingid = GridView1.DataKeys[e.RowIndex].Values["bookingid"].ToString();
            ContactTableAdapter contact = new ContactTableAdapter();
            int id = Convert.ToInt32(bookingid);
            contact.Delete(id);
            FillGrid();
        }

        protected void grdContact_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //ContactTypeTableAdapter contactType = new ContactTypeTableAdapter();
            //DataTable contactTypes = contactType.GetData();
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Label lblType = (Label)e.Row.FindControl("lblType");
            //    if (lblType != null)
            //    {
            //        int typeId = Convert.ToInt32(lblType.Text);
            //        lblType.Text = (string)contactType.GetTypeById(typeId);
            //    }
            //    DropDownList cmbType = (DropDownList)e.Row.FindControl("cmbType");
            //    if (cmbType != null)
            //    {
            //        cmbType.DataSource = contactTypes;
            //        cmbType.DataTextField = "TypeName";
            //        cmbType.DataValueField = "Id";
            //        cmbType.DataBind();
            //        cmbType.SelectedValue =
            //          grdContact.DataKeys[e.Row.RowIndex].Values[1].ToString();
            //    }
            //}
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    DropDownList cmbNewType = (DropDownList)e.Row.FindControl("cmbNewType");
            //    cmbNewType.DataSource = contactTypes;
            //    cmbNewType.DataBind();
            //}
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string bookingid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "bookingid"));
                Button lnkbtnresult = (Button)e.Row.FindControl("ButtonDelete");
                if (lnkbtnresult != null)
                {
                    lnkbtnresult.Attributes.Add("onclick", "javascript:return deleteConfirm('" + bookingid + "')");
                }
                
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DropDownList ddList = (DropDownList)e.Row.FindControl("insertfloorno");
                ContactTableAdapter contact = new ContactTableAdapter();
                //return DataTable havinf department data
                DataTable dt = contact.GetFloors();
                ddList.DataSource = dt;
                ddList.DataTextField = "floorno";
                ddList.DataValueField = "floorno";
                ddList.DataBind();

                //DataRowView dr = e.Row.DataItem as DataRowView;
                //ddList.SelectedValue = dr["insertroomno"].ToString();
            }
            
            //ContactTableAdapter contact = new ContactTableAdapter();
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
                //GridView1.DataBind();
                //Find the DropDownList in the Row
                //if (Convert.ToInt32(e.Row.Cells[0].Text) < 10000)
                //{
                //    e.Row.BackColor = System.Drawing.Color.AliceBlue;
                //}  
            //}
        }
     
        public void FillGrid()
        {
            ContactTableAdapter contact = new ContactTableAdapter();
            DataSet contacts = contact.GetData("select id,roomno,floorno,timefrom,timeto,bookingid from booking");
            if (contacts.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = contacts;
                GridView1.DataBind();
            }
            else
            {
                contacts.Tables[0].Rows.Add(contacts.Tables[0].NewRow());
                GridView1.DataSource = contacts;
                GridView1.DataBind();

                int TotalColumns = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                GridView1.Rows[0].Cells[0].Text = "No Record Found";
            }
        }

        protected void insertfloorno_SelectedIndexChanged(object sender, EventArgs e)
        {  
            BindDropDownList2(((DropDownList)GridView1.FooterRow.FindControl("insertfloorno")).SelectedValue);
        }
        private void BindDropDownList2(string field)
         {
        DataTable dt = new DataTable();
        string conString = ConfigurationManager.ConnectionStrings["PracticeDBConnectionString"].ConnectionString;
        SqlConnection conn=new SqlConnection(conString);
        try
        {
            
            string sqlStatement = "SELECT roomno FROM librooms WHERE floorno = @floono";
            SqlCommand sqlCmd = new SqlCommand(sqlStatement, conn);
            sqlCmd .Parameters.AddWithValue("@floono", Convert.ToInt32(field));
            sqlCmd.Connection=conn;
            conn.Open();
            dt.Load(sqlCmd.ExecuteReader());
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                DropDownList ddList = ((DropDownList)GridView1.FooterRow.FindControl("insertroomno"));
                ddList.DataSource = dt;
                ddList.DataTextField = "roomno";
                ddList.DataValueField = "roomno";
                ddList.DataBind();
            }
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Fetch Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            conn.Close();
        }
    }
    }
    public class ContactTableAdapter
    {
        string conString = ConfigurationManager.ConnectionStrings["PracticeDBConnectionString"].ConnectionString.ToString();
        public void Delete(int id)
        {
            SqlConnection conn = new SqlConnection(conString);
            string cmdtxt = @"delete from booking where bookingid=@id";
            SqlCommand cmd = new SqlCommand(cmdtxt);
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        
        public void Update(int id,int roomno,int floorno,int timefrom,int timeto)
        {
            SqlConnection conn = new SqlConnection(conString);
            //string cmdtxt = @"update booking set id=@id,roomno=@roomno,floorno=@floorno,timefrom=@timefrom, timeto=@timeto where bookingid=@id";
            string cmdtxt = @"update booking set id=@id,roomno=@roomno,floorno=@floorno,timefrom=@timefrom, timeto=@timeto where id=@id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdtxt;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@id"].Value = id;
            cmd.Parameters.Add("@roomno", SqlDbType.Int);
            cmd.Parameters["@roomno"].Value = roomno;
            cmd.Parameters.Add("@floorno", SqlDbType.Int);
            cmd.Parameters["@floorno"].Value = floorno;
            cmd.Parameters.Add("@timefrom", SqlDbType.Int);
            cmd.Parameters["@timefrom"].Value = timefrom;
            cmd.Parameters.Add("@timeto", SqlDbType.Int);
            cmd.Parameters["@timeto"].Value = timeto;

            //cmd.Parameters.AddWithValue("@id", id);
            //cmd.Parameters.AddWithValue("@roomno", roomno);
            //cmd.Parameters.AddWithValue("@floorno", floorno);
            //cmd.Parameters.AddWithValue("@timefrom", timefrom);
            //cmd.Parameters.AddWithValue("@timeto", timeto);
            
            cmd.Connection = conn;
            conn.Open();
            //SqlDataReader reader = cmd.ExecuteReader();
            int n=cmd.ExecuteNonQuery();
            conn.Close();
            //Bookings obj = new Bookings();
            //obj.FillGrid();
        }

        public void Insert(int id, int roomno, int floorno, int timefrom, int timeto)
        {
            SqlConnection conn = new SqlConnection(conString);
            string cmdtxt = @"insert into booking(id,roomno,floorno,timefrom,timeto) 
                        values(@id,@roomno,@floorno,@timefrom,@timeto)";
            SqlCommand cmd = new SqlCommand(cmdtxt);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@roomno", roomno);
            cmd.Parameters.AddWithValue("@floorno", floorno);
            cmd.Parameters.AddWithValue("@timefrom", timefrom);
            cmd.Parameters.AddWithValue("@timeto", timeto);
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public DataSet GetData(string query)
        {
            string conString = ConfigurationManager.ConnectionStrings["PracticeDBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        sda.Fill(ds);
                        return ds;
                    }
                }
            }
        }

        public DataTable GetFloors()
        {
            string conString = ConfigurationManager.ConnectionStrings["PracticeDBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand(@"select distinct floorno from librooms");
            SqlConnection con = new SqlConnection(conString);
            cmd.Connection=con;
            DataTable dt = new DataTable();
            con.Open();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

    }
}
