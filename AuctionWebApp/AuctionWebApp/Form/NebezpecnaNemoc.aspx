<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NebezpecnaNemoc.aspx.cs" Inherits="AuctionWebApp.Form.NebezpecnaNemoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <asp:GridView ID="GridView1" runat="server" DataKeyNames="IdNemoc" 
        AutoGenerateColumns="False"
    AllowPaging="True" DataSourceID="ObjectDataSource1">

         <Columns>
      <asp:CommandField ShowSelectButton="true" ShowDeleteButton="True"/>
      <asp:BoundField HeaderText="IdNemoc"     DataField="IdNemoc"  SortExpression="idnemoc"/>
      <asp:BoundField HeaderText="Nazev"  DataField="Nazev" SortExpression="nazev"/>

    </Columns>
    </asp:GridView>
    <asp:DetailsView ID="DetailsView1" runat="server" 
        AutoGenerateRows="false" DataSourceID="ObjectDataSource2" DataKeyNames="idnemoc" GridLines="None">


        <Fields>

            <asp:TemplateField HeaderText="IdNemoc" SortExpression="idnemoc" InsertVisible="true">
				<EditItemTemplate>
			   	<asp:Label ID="idnemoc" runat="server" Text='<%# Bind("idnemoc") %>'></asp:Label>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:Label ID="idnemoc" runat="server"></asp:Label>
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="idnemoc" runat="server" Text='<%# Bind("idnemoc") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>

            <asp:TemplateField HeaderText="Nazev" SortExpression="nazev" InsertVisible="True">
				<EditItemTemplate>
			   	<asp:TextBox ID="nazev" runat="server" Text='<%# Bind("nazev") %>'></asp:TextBox>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:TextBox ID="nazev" runat="server" Text='<%# Bind("nazev") %>'></asp:TextBox>
                    <asp:CompareValidator ID="nazevValidator" runat="server" ControlToValidate="nazev" ErrorMessage="Permission neni Integer" Operator="DataTypeCheck" Type="String" ValueToCompare="0">
                        Permission neni Integer</asp:CompareValidator>
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="nazev" runat="server" Text='<%# Bind("nazev") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>

             <asp:CommandField ShowEditButton="True" ShowInsertButton="True" CancelText="Zrusit" DeleteText="Smazat" EditText="Upravit" InsertText="Vlozit" NewText="Novy zaznam" SelectText="Vzbrat" UpdateText="Aktualizovat" /> 
        
        
        
        
        
        </Fields>

    </asp:DetailsView>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server"
        TypeName="AuctionWebApp.Database.NebezpecnaNemocTable" DataObjectTypeName="AuctionWebApp.Database.NebezpecnaNemoc" SelectMethod="Select" InsertMethod="Insert" UpdateMethod="Update">

        <SelectParameters>
            <asp:ControlParameter PropertyName="SelectedValue" Type="Int32" Name="idnemoc" ControlID="GridView1" DefaultValue="1"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>



    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
        TypeName="AuctionWebApp.Database.NebezpecnaNemocTable" 
        SelectMethod="Select"  DeleteMethod="Delete">
        <DeleteParameters>
      <asp:ControlParameter Type="Int32" Name="IdNemoc" ControlID="GridView1"></asp:ControlParameter>
    </DeleteParameters>
    </asp:ObjectDataSource>


</asp:Content>
