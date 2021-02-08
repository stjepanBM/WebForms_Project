<%@ Page Title="Prijava" Language="C#" MasterPageFile="~/Glavni.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebForms.Login" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>



<%@ MasterType VirtualPath="~/Glavni.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderTextContent" runat="server">
    <%: Page.Title %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-lg-4 col-md-4 col-sm-4"></div>
        <div class="col-lg-4 col-md-4 col-sm-4">
            <div class="formContainer">

                <div class="form-group">
                    <span id="content_lblEmail" style="font-weight: bold;">E-mail:</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="E-mail je obavezno polje" ForeColor="Red" ControlToValidate="txtEmail" Display="Dynamic" ValidationGroup="pass" meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Kriva E-mail adresa" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" Display="Dynamic" ValidationGroup="pass" meta:resourcekey="RegularExpressionValidator1Resource1">*</asp:RegularExpressionValidator>
                    </span>
                    &nbsp;<asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" meta:resourcekey="txtEmailResource1" />
                  
                </div>
                <div class="form-group">
                    <span id="content_lblPass" style="font-weight: bold;">Lozinka:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lozinka je obavezno polje" ForeColor="Red" ControlToValidate="txtPass" ValidationGroup="pass" meta:resourcekey="RequiredFieldValidator2Resource1">*</asp:RequiredFieldValidator>
                    </span>
                    &nbsp;<asp:TextBox ID="txtPass" CssClass="form-control" runat="server" TextMode="Password" meta:resourcekey="txtPassResource1" />
                  
                </div>
                <asp:CheckBox runat="server" ID="checkboxLogin" CssClass="checkbox checkbox-inline " Text="Zapamti me" meta:resourcekey="checkboxLoginResource1" />
               
                <br />
                
                <asp:Button Text="Ulaz" OnClick="btnLogin_Click" runat="server" ID="btnLogin" CssClass="btn btn-primary" ValidationGroup="pass" meta:resourcekey="btnLoginResource1" />
                &nbsp;&nbsp;&nbsp;
                <br />
                <br />
                <asp:Label ID="lblInfo" runat="server" Text="Label" ForeColor="Red" Visible="False" meta:resourcekey="lblInfoResource1"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="pass" meta:resourcekey="ValidationSummary1Resource1" />
            </div>
        </div>
    </div>








</asp:Content>
