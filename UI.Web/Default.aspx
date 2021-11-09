<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>TP2 Web</h1>
        <p class="lead">Altas, bajas y modificaciones en web forms.</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>ABM Especialidades</h2>
            <p>
                <a runat="server" href="~/Especialidades" class="btn btn-primary btn-lg">Especialidades</a>
            </p>
        </div>

        <div class="col-md-4">
            <h2>ABM Planes</h2>
            <p>
                <a runat="server" href="~/Planes" class="btn btn-primary btn-lg">Planes</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>ABM Materias</h2>
            <p>
                <a runat="server" href="~/Materias" class="btn btn-primary btn-lg">Materias</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Login Alumno</h2>
            <p>
                <a runat="server" href="~/LogInAlumno" class="btn btn-primary btn-lg">Login</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Login Docente</h2>
            <p>
                <a runat="server" href="~/LogInDocente" class="btn btn-primary btn-lg">Login</a>
            </p>
        </div>
    </div>

</asp:Content>
