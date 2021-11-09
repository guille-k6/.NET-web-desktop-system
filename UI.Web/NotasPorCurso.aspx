<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NotasPorCurso.aspx.cs" Inherits="UI.Web.NotasPorCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />  
    <p class="lead" style="color:#337ab7; padding:1rem 0rem; border-bottom: 1px solid #222;">Registro de notas del curso.</p>   
    <asp:Panel ID="GridPanel" runat="server">
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView_SelectedIndexChanged1" DataKeyNames="ID" CssClass="table">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID Inscripcion" ReadOnly="True" />
                <asp:BoundField DataField="IDAlumno" HeaderText="ID Alumno" />
                <asp:BoundField DataField="IDCurso" HeaderText="ID Curso" />
                <asp:BoundField DataField="Condicion" HeaderText="Año calendario" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True"/>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <br />
    <asp:Panel ID="gridActionsPanel" runat="server">
         <asp:LinkButton ID="actualizarLinkButton" runat="server" OnClick="actualizarLinkButton_Click" CssClass="btn btn-primary my-5 mx-2">Actualizar</asp:LinkButton>
    </asp:Panel>
    <br/>
    <asp:Panel ID="formPanel" runat="server" Visible="False">
        <asp:Label ID="idLabel" runat="server" Text="ID Alumno: "></asp:Label>
        <asp:TextBox ID="IDAlumnoTextBox" runat="server" Enabled ="false"></asp:TextBox>
        <br/>
        <asp:Label ID="Label3" runat="server" Text="ID Curso: "></asp:Label>
        <asp:TextBox ID="IDCursoTextBox" runat="server" Enabled ="false"></asp:TextBox>
        <br/>
        <asp:Label ID="Label4" runat="server" Text="Condicion: "></asp:Label>
        <asp:TextBox ID="condicionTextBox" runat="server" Enabled ="false"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValidatorCondicion" runat="server" ErrorMessage="La condición no puede estar vacia." ControlToValidate="condicionTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="Label5" runat="server" Text="Nota: "></asp:Label>
        <asp:TextBox ID="notaTextBox" runat="server" Enabled ="false"></asp:TextBox>
        <asp:RangeValidator ID="RangeNotaValidator" runat="server" ControlToValidate="notaTextBox" ErrorMessage="La nota debe estar en un rango de 0-10" MaximumValue="10" MinimumValue="-1" Type="Integer" ForeColor ="Red">*</asp:RangeValidator>
        <asp:RequiredFieldValidator ID="ValidatorNota" runat="server" ErrorMessage="La nota no puede estar vacia." ControlToValidate="notaTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="AceptarLinkButton" runat="server" CssClass="btn btn-success my-5 mx-2" OnClick="AceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="CancelarLinkButton" runat="server" CssClass="btn btn-danger my-5 mx-2" OnClick="CancelarLinkButton_Click" CausesValidation="false">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
