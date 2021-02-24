<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PositionsList.aspx.cs" Inherits="HiringTrackingSite.PositionsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table>
        <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Description</th>
            <th>Start Date</th>
            <th>Deadline</th>
            <th>Position Closed</th>
            <th>Client Contact</th>
            <th></th>
        </tr>
        <tr>
            <th><asp:Textbox ID="IdFilter" runat="server"></asp:Textbox></th>
            <th><asp:Textbox ID="NameFilter" runat="server"></asp:Textbox></th>
            <th><asp:Textbox ID="DescriptionFilter" runat="server"></asp:Textbox></th>
            <th><asp:Textbox ID="StartDateFilter" runat="server"></asp:Textbox></th>
            <th><asp:Textbox ID="DeadlineFilter" runat="server"></asp:Textbox></th>
            <th></th>
            <th><asp:Textbox ID="ClientContactFilter" runat="server"></asp:Textbox></th>
            <th><asp:Button runat="server" ID="btnFilter" OnClick="btnFilter_Click" Text="Filter" /></th>
        </tr>
        <asp:DataList ID="DataList1" runat="server" DataKeyField="Id" DataSourceID="PositionsDataSource" RepeatLayout="Flow">
            <ItemTemplate>
                <tr>
                    <td>
        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    </td>
                    <td>
        <asp:Label ID="PhoneLabel" runat="server" Text='<%# Eval("Description") %>' />
                    </td>
                    <td>
        <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("StartDate") %>' />
                    </td>
                    <td>
        <asp:Label ID="WebsiteLabel" runat="server" Text='<%# Eval("Deadline") %>' />
                    </td>
                    <td>
        <asp:Label ID="ContactNameLabel" runat="server" Text='<%# Eval("Hired") %>' />
                    </td>
                    <td>
        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ClientName") + " (" + Eval("ClientContactName") + ")" %>' />
                    </td>
                    <td><asp:LinkButton runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="Details_Click" >Details</asp:LinkButton></td>
                </tr>
            </ItemTemplate>
        </asp:DataList>

    </table>
    <asp:LinkButton ID="AddNewButton" OnClick="AddNewButton_Click" runat="server">Add new position</asp:LinkButton>
    <asp:SqlDataSource ID="PositionsDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HiringConnectionString %>" ></asp:SqlDataSource>
</asp:Content>
