﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Exhibitor_Default : System.Web.UI.Page
{
    data d = new data();
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            dr=d.dataread("SELECT companyId, logid, companyname, companytype, country, landmark FROM companyregist");
            if (!dr.Read())
            {
                Label4.Text = "Sorry!!!...Nothing To show...";
            }
        }
    }
    protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "invite")
        {
            Session["Iid"] = e.CommandArgument.ToString();
            MultiView1.ActiveViewIndex = 1; 
            //dr = d.dataread("select companyname from companyregist where companyid='" + e.CommandArgument + "'");
            //dr = d.dataread("select expotitle from expodetails where expoid='" + e.CommandArgument + "'");
            //if (dr.Read())
            //{
            //    Label1.Text = dr["expotitle"].ToString();
            //}
          //  d.execute("update  set status='invite' where companyid='" + e.CommandArgument.ToString() + "'");
        }
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int m = d.execute("insert into invitecompany values('" + DropDownList1.SelectedValue + "','" + Session["Iid"] + "','"+TextBox1.Text+"','Requested')");
        if (m > 0)
        {
            Response.Write("<script>alert('INVITED SUCCESSFULLY')</script/>");

        }
    }
    protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
}