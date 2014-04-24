<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ZdravotniZaznam.aspx.cs" Inherits="AuctionWebApp.Form.ZdravotniZaznam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server"
         DataKeyNames="IdZaznam" 
        AutoGenerateColumns="False"
    AllowPaging="True" DataSourceID="ObjectDataSource1">

          <Columns>
      <asp:CommandField ShowSelectButton="true" ShowDeleteButton="True"/>
      <asp:BoundField HeaderText="IdZaznam"     DataField="IdZaznam"  SortExpression="idzaznam"/>
      <asp:BoundField HeaderText="Popis"  DataField="Popis" SortExpression="popis"/>
             <asp:BoundField HeaderText="Datum"  DataField="Datum" SortExpression="datum"/>
             



              <asp:TemplateField HeaderText ="Pacient">
                 <ItemTemplate >
                     <asp:Label ID="pacient" runat="server" Text='<%# Eval("Pacient.Jmeno") + " " + Eval("Pacient.Prijmeni") + " - " + Eval("Pacient.Email")%>'></asp:Label>
                </ItemTemplate>
             </asp:TemplateField>

    </Columns>

    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="AuctionWebApp.Database.ZdravotniZaznamTable" 
        SelectMethod="Select"  DeleteMethod="Delete">
        <DeleteParameters>
      <asp:ControlParameter Type="Int32" Name="IdZaznam" ControlID="GridView1"></asp:ControlParameter>
    </DeleteParameters></asp:ObjectDataSource>


    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server"
        TypeName="AuctionWebApp.Database.ZdravotniZaznamTable" DataObjectTypeName="AuctionWebApp.Database.ZdravotniZaznam" SelectMethod="Select" InsertMethod="Insert" UpdateMethod="Update">

        <SelectParameters>
            <asp:ControlParameter PropertyName="SelectedValue" Type="Int32" Name="IdZaznam" ControlID="GridView1" DefaultValue="1"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>


    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server"
        TypeName="AuctionWebApp.Database.PacientTable" 
        SelectMethod="Select"></asp:ObjectDataSource>


    <asp:DetailsView ID="DetailsView1" runat="server"
         AutoGenerateRows="false" DataSourceID="ObjectDataSource2" DataKeyNames="idzaznam"
         GridLines="None">

        <Fields>

            <asp:TemplateField HeaderText="IdZaznam" SortExpression="idzaznam" InsertVisible="true">
				<EditItemTemplate>
			   	<asp:Label ID="idzaznam" runat="server" Text='<%# Bind("idzaznam") %>'></asp:Label>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:Label ID="idzaznam" runat="server"></asp:Label>
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="idzaznam" runat="server" Text='<%# Bind("idzaznam") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>

            <asp:TemplateField HeaderText="Popis" SortExpression="popis" InsertVisible="True">
				<EditItemTemplate>
			   	<asp:TextBox ID="popis" runat="server" Text='<%# Bind("popis") %>'></asp:TextBox>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:TextBox  ID="popis" runat="server" Text='<%# Bind("popis") %>'></asp:TextBox>
                    
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="popis" runat="server" Text='<%# Bind("popis") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>

              <%-- <asp:BoundField ty DataField="datum" HeaderText="Datum" DataFormatString="dd-mm-yyyy"/>--%>

            <asp:TemplateField HeaderText="Datum" SortExpression="mdatum" InsertVisible="True">
				<EditItemTemplate>
			   	<asp:TextBox ID="datum" runat="server" Text='<%# Bind("mdatum") %>'></asp:TextBox>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		
                   <asp:TextBox  ID="datum" runat="server" Text='<%# Bind("mdatum") %>'></asp:TextBox>
                    
  
                </InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="datum" runat="server" Text='<%# Bind("datum") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField> 
            


              <asp:TemplateField HeaderText="pacient" SortExpression="pacient.email" InsertVisible="True">
				<EditItemTemplate>
                    

                    <asp:DropDownList ID="ListKrve" runat="server" DataSourceID="ObjectDataSource3"
                        DataTextField="Email" DataValueField="IdPacient" AppendDataBoundItems="true"
                        SelectedValue='<%# Bind("IdPacient") %>'>
                        <asp:ListItem Value="0">Please Select</asp:ListItem>
                    </asp:DropDownList>
                    
                                      
			   	<%--<asp:TextBox ID="krev" runat="server" Text='<%# Bind("krev.skupina") %>'></asp:TextBox>--%>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:DropDownList ID="ListKrve" runat="server" DataSourceID="ObjectDataSource3"
                        DataTextField="Email" DataValueField="IdPacient" AppendDataBoundItems="true"
                        SelectedValue='<%# Bind("IdPacient") %>'>
                        <asp:ListItem Value="0">Please Select</asp:ListItem>
                    </asp:DropDownList>
                    
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="Label11" runat="server" Text='<%# Bind("Pacient.email") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>


             <asp:CommandField ShowEditButton="True" ShowInsertButton="True" CancelText="Zrusit" DeleteText="Smazat" EditText="Upravit" InsertText="Vlozit" NewText="Novy zaznam" SelectText="Vzbrat" UpdateText="Aktualizovat" /> 
        
        
        
        
        
        </Fields>


    </asp:DetailsView>
    
</asp:Content>
