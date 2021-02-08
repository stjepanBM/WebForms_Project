<%@ Page Title="Prikaz osoba" Language="C#" MasterPageFile="~/Glavni.Master" AutoEventWireup="true" CodeBehind="PrikazOsoba.aspx.cs" Inherits="WebForms.PrikazOsoba" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>


<%@ MasterType VirtualPath="~/Glavni.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderTextContent" runat="server">
    <%: Page.Title %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #MainContent_gvUseri{
            width:100%;
        }

        #divGrid {
            margin-bottom: 5px;
        }
    </style>

    <div class="panel-group" id="accordion">
        <div id="divGrid" class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a href="#gridViewContent" data-parent="#accordion" data-toggle="collapse">Grid View
                    </a>

                </h4>
            </div>
            <div id="gridViewContent" class="panel-collapse collapse in ">
                <div class="panel-body">

                    <asp:GridView ID="gvUseri" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="IDUser" GridLines="Horizontal" OnRowEditing="gvUseri_RowEditing" OnRowUpdating="gvUseri_RowUpdating" OnSelectedIndexChanging="gvUseri_SelectedIndexChanging" OnRowCancelingEdit="gvUseri_RowCancelingEdit" ForeColor="Black" meta:resourcekey="gvUseriResource1">
                        <Columns>
                            <asp:TemplateField HeaderText="Ime" meta:resourcekey="TemplateFieldResource1">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" CssClass="form-control input-sm" runat="server" Text='<%# Bind("Name") %>' meta:resourcekey="TextBox2Resource1"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>' meta:resourcekey="Label1Resource1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Prezime" meta:resourcekey="TemplateFieldResource2">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" CssClass="form-control input-sm" runat="server" Text='<%# Bind("Surname") %>' meta:resourcekey="TextBox3Resource1"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Surname") %>' meta:resourcekey="Label2Resource1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" meta:resourcekey="TemplateFieldResource3">
                                <ItemTemplate>
                                    <asp:Repeater runat="server" ID="repEmail" DataSource='<%# Eval("Emails") %>'>
                                        <ItemTemplate>
                                            <div>
                                                <asp:HyperLink runat="server" Visible='<%# Eval("Email").ToString()!=string.Empty %>' Text='<%# Eval("Email") %>' NavigateUrl='<%# "mailto:" + Eval("Email") %>' meta:resourcekey="HyperLinkResource1" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Repeater runat="server" ID="repEditEmail" DataSource='<%# Eval("Emails") %>'>
                                        <ItemTemplate>
                                            <div style="margin: 5px 0;">


                                                <asp:TextBox Visible='<%# Eval("Email").ToString()!=string.Empty %>' runat="server" CssClass="form-control input-sm" Text='<%# Eval("Email") %>' meta:resourcekey="TextBoxResource1" />

                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Telefon" meta:resourcekey="TemplateFieldResource4">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" CssClass="form-control input-sm" runat="server" Text='<%# Bind("Telephone") %>' meta:resourcekey="TextBox4Resource1"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblTelephone" runat="server" Text='<%# Bind("Telephone") %>' meta:resourcekey="lblTelephoneResource1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField meta:resourcekey="TemplateFieldResource5">

                                <ItemTemplate>
                                    <asp:DropDownList CssClass="form-control input-sm" Width="120px" Enabled="False" ID="ddlItem" runat="server" DataSourceID="GridSource" DataTextField="Status" DataValueField="Status" SelectedValue='<%# Bind("Status") %>' meta:resourcekey="ddlItemResource1">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="GridSource" runat="server" ConnectionString="<%$ ConnectionStrings:ProjektWebFormsConnectionString %>" SelectCommand="SELECT DISTINCT Status FROM [User]"></asp:SqlDataSource>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList CssClass="form-control input-sm" ID="ddlEdit" runat="server" SelectedValue='<%# Bind("Status") %>' DataSourceID="SqlDataSource1" DataTextField="Status" DataValueField="Status" meta:resourcekey="ddlEditResource1">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProjektWebFormsConnectionString %>" SelectCommand="SELECT DISTINCT Status from [User]"></asp:SqlDataSource>
                                </EditItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False" meta:resourcekey="TemplateFieldResource6">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Ažuriraj" meta:resourcekey="LinkButton1Resource1"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Odustani" meta:resourcekey="LinkButton2Resource1"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" Visible='<%# Session["User"]!="Korisnik" %>' runat="server" CausesValidation="False" CommandName="Edit" Text="Uredi" meta:resourcekey="LinkButton1Resource2"></asp:LinkButton>
                                </ItemTemplate>
                                <ControlStyle ForeColor="#337AB7" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div id="divRepeater" class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a href="#repeaterContent" data-parent="#accordion" data-toggle="collapse">Repeater</a>
                </h4>
            </div>
            <div id="repeaterContent" class="panel-collapse collapse  ">
                <div class="panel-body">
                    <asp:Repeater ID="mojRepeater" runat="server">
                        <HeaderTemplate>
                            <table class="table table-condensed table-hover tblUseri">
                                <tr style="color: white; background: #333333; font-weight: normal; height: 30px;">
                                    <th>Name</th>
                                    <th>Surname</th>
                                    <th>E-mail</th>
                                    <th>Telephone</th>
                                    <th>Status</th>
                                    <th>City</th>
                                    <th>&nbsp;</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Name") %></td>
                                <td><%# Eval("Surname") %></td>
                                <td>
                                    <asp:Repeater runat="server" ID="repeaterMails" DataSource='<%# Eval("Emails") %>'>
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" Visible='<%# Eval("Email").ToString()!=string.Empty %>' Text='<%# Eval("Email") %>' NavigateUrl='<%# "mailto:" + Eval("Email") %>' meta:resourcekey="HyperLinkResource2" />
                                            <br />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <td><%# Eval("Telephone") %></td>
                                    <td><%# Eval("Status") %></td>
                                    <td><%# Eval("City") %></td>
                                    <td>
                                        <asp:LinkButton Visible='<%#  Session["User"]!="Korisnik" %>' ID="lbRepeaterUredi" CommandArgument='<%# Eval("IDUser") %>' OnClick="lbRepeaterUredi_Click" runat="server" CssClass="btn btn-primary" meta:resourcekey="lbRepeaterUrediResource1">Uredi</asp:LinkButton>
                                    </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>


    <asp:Label Visible="False" ID="lblError" runat="server" ForeColor="Red" meta:resourcekey="lblErrorResource1">greska</asp:Label>






</asp:Content>
