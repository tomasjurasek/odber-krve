<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="User.aspx.cs" Inherits="AuctionWebApp.Form.User" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <p><asp:GridView ID="GridViewUser" runat="server" DataKeyNames="id" 
    AllowPaging="True" DataSourceID="odsUser">
    <Columns>
      <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True"/>
    </Columns>
  </asp:GridView></p>

  <p><asp:DetailsView ID="DetailsViewUser" runat="server"
    AutoGenerateRows="true" DataSourceID="odsUserDetail" 
    DataKeyNames="id">
    <Fields>
        <asp:CommandField ShowEditButton="True" ShowInsertButton="True"/>
    </Fields>
  </asp:DetailsView></p>

  <asp:ObjectDataSource ID="odsUser" runat="server" 
     TypeName="AuctionWebApp.Database.UserTable" 
    SelectMethod="Select"  DeleteMethod="Delete">
    <DeleteParameters>
      <asp:ControlParameter Type="Int32" Name="id" ControlID="GridViewUser"></asp:ControlParameter>
    </DeleteParameters>
  </asp:ObjectDataSource> 

  <asp:ObjectDataSource ID="odsUserDetail" runat="server" 
    TypeName="AuctionWebApp.Database.UserTable" 
    DataObjectTypeName="AuctionWebApp.Database.User"
    SelectMethod="Select" InsertMethod="Insert" UpdateMethod="Update">
    <SelectParameters>
      <asp:ControlParameter PropertyName="SelectedValue" Type="Int32" Name="id" 
      ControlID="GridViewUser" DefaultValue="1"></asp:ControlParameter>
    </SelectParameters>
  </asp:ObjectDataSource>
</asp:Content>