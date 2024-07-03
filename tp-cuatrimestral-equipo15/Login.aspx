<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="tp_cuatrimestral_equipo15.Login" Async="true" %>
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
            <div style="text-align:center; align-content:center">
                <asp:Label Text="Email o Contraseña incorectos" runat="server"  CssClass="validacion_2" Visible="false" ID="lblIncorrecto" />
                <asp:Label Text="Usuario Suspendido" runat="server"  CssClass="validacion_2" Visible="false" ID="lblSuspendido" />
            </div>
            <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-success w-50 mx-auto mb-3 d-block" style="margin-top: 30px" Text="Ingresar" OnClick="LoginButton_Click" />
            <div style="margin-top: 40px">
                <p style="text-align: center"> Todavía no te registraste? 
                    <asp:HyperLink ID="HyperLinkRegister" runat="server" NavigateUrl="~/Register.aspx">Registrarme</asp:HyperLink> 
                </p>
                <p style="text-align: center"> Olvidaste tu contraseña? 
                    <asp:LinkButton ID="LinkButtonRecoverPassword" runat="server" CssClass="link-style" OnClick="LinkButtonRecoverPassword_Click">Recuperar</asp:LinkButton>
                </p>
            </div>
            <div id="ModalFormRecoverPassword" class="modal fade" role="dialog">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Recuperar contraseña</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                        </div>
                        <div class="modal-body">
                            <p class="text-secondary" style="font-size: 14px">Te enviaremos un correo electrónico con la nueva contraseña para que puedas ingresar a la plataforma. Podrás cambiar la misma cuando quieras.</p>
                            <br />
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtEmailFormRecoverPassword" runat="server" CssClass="form-control" TextMode="Email" placeholder="Correo Electrónico"></asp:TextBox>
                                <label for="floatingInput">Correo Electrónico</label>
                            </div>
                        </div>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="modal-footer d-flex justify-content-center align-items-center" style="margin-bottom: 10px">
                                    <asp:LinkButton ID="LinkButtonSendEmail" runat="server" CssClass="btn w-25" style="background-color: #7b1fa2; color: #fff" OnClick="LinkButtonSendEmail_Click">Enviar</asp:LinkButton>
                                </div>
                                <div style="text-align: center; margin-bottom: 20px">
                                    <asp:Label ID="lblMessageRecoverPassword" runat="server" style="font-size: 14px"></asp:Label>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
