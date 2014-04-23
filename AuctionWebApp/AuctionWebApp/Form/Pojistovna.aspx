<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pojistovna.aspx.cs" Inherits="AuctionWebApp.Form.Pojistovna" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    <asp:GridView ID="GridView1" runat="server" DataKeyNames="IdPojistovna" 
    AutoGenerateColumns="False"
    AllowPaging="True" DataSourceID="ObjectDataSource1">
        <Columns>
      <asp:CommandField ShowSelectButton="true" ShowDeleteButton="True"/>
      <asp:BoundField HeaderText="IdPojistovna"     DataField="IdPojistovna"  SortExpression="idpojistovna"/>
      <asp:BoundField HeaderText="CisloPojistovna"  DataField="CisloPojistovna" SortExpression="cislopojistovna"/>

    </Columns>
        
    </asp:GridView>
    </br>
      </br>
      </br>
    <asp:DetailsView ID="DetailsView1" runat="server"
        AutoGenerateRows="false" DataSourceID="ObjectDataSource2" DataKeyNames="idpojistovna" GridLines="None">
        <Fields>

            <asp:TemplateField HeaderText="IdPojistovna" SortExpression="idpojistovna" InsertVisible="False">
				<EditItemTemplate>
			   	<asp:Label ID="idpojistovna" runat="server" Text='<%# Bind("idpojistovna") %>'></asp:Label>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:Label ID="idpojistovna" runat="server" Text="ID"></asp:Label>
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="idpojistovna" runat="server" Text='<%# Bind("idpojistovna") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>

            <asp:TemplateField HeaderText="CisloPojistovna" SortExpression="cislopojistovna" InsertVisible="True">
				<EditItemTemplate>
			   	<asp:TextBox ID="cislopojistovna" runat="server" Text='<%# Bind("cislopojistovna") %>'></asp:TextBox>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:TextBox ID="cislopojistovna" runat="server" Text='<%# Bind("cislopojistovna") %>'></asp:TextBox>
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="cislopojistovna" runat="server" Text='<%# Bind("cislopojistovna") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>

             <asp:CommandField ShowEditButton="True" ShowInsertButton="True" CancelText="Zrusit" DeleteText="Smazat" EditText="Upravit" InsertText="Vlozit" NewText="Novy zaznam" SelectText="Vzbrat" UpdateText="Aktualizovat" /> 
        
        
        
        
        
        </Fields>
       

    </asp:DetailsView>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" TypeName="AuctionWebApp.Database.PojistovnaTable" DataObjectTypeName="AuctionWebApp.Database.Pojistovna" SelectMethod="Select" InsertMethod="Insert" UpdateMethod="Update">
         <SelectParameters>
            <asp:ControlParameter PropertyName="SelectedValue" Type="Int32" Name="idpojistovna" ControlID="GridView1" DefaultValue="1"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>



    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
        TypeName="AuctionWebApp.Database.PojistovnaTable" 
        SelectMethod="Select"  DeleteMethod="Delete">

      <DeleteParameters>
      <asp:ControlParameter Type="Int32" Name="IdPojistovna" ControlID="GridView1"></asp:ControlParameter>
    </DeleteParameters>
        
    </asp:ObjectDataSource>



</asp:Content>
