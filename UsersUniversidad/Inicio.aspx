<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="UsersUniversidad.WebForm1" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 620px;
            height: 335px;
            left: 224px;
            top: 152px;
        }
        .centrar{
            text-align:center;
        }
        .inicio{
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="inicio">Inicio</h1>
    <div class="centrar"><img src="images/welcome-sign.jpg" alt="Alternate Text" class="auto-style1" /></div>
</asp:Content>

