<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Auction.aspx.cs" Inherits="AuctionWebApp.Form.Auction" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h3>My Auctions</h3>
  <p><asp:GridView ID="GridViewAuction" runat="server" DataKeyNames="IdAuction" 
    AutoGenerateColumns="False"
    AllowPaging="True" DataSourceID="odsAuction">
    <Columns>
      <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True"/>
      <asp:BoundField DataField="IdAuction" HeaderText="IdAuction" SortExpression="idAuction"/>
      <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="name"/>
      <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="description"/>
      <asp:BoundField DataField="Creation" HeaderText="Creation" SortExpression="creation"/>
      <asp:BoundField DataField="End" HeaderText="End" SortExpression="end"/>
      <asp:TemplateField HeaderText="Category" SortExpression="Category">
        <ItemTemplate>
            <asp:Label ID="LabelCategory" runat="server" Text='<%# Eval("Category.Name") %>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField> 
      <asp:BoundField DataField="MinBidValue" HeaderText="Minimal Bid" SortExpression="MinBidValue"/>
      <asp:BoundField DataField="MaxBidValue" HeaderText="Maximal Bid" SortExpression="MaxBidValue"/>
      <asp:BoundField DataField="IdMaxBidUser" HeaderText="User with Maximal Bid" SortExpression="IdMaxBidUser"/>
    </Columns>
  </asp:GridView></p>

  <h3>Auction Detail</h3>
  <p><asp:DetailsView ID="DetailsViewAuction" runat="server"
    AutoGenerateRows="false" DataSourceID="odsAuctionDetail" DataKeyNames="idAuction"
    OnDataBound="DetailsViewAuction_OnDataBound">
    <Fields>
        <asp:BoundField DataField="IdAuction" HeaderText="idAuction"/>
        <asp:BoundField DataField="IdOwner" HeaderText="IdOwner"/>
        <asp:BoundField DataField="Name" HeaderText="Name"/>
        <asp:BoundField DataField="Description" HeaderText="Description"/>
        <asp:BoundField DataField="DescriptionDetail" HeaderText="Description Detail"/>
        <asp:BoundField DataField="Creation" HeaderText="Creation"/>
        <asp:BoundField DataField="End" HeaderText="End"/>

        <asp:TemplateField HeaderText="Category" SortExpression="Category">
            <ItemTemplate>
                <asp:Label ID="LabelCategory" runat="server" Text='<%# Eval("Category.Name") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ListCategory" runat="server" DataSourceID="odsCategory"
                    DataTextField="Name" DataValueField="IdCategory" SelectedValue='<%# Bind("IdCategory") %>'>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="ValidatorCategory" runat="server" ControlToValidate="ListCategory" 
                    ErrorMessage="Category is required" Display="None">
                </asp:RequiredFieldValidator>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:BoundField DataField="MinBidValue" HeaderText="Minimal Bid"/>
        <asp:BoundField DataField="MaxBidValue" HeaderText="Maximal Bid"/>
        <asp:BoundField DataField="IdMaxBidUser" HeaderText="User with Maximal Bid"/>
        <asp:CommandField ShowInsertButton="True"/>
    </Fields>
  </asp:DetailsView></p>

  <asp:ObjectDataSource ID="odsAuction" runat="server" 
     TypeName="AuctionWebApp.Database.AuctionTable" 
    SelectMethod="Select"  DeleteMethod="Delete">
    <DeleteParameters>
      <asp:ControlParameter Type="Int32" Name="IdAuction" ControlID="GridViewAuction"></asp:ControlParameter>
    </DeleteParameters>
    <SelectParameters>
        <asp:SessionParameter Name="IDUSER" SessionField="IDUSER" DefaultValue="1"/>
    </SelectParameters>
  </asp:ObjectDataSource> 

  <asp:ObjectDataSource ID="odsAuctionDetail" runat="server" 
    TypeName="AuctionWebApp.Database.AuctionTable" 
    DataObjectTypeName="AuctionWebApp.Database.Auction"
    SelectMethod="SelectOne" InsertMethod="Insert">
    <SelectParameters>
      <asp:ControlParameter PropertyName="SelectedValue" Type="Int32" Name="IdAuction" 
      ControlID="GridViewAuction" DefaultValue="1"></asp:ControlParameter>
    </SelectParameters>
  </asp:ObjectDataSource>

<asp:ObjectDataSource ID="odsCategory" runat="server" 
  TypeName="AuctionWebApp.Database.CategoryTable" SelectMethod="Select" >
</asp:ObjectDataSource>
</asp:Content>

