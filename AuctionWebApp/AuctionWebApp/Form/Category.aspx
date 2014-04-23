<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="AuctionWebApp.Form.Category" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <p><asp:GridView ID="GridViewCategory" runat="server" DataKeyNames="idCategory" 
    AllowPaging="True" DataSourceID="odsCategory">
    <Columns>
      <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True"/>
    </Columns>
  </asp:GridView></p>

  <p><asp:DetailsView ID="DetailsViewCategory" runat="server"
    AutoGenerateRows="true" DataSourceID="odsCategoryDetail" 
    DataKeyNames="idCategory" OnDataBound="DetailsViewCategory_OnDataBound" 
    Width="50%" FieldHeaderStyle-Width="10%">
    <Fields>
      <asp:CommandField ShowEditButton="True" ShowInsertButton="True"/>
    </Fields>
  </asp:DetailsView></p>

  <asp:ObjectDataSource ID="odsCategory" runat="server" 
     TypeName="AuctionWebApp.Database.CategoryTable" 
    SelectMethod="Select"  DeleteMethod="Delete">
    <DeleteParameters>
      <asp:ControlParameter Type="Int32" Name="idCategory" ControlID="GridViewCategory"></asp:ControlParameter>
    </DeleteParameters>
  </asp:ObjectDataSource> 

  <asp:ObjectDataSource ID="odsCategoryDetail" runat="server" 
    TypeName="AuctionWebApp.Database.CategoryTable" 
    DataObjectTypeName="AuctionWebApp.Database.Category"
    SelectMethod="Select" InsertMethod="Insert" UpdateMethod="Update">
    <SelectParameters>
      <asp:ControlParameter PropertyName="SelectedValue" Type="Int32" Name="idCategory" 
      ControlID="GridViewCategory" DefaultValue="1"></asp:ControlParameter>
    </SelectParameters>
  </asp:ObjectDataSource>
</asp:Content>
