<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="CatalogoUsers.aspx.cs" Inherits="UsersUniversidad.CatalogoUsers" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/MenuEstilos.css" rel="stylesheet" />
    <h1>Información de usuarios</h1>
    <p>
        <asp:GridView ID="GridView1" runat="server" Height="153px" Width="234px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    </p>
    <p>
        Código:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tCodigo" runat="server"></asp:TextBox>
    </p>
    <p>
        Nombre:&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tNombre" runat="server"></asp:TextBox>
    </p>
    <p>
        Clave:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tClave" runat="server"></asp:TextBox>
    </p>
    <p>
        Edad:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tEdad" runat="server"></asp:TextBox>
    </p>
    <div class="padre">
        <asp:Button Class="button button1" ID="bIngresar" runat="server" OnClick="bIngresar_Click" text="Ingresar"/>
         <asp:Button Class="button button2" ID="bBorrar" runat="server" OnClick="bBorrar_Click" text="Borrar"/>
         <asp:Button Class="button button3" ID="bModificar" runat="server" OnClick="bModificar_Click" text="Modificar"/>
         <asp:Button Class="button button4" ID="bConsultar" runat="server" OnClick="bConsultar_Click" text="Consultar"/>
    </div>
</asp:Content>
