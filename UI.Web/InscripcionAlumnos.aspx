<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InscripcionAlumnos.aspx.cs" Inherits="UI.Web.InscripcionAlumnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="lead" style="color:#337ab7; padding:1rem 0rem; border-bottom: 1px solid #222;">Inscripción a Cursos.</p>
    <asp:Panel ID="GridPanel" runat="server">
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView_SelectedIndexChanged1" DataKeyNames="ID" CssClass="table">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID Curso" ReadOnly="True" />
                <asp:BoundField DataField="IDMateria" HeaderText="ID Materia" />
                <asp:BoundField DataField="IDComision" HeaderText="ID Comision" />
                <asp:BoundField DataField="AnioCalendario" HeaderText="Año calendario" />
                <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True"/>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server">
         <asp:LinkButton ID="inscripcionLinkButton" runat="server" OnClick="inscripcionLinkButton_Click" CssClass="btn btn-primary my-5 mx-2">Inscribirse</asp:LinkButton>
    </asp:Panel>
    <br/>
    <asp:Panel ID="formPanel" runat="server" Visible="False">
        <asp:Label ID="idLabel" runat="server" Text="ID Curso: "></asp:Label>
        <asp:TextBox ID="idTextBox" runat="server" Enabled ="false"></asp:TextBox>
        <br />
        <asp:Label ID="Label1" runat="server" Text="ID Materia: "></asp:Label>
        <asp:TextBox ID="idMateriaTextBox" runat="server" Enabled ="false"></asp:TextBox>
        <br/>
        <asp:Label ID="Label2" runat="server" Text="ID Comisión: "></asp:Label>
        <asp:TextBox ID="idComisionTextBox" runat="server" Enabled ="false"></asp:TextBox>
        <br/>
        <asp:Label ID="Label3" runat="server" Text="Año calendario: "></asp:Label>
        <asp:TextBox ID="anioCalTextBox" runat="server" Enabled ="false"></asp:TextBox>
        <br/>
        <asp:Label ID="Label4" runat="server" Text="Cupo: "></asp:Label>
        <asp:TextBox ID="cupoTextBox" runat="server" Enabled ="false"></asp:TextBox>
        <br/>
        <br/>
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="AceptarLinkButton" runat="server" CssClass="btn btn-success my-5 mx-2" OnClick="AceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="CancelarLinkButton" runat="server" CssClass="btn btn-danger my-5 mx-2" OnClick="CancelarLinkButton_Click" CausesValidation="false">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
