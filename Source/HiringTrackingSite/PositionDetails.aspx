<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PositionDetails.aspx.cs" Inherits="HiringTrackingSite.PositionDetailsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <span class="formLabel">Id:</span>
            <asp:Label ID="IdLabel1" runat="server" Text="" />
    <br />
    <span class="formLabel">Name:</span>
            <asp:TextBox ID="NameTextBox" runat="server" Text="" />
    <br />
    <span class="formLabel">Description:</span>
            <asp:TextBox TextMode="MultiLine" ID="DescriptionTextBox" runat="server" Rows="6" Width="500" Text="" />
    <br />
    <span class="formLabel">Start Date:</span>
            <asp:TextBox ID="StartDateTextBox" TextMode="Date" runat="server" Text="" />
    <br />
    <span class="formLabel">Deadline:</span>
            <asp:TextBox ID="DeadlineTextBox" TextMode="Date" runat="server" Text="" />
    <br />
    <span class="formLabel">Hired?:</span>
            <asp:CheckBox ID="HiredCheckbox" runat="server" Checked="false" />
    <br /> 
    <span class="formLabel">Client:</span>
            <asp:DropDownList ID="ClientCombo" runat="server" />
    <br />
    <span class="formLabel">Client Contact Name:</span>
            <asp:TextBox ID="ClientContactNameTextBox" runat="server" Text="" />
    <br />
    <span class="formLabel">Phone:</span>
            <asp:TextBox ID="ClientContactPhoneTextBox" runat="server" Text="" />
    <br />
    <span class="formLabel">Email:</span>
            <asp:TextBox ID="ClientContactEmailTextBox" runat="server" Text="" />
    <br />
    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" OnClick="UpdateButton_Click" />
    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Update" Text="Insert" OnClick="InsertButton_Click" />
    
</asp:Content>
