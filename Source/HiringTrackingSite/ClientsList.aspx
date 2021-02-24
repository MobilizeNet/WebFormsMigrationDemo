<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientsList.aspx.cs" Inherits="HiringTrackingSite.ClientsListForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table>
        <tr>
            <th>Id</th>
            <th>Client Name</th>
            <th>Phone</th>
            <th>Email</th>
            <th>Website</th>
            <th>Contact Name</th>
            <th></th>
        </tr>
        <tr>
            <th><asp:Textbox ID="IdFilter" runat="server"></asp:Textbox></th>
            <th><asp:Textbox ID="NameFilter" runat="server"></asp:Textbox></th>
            <th><asp:Textbox ID="PhoneFilter" runat="server"></asp:Textbox></th>
            <th><asp:Textbox ID="EmailFilter" runat="server"></asp:Textbox></th>
            <th><asp:Textbox ID="WebsiteFilter" runat="server"></asp:Textbox></th>
            <th><asp:Textbox ID="ContactNameFilter" runat="server"></asp:Textbox></th>
            <th><asp:Button runat="server" ID="btnFilter" OnClick="btnFilter_Click" Text="Filter" /></th>
        </tr>
        <asp:DataList ID="DataList1" runat="server" DataKeyField="Id" DataSourceID="ClientsDataSource" RepeatLayout="Flow">
            <ItemTemplate>
                <tr>
                    <td>
        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    </td> 
                    <td>
        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    </td>
                    <td>
        <asp:Label ID="PhoneLabel" runat="server" Text='<%# Eval("Phone") %>' />
                    </td>
                    <td>
        <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                    </td>
                    <td>
        <asp:Label ID="WebsiteLabel" runat="server" Text='<%# Eval("Website") %>' />
                    </td>
                    <td>
        <asp:Label ID="ContactNameLabel" runat="server" Text='<%# Eval("ContactName") %>' />
                    </td>
                    <td><asp:LinkButton runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="Details_Click" >Details</asp:LinkButton></td>
                </tr>
            </ItemTemplate>
        </asp:DataList>

    </table>
    <asp:LinkButton ID="AddNewButton" OnClick="AddNewButton_Click" runat="server">Add new client</asp:LinkButton>
    <asp:SqlDataSource ID="ClientsDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HiringConnectionString %>" SelectCommand="SELECT * FROM [Clients]"></asp:SqlDataSource>
</asp:Content>
