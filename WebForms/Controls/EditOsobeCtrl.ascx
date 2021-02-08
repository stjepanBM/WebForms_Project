<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditOsobeCtrl.ascx.cs" Inherits="WebForms.Controls.EditOsobeCtrl" %>


<div class="osoba">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblIme" runat="server" Font-Bold="True" Text="Ime:" meta:resourcekey="lblImeResource1"></asp:Label>
                <asp:HiddenField ID="hiddenID" runat="server" />
                <asp:HiddenField ID="hiddenIndex" runat="server" />
            </td>
            <td>
                <asp:TextBox CssClass="form-control input-sm" ID="txtName" runat="server" meta:resourcekey="txtNameResource1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPrezime" runat="server" Font-Bold="True" Text="Prezime:" meta:resourcekey="lblPrezimeResource1"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="form-control input-sm" ID="txtSurname" runat="server" meta:resourcekey="txtSurnameResource1"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td></td>
            <td>

                <asp:DropDownList AutoPostBack="True" CssClass="form-control input-sm  " ID="ddlMails" OnSelectedIndexChanged="ddlMails_SelectedIndexChanged" runat="server" meta:resourcekey="ddlMailsResource1">
                </asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmail" runat="server" Font-Bold="True" Text="E-mail:" meta:resourcekey="lblEmailResource1"></asp:Label>

            </td>
            <td>


                <div class="input-group">
                    <asp:TextBox CssClass="form-control input-sm" ID="txtEmail" runat="server" meta:resourcekey="txtEmailResource1"></asp:TextBox>
                    <span class="input-group-btn">
                        <asp:LinkButton runat="server" ID="btnSaveMail" CssClass="btn btn-default btn-sm" OnClientClick="Toastr('success','Mail uspjesno azuriran');" OnClick="btnSaveMail_Click" meta:resourcekey="btnSaveMailResource1">
                            <span style="color:#0094ff;" class="glyphicon glyphicon-save"></span>
                        </asp:LinkButton>
                    </span>
                </div>


            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTelephone" runat="server" Font-Bold="True" Text="Telefon:" meta:resourcekey="lblTelephoneResource1"></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="txtTelephone" CssClass="form-control input-sm" runat="server" meta:resourcekey="txtTelephoneResource1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>

                <asp:Label ID="lblPassword" runat="server" Font-Bold="True" Text="Lozinka:" meta:resourcekey="lblPasswordResource1"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control input-sm" meta:resourcekey="txtPasswordResource1"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Text="Status" meta:resourcekey="lblStatusResource1"></asp:Label>
            </td>
            <td>
                <asp:DropDownList CssClass="form-control input-sm" ID="ddlStatusUsera" runat="server" meta:resourcekey="ddlStatusUseraResource1">
                    <asp:ListItem Text="Administrator" Value="Administrator" meta:resourcekey="ListItemResource1" />
                    <asp:ListItem Text="Korisnik" Value="Korisnik" meta:resourcekey="ListItemResource2" />
                </asp:DropDownList>

            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblCity" runat="server" Font-Bold="True" Text="Grad:" meta:resourcekey="lblCityResource1"></asp:Label>
            </td>
            <td>
                <asp:DropDownList CssClass="form-control input-sm" ID="ddlCityList" runat="server" meta:resourcekey="ddlCityListResource1">
                    <asp:ListItem Text="Zagreb" Value="Zagreb" meta:resourcekey="ListItemResource3" />
                    <asp:ListItem Text="Varazdin" Value="Varazdin" meta:resourcekey="ListItemResource4" />
                    <asp:ListItem Text="Split" Value="Split" meta:resourcekey="ListItemResource5" />
                    <asp:ListItem Text="Rijeka" Value="Rijeka" meta:resourcekey="ListItemResource6" />
                    <asp:ListItem Text="Pula" Value="Pula" meta:resourcekey="ListItemResource7" />
                    <asp:ListItem Text="Osijek" Value="Osijek" meta:resourcekey="ListItemResource8" />
                    <asp:ListItem Text="Dubrovnik" Value="Dubrovnik" meta:resourcekey="ListItemResource9" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnEdit" OnClick="btnEdit_Click" OnClientClick="Toastr('warning','Podaci uspjesno azurirani');" CssClass="btn btn-primary btn-sm btnCtrl" runat="server" Text="Edit" meta:resourcekey="btnEditResource1" />
                &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-warning btn-sm btnCtrl" OnClientClick="return confirmDelete(this, 'Obrisati osobu');" OnClick="btnDelete_Click" Text="Delete" meta:resourcekey="btnDeleteResource1" />
            </td>
        </tr>
    </table>


</div>
