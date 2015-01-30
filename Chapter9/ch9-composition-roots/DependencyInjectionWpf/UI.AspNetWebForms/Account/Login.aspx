<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.AspNetWebForms.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>

    <div class="row-fluid">
        <div class="span7">
            <section id="loginForm">
                
                <fieldset class="form-horizontal">
                    <legend>Use a local account to log in.</legend>
                      <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-error">
                            <asp:Literal runat="server" ID="Literal1" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="control-group">
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="control-label">User name</asp:Label>
                        <div class="controls">
                            <asp:TextBox runat="server" ID="UserName" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                CssClass="text-error" ErrorMessage="The user name field is required." />
                        </div>
                    </div>
                    <div class="control-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="control-label">Password</asp:Label>
                        <div class="controls">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-error" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <label class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                            </label>
                        </div>
                    </div>
                    <div class="form-actions no-color">
                        <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn" />
                    </div>
                </fieldset>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
                    if you don't have a local account.
                </p>
            </section>
        </div>

        <div class="span5">
            <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
        </div>
    </div>
</asp:Content>
