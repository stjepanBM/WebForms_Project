<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddPersonCtrl.ascx.cs" Inherits="WebForms.Controls.AddPersonCtrl" %>

<div class="formContainer" style="width: 100%; min-height: 300px;">
    <div class="col-lg-4 col-md-4 col-sm-4">

        <div class="form-group">
            <asp:Label ID="lblIme" Text="Ime:" Font-Bold="True" runat="server" meta:resourcekey="lblImeResource1" />
            <asp:RequiredFieldValidator ID="ImeValidator" runat="server" ControlToValidate="txtIme" ErrorMessage="Ime obavezno" ForeColor="Red" ValidationGroup="grupa" Display="Dynamic" meta:resourcekey="ImeValidatorResource1">*</asp:RequiredFieldValidator>

            <br />
            <asp:TextBox CssClass="form-control" ID="txtIme" runat="server" meta:resourcekey="txtImeResource1" />
        </div>
        <div class="form-group">
            <asp:Label ID="lblPrezime" Text="Prezime:" Font-Bold="True" runat="server" meta:resourcekey="lblPrezimeResource1" />
            <asp:RequiredFieldValidator ID="PrezimeValidator" runat="server" ControlToValidate="txtPrezime" ErrorMessage="Prezime obavezno" ForeColor="Red" ValidationGroup="grupa" Display="Dynamic" meta:resourcekey="PrezimeValidatorResource1">*</asp:RequiredFieldValidator>

            <asp:TextBox CssClass="form-control" ID="txtPrezime" runat="server" meta:resourcekey="txtPrezimeResource1" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblEmail" Text="E-mail:" Font-Bold="True" runat="server" meta:resourcekey="lblEmailResource1" />
            <asp:PlaceHolder ID="phEmails" runat="server"></asp:PlaceHolder>


        </div>

    </div>
    <div class="col-lg-4 col-md-4 col-sm-4">
        <div class="form-group">
            <asp:Label ID="lblTelefon" Text="Telefon:" Font-Bold="True" runat="server" meta:resourcekey="lblTelefonResource1" />
            <br />
            <asp:TextBox CssClass="form-control" ID="txtTelefon" runat="server" meta:resourcekey="txtTelefonResource1" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblGrad" Text="Grad:" Font-Bold="True" runat="server" meta:resourcekey="lblGradResource1" />
            <br />
            <asp:DropDownList ID="ddlGrad" runat="server" CssClass="form-control" meta:resourcekey="ddlGradResource1">
                <asp:ListItem Value="Zagreb" Text="Zagreb" Selected="True" meta:resourcekey="ListItemResource1" />
                <asp:ListItem Value="Varaždin" Text="Varaždin" meta:resourcekey="ListItemResource2" />
                <asp:ListItem Value="Split" Text="Split" meta:resourcekey="ListItemResource3" />
                <asp:ListItem Value="Rijeka" Text="Rijeka" meta:resourcekey="ListItemResource4" />
                <asp:ListItem Value="Pula" Text="Pula" meta:resourcekey="ListItemResource5" />
                <asp:ListItem Value="Osijek" Text="Osijek" meta:resourcekey="ListItemResource6" />
                <asp:ListItem Value="Dubrovnik" Text="Dubrovnik" meta:resourcekey="ListItemResource7" />
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="lblStatus" Text="Status:" Font-Bold="True" runat="server" meta:resourcekey="lblStatusResource1" />
            <asp:DropDownList ID="ddlUserType" CssClass="form-control" runat="server" meta:resourcekey="ddlUserTypeResource1">
                <asp:ListItem Value="Korisnik" Text="Korisnik" meta:resourcekey="ListItemResource8" />
                <asp:ListItem Value="Administrator" Text="Administrator" meta:resourcekey="ListItemResource9" />
            </asp:DropDownList>
        </div>


    </div>



    <div class="col-lg-4 col-md-4 col-sm-4">
        <div class="form-group">
            <asp:Label ID="lblPassword" Text="Lozinka:" Font-Bold="True" runat="server" meta:resourcekey="lblPasswordResource1" />
            <asp:RequiredFieldValidator ID="PassValidator" runat="server" ErrorMessage="Lozinka je obavezna" ForeColor="Red" ValidationGroup="grupa" ControlToValidate="txtLozinka" Display="Dynamic" meta:resourcekey="PassValidatorResource1">*</asp:RequiredFieldValidator>
            <br />
            <asp:TextBox CssClass="form-control" ID="txtLozinka" runat="server" meta:resourcekey="txtLozinkaResource1" TextMode="Password" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblConfirmPass" Text="Potvrda lozinke:" Font-Bold="True" runat="server" meta:resourcekey="lblConfirmPassResource1" />
            <asp:RequiredFieldValidator ID="ConfirmPassValidator" runat="server" ErrorMessage="Potvrda lozinke je obavezna" ForeColor="Red" ValidationGroup="grupa" ControlToValidate="txtPotvrda" Display="Dynamic" meta:resourcekey="ConfirmPassValidatorResource1">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtLozinka" ControlToValidate="txtPotvrda" ErrorMessage="Potvrda lozinke ne odgovara unesenoj lozinki." ForeColor="Red" ValidationGroup="grupa" meta:resourcekey="CompareValidator1Resource1">*</asp:CompareValidator>
            <br />
            <asp:TextBox CssClass="form-control" ID="txtPotvrda" runat="server" meta:resourcekey="txtPotvrdaResource1" TextMode="Password" />
        </div>

        <div class="form-group">
            <asp:LinkButton ID="btnDodaj" runat="server" OnClick="btnDodaj_Click" CssClass="btn btn-primary" Text="Dodaj" ValidationGroup="grupa" meta:resourcekey="btnDodajResource1" />
        </div>
    </div>
    <div class="col-lg-12 col-md-12 col-sm-12">

        <asp:ValidationSummary ID="AddPersonSummary" runat="server" ForeColor="Red" ValidationGroup="grupa" meta:resourcekey="AddPersonSummaryResource1" />

    </div>

</div>






