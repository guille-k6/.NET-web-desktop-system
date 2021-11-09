<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="lead" style="color:#337ab7; padding:1rem 0rem; border-bottom: 1px solid #222;">ABM Materias</p>
    <asp:Panel ID="GridPanel" runat="server">
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView_SelectedIndexChanged1" CssClass="table" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID Materia" ReadOnly="True" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="HSSemanales" HeaderText="Horas Semanales" />
                <asp:BoundField DataField="HSTotales" HeaderText="Horas Totales" />
                <asp:BoundField DataField="IDPlan" HeaderText="ID Plan" />
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
        <asp:Label ID="idLabel" runat="server" Text="ID Plan: "></asp:Label>
        <asp:TextBox ID="idTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValidatorDescripcion" runat="server" ErrorMessage="La descripción no puede estar vacia." ControlToValidate="descripcionTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="hsSemanalesLabel" runat="server" Text="Horas semanales: "></asp:Label>
        <asp:TextBox ID="hsSemanalesTextBox" runat="server"></asp:TextBox>
        <asp:RangeValidator ID="RangeValidatorHsSemanales" runat="server" ControlToValidate="hsSemanalesTextBox" ErrorMessage="Ingresar horas semanales en el rango 6-12" MaximumValue="12" MinimumValue="6" Type="Integer" ForeColor ="Red">*</asp:RangeValidator>
        <asp:RequiredFieldValidator ID="ValidatorHsSemanales" runat="server" ErrorMessage="Las horas semanales no pueden estar vacías." ControlToValidate="hsSemanalesTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="hsTotalesLabel" runat="server" Text="Horas totales: "></asp:Label>
        <asp:TextBox ID="hsTotalesTextBox" runat="server"></asp:TextBox> 
        <asp:RangeValidator ID="RangeValidatorHsTotales" runat="server" ControlToValidate="hsTotalesTextBox" ErrorMessage="Ingresar horas totales en el rango 96-384" MaximumValue="384" MinimumValue="96" Type="Integer" ForeColor ="Red">*</asp:RangeValidator>
        <asp:RequiredFieldValidator ID="ValidatorHsTotales" runat="server" ErrorMessage="Las horas totales no pueden estar vacías." ControlToValidate="hsTotalesTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="idPlanLabel" runat="server" Text="Id Plan: "></asp:Label>
        <asp:DropDownList ID="idPlanDropDown" runat="server"></asp:DropDownList>
        <br/>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        <asp:Panel ID="formActionsPanel" runat="server">
            <br />
            <asp:LinkButton ID="AceptarLinkButton" runat="server" OnClick="AceptarLinkButton_Click" CssClass="btn btn-success my-5 mx-2">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="CancelarLinkButton" runat="server" OnClick="CancelarLinkButton_Click" CausesValidation="false" CssClass="btn btn-danger my-5 mx-2">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    
</asp:Content>
