<%@ Page Title="Dodavanje osoba" Language="C#" MasterPageFile="~/Glavni.Master" AutoEventWireup="true" CodeBehind="DodavanjeOsoba.aspx.cs" Inherits="WebForms.DodavanjeOsoba" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>


<%@ Register Src="~/Controls/AddPersonCtrl.ascx" TagPrefix="uc1" TagName="AddPersonctrl" %>

<%@ MasterType VirtualPath="~/Glavni.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderTextContent" runat="server">
    <%: Page.Title %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">


    <asp:PlaceHolder ID="plAddCtrl" runat="server"></asp:PlaceHolder>
</asp:Content>
