<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="StudentOnCoursePanel.aspx.cs" Inherits="tp_cuatrimestral_equipo15.StudenOnCoursePanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <div class="p-3" style="width: 50%; margin-left: 10%; margin-bottom: 10px">
        <div class="p-2 mb-4" style="border-left: 2px solid #7b1fa2">
            <h1>Estudiantes</h1>
        </div>
    </div>
    <div class="m-5 mx-auto w-75 d-flex justify-content-center">
        <table class="table table-bordered">
            <thead class="table-dark">
                <tr class="text-center">
                    <asp:Repeater runat="server" id="columnList">
                        <ItemTemplate>
                            <th scope="col"><%# Container.DataItem %></th>
                        </ItemTemplate>
                    </asp:Repeater>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" id="userList">
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
                                <asp:LinkButton ID="LinkButtonEditUser" runat="server" CssClass="fa fa-edit text-success"></asp:LinkButton>
                            </td>
                            <td class="text-center">
                                <asp:LinkButton ID="LinkButtonRemoveUser" runat="server" OnCommand="DeleteUserButton_Click" CommandArgument='<%# Eval("ID") %>' CssClass="bi bi-person-fill-x text-danger"></asp:LinkButton>
                            </td>
                            <td class="text-center">
                                <p><%# CheckEnrollmentStatus((int)Eval("ID")) %></p>
                            </td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
     <div class="justify-content-center" style="text-align:center; align-content:center; margin:50px" >
         <asp:HyperLink ID="btnCancelar" CssClass="btn btn-danger btn-lg px-4 gap-3" runat="server" href="CourseControlPanel.aspx" Visible="true">Volver</asp:HyperLink>
    </div>
</asp:Content>
