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
        if (!IsPostBack)
        {

            dr=d.dataread("SELECT expoId FROM expodetails WHERE exhibitorId ='" + Session["userid"] + "'");
            if (!dr.Read())
            {
                Label4.Text = "Nothing to display";
            }

        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ticket")
        {
            MultiView1.ActiveViewIndex = 1;
            dr = d.dataread("select expotitle from expodetails where expoid='" + e.CommandArgument + "'");
            if (dr.Read())
            {
                Label1.Text = dr["expotitle"].ToString();
            }
            //d.execute("update expodetails set status='pending' where expoid='" + e.CommandArgument.ToString() + "'");
        }
        Session["tid"] = e.CommandArgument.ToString();
    }
    protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int m = d.execute("insert into exbaddticket values('" + Session["tid"] + "','" + DropDownList1.SelectedValue + "','" + TextBox1.Text + "')");
        if (m > 0)
        {
            Response.Write("<script>alert('ADDED SUCCESSFULLY')</script/>");
            GridView2.DataBind();
        }

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = e.RowIndex;
            string tid = GridView2.DataKeys[id].Value.ToString();
            d.execute("delete from exbaddticket where ticketId='" + tid + "'");
             Label5.Text = "Dleted Successfully...";
            GridView2.DataBind();
        }
        catch(Exception f)
        {
 Label5.Text = "Dleted Successfully...";
        }
       
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }



    protected void SqlDataSource3_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
}