<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="tp_cuatrimestral_equipo15.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div style="display: flex; justify-content: center; align-items: center; height: 83vh;">
        <div style="width: 20%">
            <h2 style="text-align: center; margin-bottom: 50px"> Registrarse </h2>
            <div class="form-floating mb-3">
              <%--<input type="text" class="form-control" id="floatingFirstname" placeholder="Correo Electrónico">--%>
                  <asp:TextBox ID="textNombre" Cssclass="form-control"  runat  ="server">      </asp:TextBox>
              <label for="floatingInput">Nombre</label>
            </div>
            <div class="form-floating mb-3">
              <%--<input type="text" class="form-control" id="floatingLastname" placeholder="Correo Electrónico">--%>
                <asp:TextBox ID="textApellido" Cssclass="form-control"  runat  ="server">      </asp:TextBox>
              <label for="floatingInput">Apellido</label>
            </div>
            <div class="form-floating mb-3">
             <%-- <input type="email" class="form-control" id="floatingEmail" placeholder="Correo Electrónico">--%>
                 <asp:TextBox ID="textEmail" Cssclass="form-control"  runat  ="server">      </asp:TextBox>
                <label for="floatingInput">Correo Electrónico</label>
            </div>
            <div class="form-floating">
              <%--<input type="password" class="form-control" id="floatingPassword" placeholder="Contraseña">--%>
                  <asp:TextBox ID="textContraseña" Cssclass="form-control"  runat  ="server">      </asp:TextBox>
              <label for="floatingPassword">Contraseña</label>
            </div>
            <asp:Button ID="btnRegistrarse" Text="Registrarse" type="submit" Cssclass="btn btn-success w-50 mx-auto mb-3 d-block" style="margin-top: 30px" runat ="server" Onclick="btnRegistrarse_Click" /> 
<%--<button type="submit" class="btn btn-success w-50 mx-auto mb-3 d-block" style="margin-top: 30px"> Registrarse </button>--%>
            <div style="margin-top: 40px">
                <p style="text-align: center"> Ya tenés una cuenta? <a href="Login.aspx"> Ingresar </a> </p>
            </div>
        </div>
    </div>
</asp:Content>
