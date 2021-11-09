<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogInAlumno.aspx.cs" Inherits="UI.Web.LogInAlumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Log in de Alumnos</h2>
    <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="nomUsuLabel" runat="server" Text="Nombre de usuario: "></asp:Label>
        <asp:TextBox ID="nomUsuTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorNomUsu" runat="server" ErrorMessage="El nombre de usuario no puede estar vacío." ControlToValidate="nomUsuTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="passLabel" runat="server" Text="Contraseña: "></asp:Label>
        <asp:TextBox ID="passTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorContraseña" runat="server" ErrorMessage="La contraseña no puede estar vacía." ControlToValidate="passTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:LinkButton ID="ingresarButton" runat="server" OnClick="ingresarButton_Click" CssClass="btn btn-primary my-5 mx-2">Ingresar</asp:LinkButton>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
    </asp:Panel>
</asp:Content>
