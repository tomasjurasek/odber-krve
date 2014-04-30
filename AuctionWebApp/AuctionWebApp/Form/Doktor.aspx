<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Doktor.aspx.cs" Inherits="AuctionWebApp.Form.Doktor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridView1" runat="server"
        DataKeyNames="IdDoktor" 
        AutoGenerateColumns="False"
    AllowPaging="True" DataSourceID="ObjectDataSource1">


         <Columns>
      <asp:CommandField ShowSelectButton="true" ShowDeleteButton="True"/>
      <asp:BoundField HeaderText="IdDoktor"     DataField="IdDoktor"  SortExpression="iddoktor"/>
      <asp:BoundField HeaderText="Jmeno"  DataField="Jmeno" SortExpression="jmeno"/>
             <asp:BoundField HeaderText="Prijmeni"  DataField="Prijmeni" SortExpression="prijmeni"/>
             <asp:BoundField HeaderText="Primar"  DataField="Primar" SortExpression="primar"/>
             <asp:BoundField HeaderText="Email"  DataField="Email" SortExpression="email"/>
             <asp:BoundField HeaderText="Telefon"  DataField="Telefon" SortExpression="telefon"/>
             <asp:BoundField HeaderText="Bonus"  DataField="Bonus" SortExpression="bonus"/>

    </Columns>
    </asp:GridView>


    <asp:DetailsView ID="DetailsView1" runat="server" 
        AutoGenerateRows="false" DataSourceID="ObjectDataSource2" DataKeyNames="iddoktor" GridLines="None">

        <Fields>

            <asp:TemplateField HeaderText="IdDoktor" SortExpression="iddoktor" InsertVisible="true">
				<EditItemTemplate>
			   	<asp:Label ID="iddoktor" runat="server" Text='<%# Bind("iddoktor") %>'></asp:Label>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:Label ID="iddoktor" runat="server"></asp:Label>
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="iddoktor" runat="server" Text='<%# Bind("iddoktor") %>'></asp:Label>
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


            <asp:TemplateField HeaderText="Primar" SortExpression="primar" InsertVisible="True">
				<EditItemTemplate>
			   	<asp:TextBox ID="primar" runat="server" Text='<%# Bind("primar") %>'></asp:TextBox>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:DropDownList ID="DropDownListSubContractors" runat="server" AppendDataBoundItems="true" 
                          SelectedValue='<%# Bind("primar") %>' >
                    <asp:ListItem Text="Ano" Value="True" />   
                   <asp:ListItem Text="Ne" Value="False" /> 
                </asp:DropDownList>
                    
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="primar" runat="server" Text='<%# Bind("primar") %>'></asp:Label>
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



             <asp:TemplateField HeaderText="Bonus" SortExpression="bonus" InsertVisible="True">
				<EditItemTemplate>
			   	<asp:TextBox ID="bonus" runat="server" Text='<%# Bind("bonus") %>'></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" ControlToValidate="bonus" 
                        Operator="DataTypeCheck" Type="Integer" ValueToCompare="0">Bonus musi byt cislo</asp:CompareValidator>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:TextBox ID="bonus" runat="server" Text='<%# Bind("bonus") %>'></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="bonus" Operator="DataTypeCheck" Type="Integer" ErrorMessage="CompareValidator">Bonus musi byt cislo</asp:CompareValidator>
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="bonus" runat="server" Text='<%# Bind("bonus") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>





             <asp:CommandField ShowEditButton="True" ShowInsertButton="True" CancelText="Zrusit" DeleteText="Smazat" EditText="Upravit" InsertText="Vlozit" NewText="Novy zaznam" SelectText="Vzbrat" UpdateText="Aktualizovat" /> 
        
        
        
        
        
        </Fields>
    </asp:DetailsView>


    


    


    


    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
        TypeName="AuctionWebApp.Database.DoktorTable" 
        SelectMethod="Select"  DeleteMethod="Delete">

         <DeleteParameters>
      <asp:ControlParameter Type="Int32" Name="IdDoktor" ControlID="GridView1"></asp:ControlParameter>
    </DeleteParameters>
    </asp:ObjectDataSource>


    


    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" TypeName="AuctionWebApp.Database.DoktorTable" DataObjectTypeName="AuctionWebApp.Database.Doktor" SelectMethod="Select" InsertMethod="Insert" UpdateMethod="Update">

        <SelectParameters>
            <asp:ControlParameter PropertyName="SelectedValue" Type="Int32" Name="iddoktor" ControlID="GridView1" DefaultValue="1"></asp:ControlParameter>
        </SelectParameters>


    </asp:ObjectDataSource>


</asp:Content>
