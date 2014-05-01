<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stav.aspx.cs" Inherits="AuctionWebApp.Form.Stav" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <asp:GridView ID="GridView1" runat="server" DataKeyNames="IdStav" 
    AutoGenerateColumns="False"
    AllowPaging="True" DataSourceID="ObjectDataSource1">

        <Columns>
      <asp:CommandField ShowSelectButton="true" ShowDeleteButton="True"/>
      <asp:BoundField HeaderText="IdStav"     DataField="IdStav"  SortExpression="idstav"/>
      <asp:BoundField HeaderText="NazevStavu"  DataField="nazevstavu" SortExpression="nazevstavu"/>

    </Columns>
    </asp:GridView>



    </br>
    <p><strong>Detail stavu</strong></p>
    <asp:DetailsView ID="DetailsView1" runat="server" 
        AutoGenerateRows="false" DataSourceID="ObjectDataSource2" DataKeyNames="idstav" GridLines="None" OnItemInserted="DetailsView1_ItemInserted" OnItemUpdated="DetailsView1_ItemUpdated">

          <Fields>

            <asp:TemplateField HeaderText="IdStav" SortExpression="idstav" InsertVisible="true">
				<EditItemTemplate>
			   	<asp:Label ID="idstav" runat="server" Text='<%# Bind("idstav") %>'></asp:Label>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:Label ID="idstav" runat="server"></asp:Label>
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="idstav" runat="server" Text='<%# Bind("idstav") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>

            <asp:TemplateField HeaderText="NazevStavu" SortExpression="nazevstavu" InsertVisible="True">
				<EditItemTemplate>
			   	<asp:TextBox ID="nazevstavu" runat="server" Text='<%# Bind("nazevstavu") %>'></asp:TextBox>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:TextBox ID="nazevstavu" runat="server" Text='<%# Bind("nazevstavu") %>'></asp:TextBox>
                    <asp:CompareValidator ID="nazevstavuValidator" runat="server" ControlToValidate="nazevstavu" ErrorMessage="Permission neni Integer" Operator="DataTypeCheck" Type="String" ValueToCompare="0">
                        Permission neni Integer</asp:CompareValidator>
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="nazevstavu" runat="server" Text='<%# Bind("nazevstavu") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>

             <asp:CommandField ShowEditButton="True" ShowInsertButton="True" CancelText="Zrusit" DeleteText="Smazat" EditText="Upravit" InsertText="Vlozit" NewText="Novy zaznam" SelectText="Vzbrat" UpdateText="Aktualizovat" /> 
        
        
        
        
        
        </Fields>
       

    </asp:DetailsView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
        TypeName="AuctionWebApp.Database.StavTable" 
        SelectMethod="Select"  DeleteMethod="Delete">

        <DeleteParameters>
      <asp:ControlParameter Type="Int32" Name="IdStav" ControlID="GridView1"></asp:ControlParameter>
    </DeleteParameters>
    </asp:ObjectDataSource>


    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server"
        TypeName="AuctionWebApp.Database.StavTable" DataObjectTypeName="AuctionWebApp.Database.Stav" SelectMethod="Select" InsertMethod="Insert" UpdateMethod="Update">
        <SelectParameters>
            <asp:ControlParameter PropertyName="SelectedValue" Type="Int32" Name="idstav" ControlID="GridView1" DefaultValue="1"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>


</asp:Content>
