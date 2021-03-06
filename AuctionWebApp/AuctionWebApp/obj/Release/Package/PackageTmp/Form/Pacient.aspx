﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pacient.aspx.cs" Inherits="AuctionWebApp.Form.Pacient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server"
         DataKeyNames="IdPacient" 
        AutoGenerateColumns="False"
    AllowPaging="True" DataSourceID="ObjectDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound">

         <Columns>
      <asp:CommandField ShowSelectButton="true" ShowDeleteButton="True"/>
      <asp:BoundField HeaderText="IdPacient"     DataField="IdPacient"  SortExpression="idpacient"/>
      <asp:BoundField HeaderText="Jmeno"  DataField="Jmeno" SortExpression="jmeno"/>
             <asp:BoundField HeaderText="Prijmeni"  DataField="Prijmeni" SortExpression="prijmeni"/>
             <asp:BoundField HeaderText="Vek"  DataField="Vek" SortExpression="vek"/>
             <asp:BoundField HeaderText="Mesto"  DataField="Mesto" SortExpression="mesto"/>
             <asp:BoundField HeaderText="Adresa"  DataField="Adresa" SortExpression="adresa"/>
             <asp:BoundField HeaderText="Telefon"  DataField="Telefon" SortExpression="telefon"/>
             <%--<asp:BoundField HeaderText="Telefon"  DataField="Telefon" SortExpression="telefon"/>--%>
             <asp:BoundField HeaderText="Email"  DataField="Email" SortExpression="email"/>
             <asp:BoundField HeaderText="Bonus"  DataField="Bonus" SortExpression="bonus"/>

             <asp:TemplateField HeaderText ="Krev">
                 <ItemTemplate >
                     <asp:Label ID="Krev" runat="server" Text='<%# Eval("Krev.Skupina") %>'></asp:Label>
                </ItemTemplate>
                
             </asp:TemplateField>

              <asp:TemplateField HeaderText ="Pojistovna">
                 <ItemTemplate >
                     <asp:Label ID="Pojistovna" runat="server" Text='<%# Eval("Pojistovna.CisloPojistovna") %>'></asp:Label>
                </ItemTemplate>
             </asp:TemplateField>

    </Columns>


    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
        TypeName="AuctionWebApp.Database.PacientTable" 
        SelectMethod="Select"  DeleteMethod="Delete">
        <DeleteParameters>
      <asp:ControlParameter Type="Int32" Name="IdPacient" ControlID="GridView1"></asp:ControlParameter>
    </DeleteParameters>

    </asp:ObjectDataSource>


    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server"
        TypeName="AuctionWebApp.Database.KrevniSkupinaTable" 
        SelectMethod="Select"></asp:ObjectDataSource>

     <asp:ObjectDataSource ID="ObjectDataSource4" runat="server"
        TypeName="AuctionWebApp.Database.PojistovnaTable" 
        SelectMethod="Select"></asp:ObjectDataSource>


    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" TypeName="AuctionWebApp.Database.PacientTable" DataObjectTypeName="AuctionWebApp.Database.Pacient" SelectMethod="Select" InsertMethod="Insert" UpdateMethod="Update" OnInserted="ObjectDataSource2_Inserted">

        <SelectParameters>
            <asp:ControlParameter PropertyName="SelectedValue" Type="Int32" Name="IdPacient" ControlID="GridView1" DefaultValue="1"></asp:ControlParameter>
        </SelectParameters>
</asp:ObjectDataSource>

        <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" TypeName="AuctionWebApp.Database.ZdravotniZaznamTable" DataObjectTypeName="AuctionWebApp.Database.ZdravotniZaznam" SelectMethod="SelectPacient" InsertMethod="Insert" UpdateMethod="Update">

        <SelectParameters>
            <asp:ControlParameter PropertyName="SelectedValue" Type="Int32" Name="IdPacient" ControlID="GridView1" DefaultValue="1"></asp:ControlParameter>
        </SelectParameters>
</asp:ObjectDataSource>


    </br>
    <p><strong>Detail pacienta</strong></p>


    <asp:DetailsView ID="DetailsView1" runat="server" 
        AutoGenerateRows="false" DataSourceID="ObjectDataSource2" DataKeyNames="idpacient"
         GridLines="None" OnItemInserting="DetailsView1_ItemInserting" OnItemUpdated="DetailsView1_ItemUpdated" OnItemInserted="DetailsView1_ItemInserted">


         <Fields>

            <asp:TemplateField HeaderText="IdPacient" SortExpression="idpacient" InsertVisible="true">
				<EditItemTemplate>
			   	<asp:Label ID="idpacient" runat="server" Text='<%# Bind("idpacient") %>'></asp:Label>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:Label ID="idpacient" runat="server"></asp:Label>
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="idpacient" runat="server" Text='<%# Bind("idpacient") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>

            <asp:TemplateField HeaderText="Jmeno" SortExpression="jmeno" InsertVisible="True">
				<EditItemTemplate>
			   	<asp:TextBox ID="jmeno" runat="server" Text='<%# Bind("jmeno") %>'></asp:TextBox>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:TextBox ID="jmeno" runat="server" Text='<%# Bind("jmeno") %>'></asp:TextBox>
                    
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="jmeno" runat="server" Text='<%# Bind("jmeno") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>

             <asp:TemplateField HeaderText="Prijmeni" SortExpression="prijmeni" InsertVisible="True">
				<EditItemTemplate>
			   	<asp:TextBox ID="prijmeni" runat="server" Text='<%# Bind("prijmeni") %>'></asp:TextBox>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:TextBox ID="prijmeni" runat="server" Text='<%# Bind("prijmeni") %>'></asp:TextBox>
                    
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="prijmeni" runat="server" Text='<%# Bind("prijmeni") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>


            <asp:TemplateField HeaderText="Vek" SortExpression="vek" InsertVisible="True">
				<EditItemTemplate>
			   	<asp:TextBox ID="vek" runat="server" Text='<%# Bind("vek") %>'></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="CompareValidator" ControlToValidate="vek"
                       Operator="DataTypeCheck" Type="Integer" >Vek musi byt cislo</asp:CompareValidator>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:TextBox ID="vek" runat="server" Text='<%# Bind("vek") %>'></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" ControlToValidate="vek"
                        Operator="DataTypeCheck" Type="Integer">Vek musi byt cislo</asp:CompareValidator>
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="vek" runat="server" Text='<%# Bind("vek") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>


            <asp:TemplateField HeaderText="Mesto" SortExpression="mesto" InsertVisible="True">
				<EditItemTemplate>
			   	<asp:TextBox ID="mesto" runat="server" Text='<%# Bind("mesto") %>'></asp:TextBox>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:TextBox ID="mesto" runat="server" Text='<%# Bind("mesto") %>'></asp:TextBox>
                    
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="mesto" runat="server" Text='<%# Bind("mesto") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>

            <asp:TemplateField HeaderText="Adresa" SortExpression="adresa" InsertVisible="True">
				<EditItemTemplate>
			   	<asp:TextBox ID="adresa" runat="server" Text='<%# Bind("adresa") %>'></asp:TextBox>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:TextBox ID="adresa" runat="server" Text='<%# Bind("adresa") %>'></asp:TextBox>
                    
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="adresa" runat="server" Text='<%# Bind("adresa") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>



             <asp:TemplateField HeaderText="Telefon" SortExpression="telefon" InsertVisible="True">
				<EditItemTemplate>
			   	<asp:TextBox ID="telefon" runat="server" Text='<%# Bind("telefon") %>'></asp:TextBox>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:TextBox ID="telefon" runat="server" Text='<%# Bind("telefon") %>'></asp:TextBox>
                    
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="telefon" runat="server" Text='<%# Bind("telefon") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>

             <asp:TemplateField HeaderText="Email" SortExpression="email" InsertVisible="True">
				<EditItemTemplate>
			   	<asp:TextBox ID="email" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:TextBox ID="email" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                    
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="email" runat="server" Text='<%# Bind("email") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>


             <asp:TemplateField HeaderText="Bonus" SortExpression="bonus" InsertVisible="True">
				<EditItemTemplate>
			   	<asp:TextBox ID="bonus" runat="server" Text='<%# Bind("bonus") %>'></asp:TextBox>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:Label ID="bonus" runat="server" Text='<%# Bind("bonus") %>'></asp:Label>
                    
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="bonus" runat="server" Text='<%# Bind("bonus") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>


              <asp:TemplateField HeaderText="Krev" SortExpression="krev.skupina" InsertVisible="True">
				<EditItemTemplate>
                    

                    <asp:DropDownList ID="ListKrve" runat="server" DataSourceID="ObjectDataSource3"
                        DataTextField="Skupina" DataValueField="IdKrve" AppendDataBoundItems="true"
                        SelectedValue='<%# Bind("IdKrve") %>'>
                        <asp:ListItem Value="0">Vyber krev</asp:ListItem>
                    </asp:DropDownList>
                    
                                      
			   	<%--<asp:TextBox ID="krev" runat="server" Text='<%# Bind("krev.skupina") %>'></asp:TextBox>--%>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		 <asp:DropDownList ID="ListKrve" runat="server" DataSourceID="ObjectDataSource3"
                        DataTextField="Skupina" DataValueField="IdKrve" AppendDataBoundItems="true"
                        SelectedValue='<%# Bind("IdKrve") %>'>
                        <asp:ListItem Value="0">Vyber krev</asp:ListItem>
                    </asp:DropDownList>
                    
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="krev" runat="server" Text='<%# Bind("krev.skupina") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>


             <asp:TemplateField HeaderText="Pojistovna" SortExpression="pojistovna.cislopojistovna" InsertVisible="True">
				<EditItemTemplate>
                        <asp:DropDownList ID="ListCategory" runat="server" DataSourceID="ObjectDataSource4"
                        DataTextField="CisloPojistovna" DataValueField="IdPojistovna" SelectedValue='<%# Bind("IdPojistovna") %>'
                            AppendDataBoundItems="true">
                            <asp:ListItem Value="0">Vyber pojistovnu</asp:ListItem>
                        </asp:DropDownList>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		 <asp:DropDownList ID="ListCategory" runat="server" DataSourceID="ObjectDataSource4"
                    DataTextField="CisloPojistovna" DataValueField="IdPojistovna" SelectedValue='<%# Bind("IdPojistovna") %>'
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="0">Vyber pojistovnu</asp:ListItem>
                </asp:DropDownList>
                    
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="pojistovna" runat="server" Text='<%# Bind("pojistovna.cislopojistovna") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>

             <asp:CommandField ShowEditButton="True" ShowInsertButton="True" CancelText="Zrusit" DeleteText="Smazat" EditText="Upravit" InsertText="Vlozit" NewText="Novy zaznam" SelectText="Vzbrat" UpdateText="Aktualizovat" /> 

        </Fields>


         <HeaderStyle BorderStyle="Solid" />


    </asp:DetailsView>
    
    <asp:Label ID="Label1" runat="server"></asp:Label>
    </br>
    <p><strong>Seznam pacientových nemocí</strong></p>
    <asp:GridView ID="GridView2" runat="server"
        DataKeyNames="IdPacient" 
        AutoGenerateColumns="False"
    AllowPaging="True" DataSourceID="ObjectDataSource5">
        

         <Columns>      
        <asp:BoundField HeaderText="IdZaznam"  DataField="IdZaznam" SortExpression="idzaznam"/>
             <asp:BoundField HeaderText="Popis"  DataField="Popis" SortExpression="popis"/>
             <asp:BoundField HeaderText="Datum"  DataField="Datum" DataFormatString="{0:dd/MM/yyyy}" SortExpression="datum"/>
             <%--<asp:BoundField HeaderText="IdPacient"  DataField="Idpacient" SortExpression="idpacient"/>--%>
            

    </Columns>

    </asp:GridView>
    
    
    </br>
    <p><strong> Funkce na přidání bonusů</strong></p>
&nbsp;<asp:DropDownList ID="ListCategory" runat="server" DataSourceID="ObjectDataSource4"
                    DataTextField="CisloPojistovna" DataValueField="IdPojistovna"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="0">Vyber pojistovnu</asp:ListItem>
                </asp:DropDownList>
    <asp:Button ID="Button1" runat="server" Text="Pridej bonusy" OnClick="Button1_Click" />
    
    
    
</asp:Content>
