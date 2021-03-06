﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Odber.aspx.cs" Inherits="AuctionWebApp.Form.Odber" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <asp:GridView ID="GridView1" runat="server"
         DataKeyNames="IdOdber" 
        AutoGenerateColumns="False"
    AllowPaging="True" DataSourceID="ObjectDataSource1" >

         <Columns>
        <asp:CommandField ShowSelectButton="true" ShowDeleteButton="false"/>
        <asp:BoundField HeaderText="IdOdber"     DataField="IdOdber"  SortExpression="idodber"/>
        <asp:BoundField HeaderText="Datum"  DataField="Datum" DataFormatString="{0:dd/MM/yyyy}" SortExpression="Datum"/>
        <asp:BoundField HeaderText="CisloUschovna"  DataField="CisloUschovna" SortExpression="CisloUschovna"/>


             <asp:TemplateField HeaderText ="Pacient">
                 <ItemTemplate >
                     <asp:Label ID="Pacient" runat="server" Text='<%# Eval("Pacient.Jmeno") + " " + Eval("Pacient.Prijmeni") + " - " + Eval("Pacient.Email")%>'></asp:Label>
                </ItemTemplate>
             </asp:TemplateField>


             <asp:TemplateField HeaderText ="Doktor">
                 <ItemTemplate >
                     <asp:Label ID="Pacient" runat="server" Text='<%# Eval("Doktor.Jmeno") + " " + Eval("Doktor.Prijmeni")%>'></asp:Label>
                </ItemTemplate>
             </asp:TemplateField>

              <asp:TemplateField HeaderText ="Stav">
                 <ItemTemplate >
                     <asp:Label ID="Pacient" runat="server" Text='<%# Eval("Stav.NazevStavu")%>'></asp:Label>
                </ItemTemplate>
             </asp:TemplateField>
             

    </Columns>


    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
        TypeName="AuctionWebApp.Database.OdberTable" 
        SelectMethod="Select"  DeleteMethod="Delete">
        <DeleteParameters>
      <asp:ControlParameter Type="Int32" Name="IdOdber" ControlID="GridView1"></asp:ControlParameter>
    </DeleteParameters>

    </asp:ObjectDataSource>
    </br>
    <p><strong>Detail odběru</strong></p>
    <asp:DetailsView ID="DetailsView1" runat="server" 
        AutoGenerateRows="false" DataSourceID="ObjectDataSource2" DataKeyNames="idodber"
         GridLines="None" OnItemInserted="DetailsView1_ItemInserted" OnItemUpdated="DetailsView1_ItemUpdated" >



        <Fields>

            <asp:TemplateField HeaderText="IdOdber" SortExpression="Idodber" InsertVisible="true">
				<EditItemTemplate>
			   	<asp:Label ID="Idodber" runat="server" Text='<%# Bind("Idodber") %>'></asp:Label>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:Label ID="Idodber" runat="server"></asp:Label>
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="Idodber" runat="server" Text='<%# Bind("Idodber") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>


            <asp:TemplateField HeaderText="IdDoktor" SortExpression="IdDoktor" InsertVisible="true">
				<EditItemTemplate>
			   	    <asp:Label ID="IdDoktor" runat="server" Text='<%# Bind("IdDoktor") %>'></asp:Label>
                </EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:DropDownList ID="ListDoktoru" runat="server" DataSourceID="ObjectDataSource4"
                        DataTextField="Email" DataValueField="IdDoktor" AppendDataBoundItems="true"
                        SelectedValue='<%# Bind("IdDoktor") %>'>
                        <asp:ListItem Value="0">Vyber doktora</asp:ListItem>
                    </asp:DropDownList>
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="IdDoktor" runat="server" Text='<%# Bind("Doktor.Email") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>


            <asp:TemplateField HeaderText="IdPacient" SortExpression="IdPacient" InsertVisible="true">
				<EditItemTemplate>
			   	<asp:Label ID="IdPacient" runat="server" Text='<%# Bind("IdPacient") %>'></asp:Label>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:DropDownList ID="ListPacientu" runat="server" DataSourceID="ObjectDataSource5"
                        DataTextField="Email" DataValueField="IdPacient" AppendDataBoundItems="true"
                        SelectedValue='<%# Bind("IdPacient") %>'>
                        <asp:ListItem Value="0">Vyber pacienta</asp:ListItem>
                    </asp:DropDownList>
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="IdPacient" runat="server" Text='<%# Bind("Pacient.Email") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>


         


            <asp:TemplateField HeaderText="CisloUschovna" SortExpression="CisloUschovna" InsertVisible="true">
				<EditItemTemplate>
			   	    <asp:Label ID="CisloUschovna" runat="server" Text='<%# Bind("CisloUschovna") %>'></asp:Label>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:TextBox ID="CisloUschovna" runat="server" Text='<%# Bind("CisloUschovna") %>'></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="CompareValidator" ControlToValidate ="CisloUschovna"
                     Operator="DataTypeCheck" Type="Integer" >Uschovna neni cislo</asp:CompareValidator>
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="CisloUschovna" runat="server" Text='<%# Bind("CisloUschovna") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>



            <asp:TemplateField HeaderText="Stav" SortExpression="Stav" InsertVisible="True">
				<EditItemTemplate>
                    <asp:DropDownList ID="ListStavu" runat="server" DataSourceID="ObjectDataSource3"
                        DataTextField="NazevStavu" DataValueField="IdStav" AppendDataBoundItems="true"
                        SelectedValue='<%# Bind("IdStav") %>'>
                        <asp:ListItem Value="0">Vyber stav</asp:ListItem>
                    </asp:DropDownList>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:DropDownList ID="ListStavu" runat="server" DataSourceID="ObjectDataSource3"
                        DataTextField="NazevStavu" DataValueField="IdStav" AppendDataBoundItems="true"
                        SelectedValue='<%# Bind("IdStav") %>'>
                        <asp:ListItem Value="0">Vyber stav</asp:ListItem>
                    </asp:DropDownList>
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="stav" runat="server" Text='<%# Bind("stav.nazevstavu") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>

             <asp:CommandField ShowEditButton="True" ShowInsertButton="True" CancelText="Zrusit" DeleteText="Smazat" EditText="Upravit" InsertText="Vlozit" NewText="Novy zaznam" SelectText="Vzbrat" UpdateText="Aktualizovat" /> 

        </Fields>
    </asp:DetailsView>


    <asp:Label ID="Label1" runat="server"></asp:Label>
    </br>


    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server"
        TypeName="AuctionWebApp.Database.DoktorTable" 
        SelectMethod="Select"></asp:ObjectDataSource>


    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server"
        TypeName="AuctionWebApp.Database.StavTable" 
        SelectMethod="Select"></asp:ObjectDataSource>


    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" TypeName="AuctionWebApp.Database.OdberTable" DataObjectTypeName="AuctionWebApp.Database.Odber" SelectMethod="Select" InsertMethod="Insert" UpdateMethod="Update" OnInserted="ObjectDataSource2_Inserted">

        <SelectParameters>
            <asp:ControlParameter PropertyName="SelectedValue" Type="Int32" Name="idodber" ControlID="GridView1" DefaultValue="1"></asp:ControlParameter>
        </SelectParameters></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjectDataSource5" runat="server"
        TypeName="AuctionWebApp.Database.PacientTable" 
        SelectMethod="Select"></asp:ObjectDataSource>


    </br>
    <p><strong>Funkce</strong></p>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Odstraň staré odběry >=24 měsíců" />


    <br />

    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Odstraň nakazené odběry" />


</asp:Content>
