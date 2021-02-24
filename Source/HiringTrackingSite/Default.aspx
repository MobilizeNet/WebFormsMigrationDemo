<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HiringTrackingSite._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Hiring Tracking</h1>
        <p class="lead">Track positions and candidates.</p>
    </div>

    <div class="row">
<%--        <div class="col-md-4">
            <h2>Candidates</h2>
            <p>
                All existing candidates with their resumes. View and edit their information or associate with open positions.
            </p>
            <p>
                <a class="btn btn-default" href="Candidates.aspx">View</a>
            </p>
        </div>--%>
        <div class="col-md-4">
            <h2>Positions</h2>
            <p>
                View open positions or query previous hires.
            </p>
            <p>
                <a class="btn btn-default" href="PositionsList.aspx">View</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Clients</h2>
            <p>
                Manage contacts requesting the positions.
            </p>
            <p>
                <a class="btn btn-default" href="ClientsList.aspx">View</a>
            </p>
        </div>
    </div>

</asp:Content>
