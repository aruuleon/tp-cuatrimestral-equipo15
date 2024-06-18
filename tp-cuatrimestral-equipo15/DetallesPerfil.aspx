<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetallesPerfil.aspx.cs" Inherits="tp_cuatrimestral_equipo15.DetallesPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="container"> 
    <div class="row justify-content-center" style="margin-top:20px;">
        <h2 style="text-align:center; margin-bottom:20px;">Mi perfil</h2>
        <div class="col-md-4" style="padding-left:50px;">
            <div class="mb-3">
                <label class="form-labe">Nombre:</label>
                <div>
                    <asp:Label ID="lblNombre" runat="server" Text="Label" CssClass="h5"></asp:Label>
                </div>
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido:</label>
                <div>
                    <asp:Label ID="lblApellido" runat="server" Text="Label" CssClass="h5"></asp:Label>
                </div>            

            </div>
            <div class="mb-3">
                <label class="form-label">Email:</label>
                <div>
                    <asp:Label ID="lblEmail" runat="server" Text="Label" CssClass="h5"></asp:Label>
                </div>            

            </div>
        </div>

         <div class="col-md-4" style="padding-left:50px;">

            <div class="mb-3">
                <label class="form-label">Imagen Perfil:</label>
            </div>
            <asp:Image ID="imgPerfil" runat="server" CssClass="img-fluid mb-3" Style="height:300px; width:300px; object-fit: contain;" />
          </div>

         <div class="justify-content-center" style="text-align:center; align-content:center; margin:50px" >
            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary btn-lg px-4 gap-3" Text="Modificar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger btn-lg px-4 gap-3" Text="Volver" OnClick="btnCancelar_Click"/>
        </div>
    </div>
</div>


</asp:Content>
