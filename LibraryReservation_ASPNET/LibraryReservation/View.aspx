<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="LibraryReservation.View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    VIEW
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">
    <asp:GridView ID="GridView1" 
        runat="server" 
        AllowPaging="True" 
        AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1"
        horizontalalign="center"
        CssClass="mGrid"
        PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt">
    <Columns>
        <asp:BoundField DataField="id" HeaderText="StudentID" SortExpression="id" />
        <asp:BoundField DataField="roomno" HeaderText="RoomNumber" SortExpression="roomno" />
        <asp:BoundField DataField="floorno" HeaderText="FloorNumber" SortExpression="floorno" />
        <asp:BoundField DataField="timefrom" HeaderText="TimeFrom" SortExpression="timefrom" />
        <asp:BoundField DataField="timeto" HeaderText="TimeTo" SortExpression="timeto" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PracticeDBConnectionString %>" SelectCommand="SELECT * FROM [booking]"></asp:SqlDataSource>
</asp:Content>
