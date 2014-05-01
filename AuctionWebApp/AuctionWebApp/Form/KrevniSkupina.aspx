<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KrevniSkupina.aspx.cs" Inherits="AuctionWebApp.Form.KrevniSkupina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <asp:GridView ID="GridView1" runat="server" DataKeyNames="IdKrve"
    AutoGenerateColumns="False"
    AllowPaging="True" DataSourceID="ObjectDataSource1">
         <Columns>
      <asp:CommandField ShowSelectButton="true" ShowDeleteButton="True"/>
      <asp:BoundField HeaderText="IdKrve"     DataField="IdKrve"  SortExpression="idkrve"/>
      <asp:BoundField HeaderText="Skupina"  DataField="Skupina" SortExpression="skupina"/>
           

    </Columns>

    </asp:GridView>
    
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server"
        TypeName="AuctionWebApp.Database.KrevniSkupinaTable" DataObjectTypeName="AuctionWebApp.Database.KrevniSkupina" SelectMethod="Select" InsertMethod="Insert" UpdateMethod="Update">
        <SelectParameters>
            <asp:ControlParameter PropertyName="SelectedValue" Type="Int32" Name="idkrve" ControlID="GridView1" DefaultValue="1"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
    

    </br>
    <p><strong>Detail krevní skupiny</strong></p>
    <asp:DetailsView ID="DetailsView1" runat="server"
        AutoGenerateRows="false" DataSourceID="ObjectDataSource2" DataKeyNames="idkrve" GridLines="None" OnItemInserted="DetailsView1_ItemInserted" OnItemUpdated="DetailsView1_ItemUpdated">

        <Fields>

            <asp:TemplateField HeaderText="IdKrve" SortExpression="idkrve" InsertVisible="true">
				<EditItemTemplate>
			   	<asp:Label ID="idkrve" runat="server" Text='<%# Bind("idkrve") %>'></asp:Label>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:Label ID="idkrve" runat="server"></asp:Label>
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="idkrve" runat="server" Text='<%# Bind("idkrve") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>

            <asp:TemplateField HeaderText="Skupina" SortExpression="skupina" InsertVisible="True">
				<EditItemTemplate>
			   	<asp:TextBox ID="skupina" runat="server" Text='<%# Bind("skupina") %>'></asp:TextBox>
				</EditItemTemplate>
				<InsertItemTemplate>
			   		<asp:TextBox ID="skupina" runat="server" Text='<%# Bind("skupina") %>'></asp:TextBox>
                    <asp:CompareValidator ID="skupinaValidator" runat="server" ControlToValidate="skupina" ErrorMessage="Skupina neni retezec" Operator="DataTypeCheck" Type="String" ValueToCompare="">
                        Skupina neni retezec</asp:CompareValidator>
				</InsertItemTemplate>
				<ItemTemplate>
					<asp:Label ID="cislopojistovna" runat="server" Text='<%# Bind("skupina") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>

             <asp:CommandField ShowEditButton="True" ShowInsertButton="True" CancelText="Zrusit" DeleteText="Smazat" EditText="Upravit" InsertText="Vlozit" NewText="Novy zaznam" SelectText="Vzbrat" UpdateText="Aktualizovat" /> 
        
        
        
        
        
        </Fields>


    </asp:DetailsView>
    
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server"
        TypeName="AuctionWebApp.Database.KrevniSkupinaTable" 
        SelectMethod="Zasoby"></asp:ObjectDataSource>
    
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
        TypeName="AuctionWebApp.Database.KrevniSkupinaTable" 
        SelectMethod="Select"  DeleteMethod="Delete">
        <DeleteParameters>
      <asp:ControlParameter Type="Int32" Name="IdKrve" ControlID="GridView1"></asp:ControlParameter>
    </DeleteParameters>
    </asp:ObjectDataSource>


    

    </br>
    <p><strong>Statistika krve</strong></p>
    <asp:GridView ID="GridView2" runat="server"
        DataKeyNames="IdKrve"
    AutoGenerateColumns="False"
    AllowPaging="True" DataSourceID="ObjectDataSource3">
         <Columns>
      
      <%--<asp:BoundField HeaderText="IdKrve"     DataField="IdKrve"  SortExpression="idkrve"/>--%>
      <asp:BoundField HeaderText="Skupina"  DataField="Skupina" SortExpression="skupina"/>
      <asp:BoundField HeaderText="Zasoby"  DataField="Zasoby"  SortExpression="Zasoby"/>
           

    </Columns>
    </asp:GridView>


    


</asp:Content>
