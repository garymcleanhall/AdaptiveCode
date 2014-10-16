<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="UI.AspNetWebForms.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h1><%: Title %></h1>
        <p class="lead">Your app description page.</p>
    </header>

    <div class="row-fluid">
        <div class="span12">
            <p>Use this area to provide additional information.</p>
        </div>
    </div>

</asp:Content>
