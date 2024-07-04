<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="StudentControlPanel.aspx.cs" Inherits="tp_cuatrimestral_equipo15.UserControlPanel" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     
            <div class="p-3" style="width: 50%; margin-left: 10%; margin-bottom: 10px">
        <div class="p-2 mb-4" style="border-left: 2px solid #7b1fa2">
            <h1>Estudiantes</h1>
        </div>
    </div>
     <div class="d-flex justify-content-center">
        <asp:LinkButton ID="LinkButtonPlatformUsers" runat="server" CssClass="btn m-2" OnClick="LinkButtonPlatformUsers_Click">En Plataforma</asp:LinkButton>
        <asp:LinkButton ID="LinkButtonMoodleUsers" runat="server"  CssClass="btn m-2" OnClick="LinkButtonMoodleUsers_Click">En Moodle</asp:LinkButton>
    </div>
    <asp:Panel ID="PanelPlatformUsers" runat="server" CssClass="tabcontent">
        <div class="m-5 mx-auto w-75 d-flex justify-content-center">
            <table class="table table-bordered">
                <thead class="table-dark">
                    <tr class="text-center">
                        <asp:Repeater runat="server" id="columnListPlatform">
                            <ItemTemplate>
                                <th scope="col"><%# Container.DataItem %></th>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" id="userListPlatform">
                        <ItemTemplate>
                            <tr class="align-middle">
                                <td class="text-center"><%#Eval("ID")%></td>
                                <td><%#Eval("Nombre")%></td>
                                <td><%#Eval("Apellido")%></td>
                                <td><%#Eval("Email")%></td>
                                <td>
                                    <img src='<%# ImagenUrl(Eval("Avatar").ToString())%>' class="mx-auto d-block" alt="Avatar" style="width: 50px; height: 50px;">
                                </td>
                                <td class="text-center">
                                    <asp:LinkButton ID= "LinkButtonActivate2" runat="server" OnCommand="LinkButtonActivate2_Command" CommandArgument='<%#Eval("ID") %>' CssClass='<%# activeBotton2((int)Eval("ID")) %>'></asp:LinkButton>

                                </td>
                                <td class="text-center">
                                    <p><%# CheckStatus((int)Eval("ID")) %></p>
                                </td>

                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </asp:Panel>
     <asp:Panel ID="PanelMoodleUsers" runat="server" CssClass="tabcontent">
         <div class="justify-content-center text-center" style="margin-top:10px">
            <p>La contraseña por defecto cuando se habilite un estudiante es "Usuario123!"</p>
        </div>
     <div class="m-5 mx-auto w-75 d-flex justify-content-center">

         <table class="table table-bordered">
             <thead class="table-dark">
                 <tr class="text-center">
                     <asp:Repeater runat="server" id="columnListMoodle">
                         <ItemTemplate>
                             <th scope="col"><%# Container.DataItem %></th>
                         </ItemTemplate>
                     </asp:Repeater>
                 </tr>
             </thead>
             <tbody>
                 <asp:Repeater runat="server" id="userListMoodle">
                     <ItemTemplate>
                         <tr class="align-middle">
                             <td class="text-center"><%#Eval("IdMoodle")%></td>
                             <td><%#Eval("Nombre")%></td>
                             <td><%#Eval("Apellido")%></td>
                             <td><%#Eval("Email")%></td>

                             <td class="text-center">
                                 <asp:LinkButton ID= "LinkButtonActivateMoodle" runat="server" OnCommand="LinkButtonActivateMoodle_Command" CommandArgument='<%#Eval("IdMoodle") %>' CssClass='bi bi-person-fill-down text-success'></asp:LinkButton>
                             </td>
                             <td class="text-center">
                                 <p><%# CheckStatusMoodle((int)Eval("Suspendido")) %></p>
                             </td>

                         </tr>
                     </ItemTemplate>
                 </asp:Repeater>
             </tbody>
         </table>
     </div>
 </asp:Panel>
     <div class="justify-content-center" style="text-align:center; align-content:center; margin:50px" >
         <asp:HyperLink ID="btnCancelar" CssClass="btn btn-danger btn-lg px-4 gap-3" runat="server" href="AdministratorHome.aspx" Visible="true">Volver</asp:HyperLink>
    </div>
</asp:Content>
