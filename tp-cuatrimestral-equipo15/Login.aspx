<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="tp_cuatrimestral_equipo15.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <style>
     .validacion{
         color: red;
         font-size: 12px;
     }
     .validacion_2{
    color: red;
    font-size: 15px;
    text-align:center;
    margin:20px
    }
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style="display: flex; justify-content: center; align-items: center; height: 83vh;">
        <div style="width: 20%">
            <h2 style="text-align: center; margin-bottom: 50px"> Iniciar Sesión </h2>
            <div class="form-floating mb-3">
              <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Correo Electrónico"></asp:TextBox>
              <label for="floatingInput">Correo Electrónico</label>
              <asp:RequiredFieldValidator ID="validatorTxtEmail" CssClass="validacion" runat="server" ErrorMessage="* Este campo es requerido" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
            </div>
            <div class="form-floating">
              <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
              <label for="floatingPassword">Contraseña</label>
              <asp:RequiredFieldValidator ID="validatorTxtPassword" CssClass="validacion" runat="server" ErrorMessage="* Este campo es requerido" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
            </div>
            <asp:Label Text="Email o Contraseña incorectos" runat="server"  CssClass="validacion_2" Visible="false" ID="lblIncorrecto" />
            <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-success w-50 mx-auto mb-3 d-block" style="margin-top: 30px" Text="Ingresar" OnClick="LoginButton_Click" />
            <div style="margin-top: 40px">
                <p style="text-align: center"> Todavía no te registraste? <a href="Register.aspx"> Registrarme </a> </p>
                <p style="text-align: center"> Olvidaste tu contraseña? <a href="#"> Recuperar </a> </p>
            </div>
        </div>
    </div>
</asp:Content>
