<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaCurso.aspx.cs" Inherits="tp_cuatrimestral_equipo15.AltaCurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .validacion {
            color: red;
            font-size: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <div class="p-3" style="width: 50%; margin-left: 10%; margin-bottom: 10px">
            <div class="p-2 mb-4" style="border-left: 2px solid #7b1fa2">
                <h1>Información curso</h1>
            </div>
        </div>
        <div class="row justify-content-center" style="margin-top: 20px;">
            <div class="col-md-8">
                <div>
                    <div class="mb-4">
                        <label class="form-label">Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" TextMode="SingleLine" Text="C# Nivel 1" ReadOnly="true"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="validacion" runat="server" ErrorMessage="* Este campo es requerido" ControlToValidate="txtResumen"></asp:RequiredFieldValidator>--%>
                    </div>
                    <div>
                        <label class="form-label">Resumen</label>
                        <asp:TextBox ID="txtResumen" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="validacion" runat="server" ErrorMessage="* Este campo es requerido" ControlToValidate="txtResumen"></asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <label class="form-label">Descripcion</label>
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="validatorTxtDescripcion" CssClass="validacion" runat="server" ErrorMessage="* Este campo es requerido" ControlToValidate="txtDescripcion"></asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <label class="form-label">Conocimientos Requeridos</label>
                        <asp:TextBox ID="txtConocimientos" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="validatorTxtConocimientos" CssClass="validacion" runat="server" ErrorMessage="* Este campo es requerido" ControlToValidate="txtConocimientos"></asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <label class="form-label">Programa</label>
                        <asp:TextBox ID="txtPrograma" runat="server" CssClass="form-control" placeholder="URL del Programa"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="validatorTxtPrograma" CssClass="validacion" runat="server" ErrorMessage="* Este campo es requerido" ControlToValidate="txtPrograma"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div>
                    <label class="form-label">Precio</label>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" Type="number" min="0"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="validatorRequeridoTxtPrecio" CssClass="validacion" runat="server" ErrorMessage="* Este campo es requerido" ControlToValidate="txtPrecio"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="validatorPositivoTxtPrecio" CssClass="validacion" runat="server" ErrorMessage="* Solo valores positivos" ControlToValidate="txtPrecio" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                </div>
                <picture class="d-flex justify-content-center" style="width:100%; min-height: 200px; margin-top:20px">
                    <img src="https://maxiprograma.com/assets/images/nivel-1.jpg" style="max-width: 100%; height:200px;" />
                </picture>
                <div class="justify-content-center" style="text-align: center; align-content: center; margin: 40px">
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary btn-lg px-4 gap-3" Text="Guardar" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger btn-lg px-4 gap-3" Text="Cancelar" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
