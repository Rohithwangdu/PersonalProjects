<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Bookings.aspx.cs" Inherits="LibraryReservation.Bookings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    BOOKINGS
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">
    <asp:GridView ID="GridView1"
        DataKeyNames="bookingid"
         runat="server" 
        AutoGenerateColumns="False" 
        AutoGenerateEditButton="True"
        OnRowCancelingEdit="grdContact_RowCancelingEdit" 
        OnRowDataBound="grdContact_RowDataBound" 
        OnRowEditing="grdContact_RowEditing" 
        OnRowUpdating="grdContact_RowUpdating" ShowFooter="True" 
        OnRowCommand="grdContact_RowCommand" 
        OnRowDeleting="grdContact_RowDeleting"
        HorizontalAlign="Center"
        CssClass="mGrid"
        PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt">
        <%--DataSourceID="SqlDataSource1">--%>
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField HeaderText="id" SortExpression="id">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("id") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
        <asp:TextBox ID="insertid" width="40px" runat="server"/>
        <asp:RequiredFieldValidator ID="vstorid" runat="server" ControlToValidate="insertid" Text="?" ValidationGroup="validaiton"/>
    </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="roomno" SortExpression="roomno">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("roomno") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("roomno") %>'></asp:Label>
                </ItemTemplate>
                 <FooterTemplate>
                <asp:DropDownList ID="insertroomno" runat="server">
                </asp:DropDownList>      
        <%--<asp:DropDownList ID="insertroomno" width="40px" runat="server"/>--%>
        <%--<asp:RequiredFieldValidator ID="vstorroomno" runat="server" ControlToValidate="insertroomno" Text="?" ValidationGroup="validaiton"/>--%>
    </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="floorno" SortExpression="floorno">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("floorno") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("floorno") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="insertfloorno" runat="server" AutoPostBack="true" OnSelectedIndexChanged="insertfloorno_SelectedIndexChanged"></asp:DropDownList>
        <%--<asp:TextBox ID="insertfloorno" width="40px" runat="server"/>--%>
        <%--<asp:RequiredFieldValidator ID="vstorfloorno" runat="server" ControlToValidate="insertfloorno" Text="?" ValidationGroup="validaiton"/>--%>
    </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="timefrom" SortExpression="timefrom">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("timefrom") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("timefrom") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
        <asp:TextBox ID="inserttimefrom" width="40px" runat="server"/>
        <asp:RequiredFieldValidator ID="vstortimefrom" runat="server" ControlToValidate="inserttimefrom" Text="?" ValidationGroup="validaiton"/>
    </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="timeto" SortExpression="timeto">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("timeto") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("timeto") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
        <asp:TextBox ID="inserttimeto" width="40px" runat="server"/>
        <asp:RequiredFieldValidator ID="vstortimeto" runat="server" ControlToValidate="inserttimeto" Text="?" ValidationGroup="validaiton"/>
    </FooterTemplate>
            </asp:TemplateField>
<%--            <asp:TemplateField HeaderText = "timefromddl">
            <ItemTemplate>
                <asp:Label ID="lbltimefrom" runat="server" Text='<%# Eval("timefrom") %>' Visible = "false" />
                <asp:DropDownList ID="ddltimefrom" runat="server">
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>--%>
<asp:TemplateField>
    <EditItemTemplate>
        
        <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel"  Text="Cancel" />
    </EditItemTemplate>
    <ItemTemplate>
        
        <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete"  Text="Delete"  />
    </ItemTemplate>
    <FooterTemplate>
        <asp:Button ID="ButtonAdd" runat="server" CommandName="Insert"  Text="Add New Row" ValidationGroup="validaiton"  />
    </FooterTemplate>
 </asp:TemplateField>
           
            <asp:TemplateField HeaderText="bookingid" SortExpression="bookingid" Visible="false">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" ReadOnly="true" Text='<%# Bind("bookingid") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("bookingid") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PracticeDBConnectionString %>" SelectCommand="SELECT * FROM [booking]"></asp:SqlDataSource>
</asp:Content>
