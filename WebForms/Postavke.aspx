<%@ Page Title="Postavke" Language="C#" MasterPageFile="~/Glavni.Master" AutoEventWireup="true" CodeBehind="Postavke.aspx.cs" Inherits="WebForms.Postavke" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>



<%@ MasterType VirtualPath="~/Glavni.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderTextContent" runat="server">
    <%: Page.Title %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <div class="formContainer">

        <div class="form-group">
            <asp:Label Text="Tema:" Font-Bold="True" runat="server" meta:resourcekey="LabelResource1" />
            <asp:DropDownList OnSelectedIndexChanged="ddlTema_SelectedIndexChanged" ID="ddlTema" runat="server" AutoPostBack="True" CssClass="form-control" meta:resourcekey="ddlTemaResource1">
                <asp:ListItem Value="0" meta:resourcekey="ListItemResource1">---odaberi---</asp:ListItem>
                <asp:ListItem Value="Predefinirana" meta:resourcekey="ListItemResource2">Predefinirana</asp:ListItem>
                <asp:ListItem Value="Plava" Text="Plava" meta:resourcekey="ListItemResource3"></asp:ListItem>
                <asp:ListItem Value="Crvena" Text="Crvena" meta:resourcekey="ListItemResource4"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label Text="Jezik:" Font-Bold="True" runat="server" meta:resourcekey="LabelResource2" />
            <asp:DropDownList  OnSelectedIndexChanged="ddlJezik_SelectedIndexChanged" ID="ddlJezik" runat="server" AutoPostBack="True" CssClass="form-control" meta:resourcekey="ddlJezikResource1">
                <asp:ListItem Value="0" meta:resourcekey="ListItemResource5">---odaberi---</asp:ListItem>
                <asp:ListItem Value="hr" meta:resourcekey="ListItemResource6">Hrvatski</asp:ListItem>
                <asp:ListItem Value="en" Text="Engleski" meta:resourcekey="ListItemResource7"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label Text="Repozitorij:" Font-Bold="True" runat="server" meta:resourcekey="LabelResource3" />
            <asp:DropDownList ID="ddlRepozitorij" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRepozitorij_SelectedIndexChanged" CssClass="form-control" meta:resourcekey="ddlRepozitorijResource1">
                <asp:ListItem Value="0" meta:resourcekey="ListItemResource8">---odaberi---</asp:ListItem>
                <asp:ListItem Value="1" meta:resourcekey="ListItemResource9">Tekstualna datoteka</asp:ListItem>
                <asp:ListItem Value="2" Text="Baza podataka" meta:resourcekey="ListItemResource10"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>




</asp:Content>
