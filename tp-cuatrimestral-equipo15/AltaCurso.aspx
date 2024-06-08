<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaCurso.aspx.cs" Inherits="tp_cuatrimestral_equipo15.AltaCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        
       <div class="container">
     
     <div class="row justify-content-center" style="margin-top:20px;">
         <h2 style="text-align:center; margin-bottom:20px;">Nombre del Curso</h2>
         <div class="col-md-8">
              <div class="mb-3">
                 <label class="form-label">Foto Portada</label>
                 <input type="file" id="filePortada" runat="server" class="form-control" accept=".jpg" />
             </div>
           
             <div class="mb-3" style="text-align:center">
                <asp:Image ID="imgPortada"  ImageUrl="https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg" runat="server" CssClass="img-fluid mb-8" Style="height:300px; width:500px; object-fit: contain;" />
            </div>

              <div class="mb-3">
                 <label class="form-label">Programa</label>
                 <input type="file" id="filePrograma" runat="server" class="form-control" accept=".pdf" />
             </div>
             <div class="mb-3">
                <label class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" TextMode="Number" min="0"></asp:TextBox>
            </div>
             <div class="mb-3">
                 <label class="form-label">Descripcion</label>
                 <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
             </div>


              

             <div class="justify-content-center" style="text-align:center; align-content:center; margin-top:100px" >
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary btn-lg px-4 gap-3" Text="Guardar" />
                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger btn-lg px-4 gap-3" Text="Cancelar"/>
            </div>

             
         </div>
     </div>
 </div> 

</asp:Content>
