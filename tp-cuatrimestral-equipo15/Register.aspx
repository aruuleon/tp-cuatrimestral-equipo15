<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="tp_cuatrimestral_equipo15.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
         .validacion{
     color: red;
     font-size: 12px;
 }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div style="display: flex; justify-content: center; align-items: center; height: 83vh;">
        <div style="width: 20%">
            <h2 style="text-align: center; margin-bottom: 50px"> Registrarse </h2>
            <div class="form-floating mb-3">
                <asp:TextBox ID="txtNombre" Cssclass="form-control" runat="server" placeholder="Nombre"></asp:TextBox>
                <asp:RegularExpressionValidator Cssclass="validacion" ErrorMessage="Solo letras" ControlToValidate="txtNombre" validationExpression="^[A-Za-z#&áéíóúÁÉÍÓÚñÑ]+$"  runat="server" />
                 <asp:RequiredFieldValidator Cssclass="validacion"  ErrorMessage="El campo es requerido" ControlToValidate="txtNombre" runat="server" />
                <label for="floatingInput">Nombre</label>
            </div>
            <div class="form-floating mb-3">
                <asp:TextBox ID="txtApellido" Cssclass="form-control" runat="server" placeholder="Apellido"></asp:TextBox>
                 <asp:RegularExpressionValidator Cssclass="validacion" ErrorMessage="Solo letras" ControlToValidate="txtApellido" validationExpression="^[A-Za-z#&áéíóúÁÉÍÓÚñÑ]+$" runat="server" />
                 <asp:RequiredFieldValidator  Cssclass="validacion" ErrorMessage="El campo es requerido" ControlToValidate="txtApellido" runat="server" />
                <label for="floatingInput">Apellido</label>
            </div>
            <div class="form-floating mb-3">
                <asp:TextBox ID="txtEmail" Cssclass="form-control" runat="server" TextMode="Email" placeholder="Correo Electrónico"></asp:TextBox>
                 <asp:RegularExpressionValidator Cssclass="validacion" ErrorMessage="FormatoIncorrecto" ControlToValidate="txtEmail" ValidationExpression="^[\w.-]+@[\w-]+\.[a-zA-Z]{2,}$" runat="server" />
                <asp:RequiredFieldValidator Cssclass="validacion"  ErrorMessage="El campo es requerido" ControlToValidate="txtEmail" runat="server" />
                <asp:Label ID="lblMensajeError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>

                <label for="floatingInput">Correo Electrónico</label>
            </div>
            <div class="form-floating">
                <asp:TextBox ID="txtContrasenia" Cssclass="form-control" runat="server" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                <asp:RequiredFieldValidator Cssclass="validacion"  ErrorMessage="El campo es requerido" ControlToValidate="txtContrasenia" runat="server" />
                <label for="floatingPassword">Contraseña</label>
            </div>
            <asp:Button ID="RegisterButton" Text="Registrarse" type="submit" Cssclass="btn btn-success w-50 mx-auto mb-3 d-block" style="margin-top: 30px" runat ="server" Onclick="RegisterButton_Click" /> 
            <div style="margin-top: 40px">
                <p style="text-align: center"> Ya tenés una cuenta? <a href="Login.aspx"> Ingresar </a> </p>
            </div>
        </div>
    </div>
</asp:Content>
