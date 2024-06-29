<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="tp_cuatrimestral_equipo15.Register" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
         .validacion{
            color: red;
            font-size: 12px;
            }
          .validacion_2{
            color: red;
            font-size: 15px;
            text-align:justify;
            margin:5px
          }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style="display: flex; justify-content: center; align-items: center; height: 83vh; margin-top:20px">
        <div style="width: 20%; margin-top:20px">
            <h2 style="text-align: center; margin-bottom: 30px;"> Registrarse </h2>
            <div class="form-floating mb-4">
                <asp:TextBox ID="txtNombre" Cssclass="form-control" runat="server" placeholder="Nombre"></asp:TextBox>
                <div style="position: relative;">
                    <asp:RegularExpressionValidator Cssclass="validacion" ErrorMessage="* Debes ingresar solo letras" ControlToValidate="txtNombre" validationExpression="^[A-Za-z#&áéíóúÁÉÍÓÚñÑ ]+$"  runat="server" style="position: absolute; left: 0;" />
                    <asp:RequiredFieldValidator Cssclass="validacion"  ErrorMessage="* Este campo es obligatorio" ControlToValidate="txtNombre" runat="server" style="position: absolute; left: 0;" />
                </div>
                <label for="floatingInput">Nombre</label>
            </div>
            <div class="form-floating mb-4">
                <asp:TextBox ID="txtApellido" Cssclass="form-control" runat="server" placeholder="Apellido"></asp:TextBox>
                <div style="position: relative;">
                    <asp:RegularExpressionValidator Cssclass="validacion" ErrorMessage="* Debes ingresar solo letras" ControlToValidate="txtApellido" validationExpression="^[A-Za-z#&áéíóúÁÉÍÓÚñÑ ]+$" runat="server" style="position: absolute; left: 0;" />
                    <asp:RequiredFieldValidator  Cssclass="validacion" ErrorMessage="* Este campo es obligatorio" ControlToValidate="txtApellido" runat="server" style="position: absolute; left: 0;" />
                </div>
                <label for="floatingInput">Apellido</label>
            </div>
            <div class="form-floating mb-4">
                <asp:TextBox ID="txtEmail" Cssclass="form-control" runat="server" TextMode="Email" placeholder="Correo Electrónico"></asp:TextBox>
                <div style="position: relative;">
                    <asp:RegularExpressionValidator Cssclass="validacion" ErrorMessage="FormatoIncorrecto" ControlToValidate="txtEmail" ValidationExpression="^[\w.-]+@[\w-]+\.[a-zA-Z]{2,}$" runat="server" style="position: absolute; left: 0;" />
                    <asp:RequiredFieldValidator Cssclass="validacion"  ErrorMessage="* Este campo es obligatorio" ControlToValidate="txtEmail" runat="server" style="position: absolute; left: 0;" />
                </div>
                <label for="floatingInput">Correo Electrónico</label>
            </div>
            <div class="form-floating mb-4">
                <asp:TextBox ID="txtContrasenia" Cssclass="form-control" runat="server" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                <div style="position: relative;">
                    <asp:RequiredFieldValidator Cssclass="validacion"  ErrorMessage="* Este campo es obligatorio" ControlToValidate="txtContrasenia" runat="server" style="position: absolute; left: 0;" />
                </div>
                <label for="floatingPassword">Contraseña</label>
            </div>
             <div class="form-floating mb-6" style="align-items:center">
            <asp:Label Text="Este correo electrónico ya se encuentra registrado" runat="server" CssClass="validacion_2" Visible="false" ID="lblUserInDb" />
            </div>

            <asp:Button ID="RegisterButton" Text="Registrarse" type="submit" Cssclass="btn btn-success w-50 mx-auto mb-3 d-block" style="margin-top: 30px" runat ="server" Onclick="RegisterButton_Click" /> 
            <div style="margin-top: 40px">
                <p style="text-align: center"> Ya tenés una cuenta? <a href="Login.aspx"> Ingresar </a> </p>
            </div>
        </div>
    </div>
</asp:Content>
