﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Exhibitor/ExhibitorMaster.master" AutoEventWireup="true" CodeFile="boothallocation.aspx.cs" Inherits="Exhibitor_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: center;
        }
        .auto-style2 {
            font-size: medium;
            color: red;
        }
        .auto-style3 {
            font-size: x-large;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View2" runat="server">
            

            <h1 class="auto-style3">Booth Allocation</h1>
           <p> <marquee direction="left" class="auto-style2"><asp:Label ID="Label4" runat="server" Text=""></asp:Label></marquee></p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="requestid"
                onselectedindexchanged="GridView1_SelectedIndexChanged" 
                onrowcommand="GridView1_RowCommand" CellPadding="4" ForeColor="#333333" 
                GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="expotitle" HeaderText="exponame" 
                        SortExpression="expoid" />
                    <asp:BoundField DataField="companyname" HeaderText="companyname" 
                        SortExpression="companyname" />
                    <asp:BoundField DataField="description" HeaderText="description" 
                        SortExpression="description" />
                    <asp:TemplateField HeaderText="Allocate">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server"  CommandArgument='<%# Eval("requestid") %>' CommandName="allocate">Allocate</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
               
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
               
            </asp:GridView>

        </asp:View>
        <asp:View ID="View1" runat="server">
        
    <table class="style1">
        <tr>
            <td class="style2" colspan="2" style="font-weight: 700">
                BOOTH ALLOCATION</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Expo Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="246px"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Booth Number"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="booth" runat="server" CssClass="textbox" AutoPostBack="True" 
                    ontextchanged="booth_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Company Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlcompny" runat="server" CssClass="textbox" 
                    onselectedindexchanged="ddlcompny_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server"  style="height:40px;width:120px; border-radius: 5px;
    background-color: sandybrown;" Text="Allocate" 
                    onclick="Button1_Click" />
            </td>
        </tr>
    </table></asp:View> </asp:MultiView>
</asp:Content>

