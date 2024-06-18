<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaCurso.aspx.cs" Inherits="tp_cuatrimestral_equipo15.AltaCurso" %>
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
         <h2 style="text-align:center; margin-bottom:20px;"><%= curso.Nombre %></h2>
         <div class="col-md-8">
            <div class="mb-3" >
                  <asp:Label ID="lblMensajeError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                 
             </div>
             
             
             <div class="mb-3" >
                 <label class="form-label">Subir portada desde mi PC</label>
                 <input type="file" id="txtImagen" runat="server" class="form-control" accept=".jpg"/>
             </div>
           
                <div class="mb-3">
                    <label class="form-label">Subir portada desde URL</label>
                    <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-control" placeholder="URL de la imagen"></asp:TextBox>
                </div>

             <div class="mb-3" style="text-align:center">
                <asp:Image ID="imgPortada"  ImageUrl="https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg" runat="server" CssClass="img-fluid mb-8" Style="height:300px; width:500px; object-fit: contain;" />
            </div>

              <div class="mb-3">
                 <label class="form-label">Programa</label>
                 <%--<input type="file" id="txtPrograma" runat="server" class="form-control" accept=".pdf" />--%>
                 <asp:TextBox ID="txtPrograma" runat="server" CssClass="form-control" placeholder="URL del Programa"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="validatorTxtPrograma" CssClass="validacion" runat="server" ErrorMessage="* Este campo es requerido" ControlToValidate="txtPrograma"></asp:RequiredFieldValidator>
             </div>
             <div class="mb-3">
                <label class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" Type="number"  min ="0"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validatorRequeridoTxtPrecio" CssClass="validacion" runat="server" ErrorMessage="* Este campo es requerido" ControlToValidate="txtPrecio"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="validatorPositivoTxtPrecio" CssClass="validacion" runat="server" ErrorMessage="* Solo valores positivos" ControlToValidate="txtPrecio" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
             </div>
             <div class="mb-3">
                 <label class="form-label">Descripcion</label>
                 <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="validatorTxtDescripcion" CssClass="validacion" runat="server" ErrorMessage="* Este campo es requerido" ControlToValidate="txtDescripcion"></asp:RequiredFieldValidator>
             </div>
              <div class="mb-3">
                 <label class="form-label">Conocimientos Requeridos</label>
                 <asp:TextBox ID="txtConocimientos" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="validatorTxtConocimientos" CssClass="validacion" runat="server" ErrorMessage="* Este campo es requerido" ControlToValidate="txtConocimientos"></asp:RequiredFieldValidator>
             </div>
              <div class="mb-3">
    <label class="form-label">Resumen</label>
    <asp:TextBox ID="txtResumen" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="validacion" runat="server" ErrorMessage="* Este campo es requerido" ControlToValidate="txtResumen"></asp:RequiredFieldValidator>
</div>

             <div class="justify-content-center" style="text-align:center; align-content:center; margin:50px" >
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary btn-lg px-4 gap-3" Text="Guardar" OnClick="btnGuardar_Click"/>
                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger btn-lg px-4 gap-3" Text="Cancelar" OnClick="btnCancelar_Click"/>
            </div>

             
         </div>
     </div>
 </div> 

</asp:Content>
