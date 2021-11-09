<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroNotas.aspx.cs" Inherits="UI.Web.RegistroNotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="lead" style="color:#337ab7; padding:1rem 0rem; border-bottom: 1px solid #222;">Registro de notas por curso.</p>
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
         <asp:LinkButton ID="elegirLinkButton" runat="server" OnClick="elegirLinkButton_Click" CssClass="btn btn-primary my-5 mx-2">Elegir curso.</asp:LinkButton>
    </asp:Panel>
</asp:Content>
