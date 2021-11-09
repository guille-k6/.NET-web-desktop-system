<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="lead" style="color:#337ab7; padding:1rem 0rem; border-bottom: 1px solid #222;">ABM Especialidades</p>
    <asp:Panel ID="GridPanel" runat="server" >
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView_SelectedIndexChanged1" DataKeyNames="ID" CssClass="table">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID Especialidad" ReadOnly="True"/>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"/>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True"/>
            </Columns>
        </asp:GridView>
    </asp:Panel>
        <asp:Panel ID="gridActionsPanel" runat="server">
             <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" CssClass="btn btn-primary my-5 mx-2">Editar</asp:LinkButton>
             <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" CssClass="btn btn-primary my-5 mx-2">Eliminar</asp:LinkButton>
             <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" CssClass="btn btn-primary my-5 mx-2">Nuevo</asp:LinkButton>
        </asp:Panel>
    <br />
    <asp:Panel ID="formPanel" runat="server" Visible="False">
        <asp:Label ID="idLabel" runat="server" Text="ID Especialidad: "></asp:Label>
        <asp:TextBox ID="idTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValidatorDescripcion" runat="server" ErrorMessage="La descripción no puede estar vacía." ControlToValidate="descripcionTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br/>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        <br/>
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="AceptarLinkButton" runat="server" OnClick="AceptarLinkButton_Click" CssClass="btn btn-success my-5 mx-2">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="CancelarLinkButton" runat="server" OnClick="CancelarLinkButton_Click" CssClass="btn btn-danger my-5 mx-2" CausesValidation="false">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    
</asp:Content>
