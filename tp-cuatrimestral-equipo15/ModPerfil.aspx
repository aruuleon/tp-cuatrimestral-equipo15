<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ModPerfil.aspx.cs" Inherits="tp_cuatrimestral_equipo15.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <style>
      .validacion{
          color: red;
          font-size: 12px;
      }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    
<div class="container"> 
    <div class="row justify-content-center" style="margin-top:20px;">
        <h2 style="text-align:center; margin-bottom:20px;">Mi perfil</h2>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="validacion" runat="server" ErrorMessage="* Este campo es requerido" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="validacion" runat="server" ErrorMessage="* Este campo es requerido" ControlToValidate="txtApellido"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" Enabled="false"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>
            <asp:Image ID="imgPerfil"  ImageUrl="https://www.filepicker.io/api/file/Km01a73PSDr2Q74TCYoe" runat="server" CssClass="img-fluid mb-3" Style="height:300px; width:300px; object-fit: contain;" />
          
        </div>

         <div class="justify-content-center" style="text-align:center; align-content:center; margin:50px" >
            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary btn-lg px-4 gap-3" Text="Guardar" OnClick="btnGuardar_Click"/>
            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger btn-lg px-4 gap-3" Text="Cancelar" OnClick="btnCancelar_Click"/>
        </div>
    </div>
</div>


</asp:Content>
