<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientDetails.aspx.cs" Inherits="HiringTrackingSite.ClientDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <span class="formLabel">Id:</span>
            <asp:Label ID="IdLabel1" runat="server" Text="" />
    <br />
    <span class="formLabel">Name:</span>
            <asp:TextBox ID="NameTextBox" runat="server" Text="" />
    <br />
    <span class="formLabel">Phone:</span>
            <asp:TextBox ID="PhoneTextBox" runat="server" Text="" />
    <br />
    <span class="formLabel">Email:</span>
            <asp:TextBox ID="EmailTextBox" runat="server" Text="" />
    <br />
    <span class="formLabel">Contact Name:</span>
            <asp:TextBox ID="ContactNameTextBox" runat="server" Text="" />
    <br />
    <span class="formLabel">Website:</span>
            <asp:TextBox ID="WebsiteTextBox" runat="server" Text="" />
    <br />
    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" OnClick="UpdateButton_Click" />
    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Update" Text="Insert" OnClick="InsertButton_Click" />
    
</asp:Content>
