<%@ Page Title="Azuriranje osoba" Language="C#" MasterPageFile="~/Glavni.Master" AutoEventWireup="true" CodeBehind="AzuriranjeOsoba.aspx.cs" Inherits="WebForms.AzuriranjeOsoba" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>



<%@ MasterType VirtualPath="~/Glavni.Master" %>
<%@ Register Src="~/Controls/EditOsobeCtrl.ascx" TagPrefix="uc1" TagName="EditOsobeCtrl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderTextContent" runat="server">
    <%: Page.Title %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <div class="urediOsobu">
        <asp:PlaceHolder runat="server" ID="phUredi"></asp:PlaceHolder>
    </div>
</asp:Content>
