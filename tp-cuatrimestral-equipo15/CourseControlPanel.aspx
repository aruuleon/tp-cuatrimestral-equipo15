<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CourseControlPanel.aspx.cs" Inherits="tp_cuatrimestral_equipo15.CourseControlPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="p-3" style="width: 50%; margin-left: 10%; margin-bottom: 10px">
        <div class="p-2 mb-4" style="border-left: 2px solid #7b1fa2">
            <h1>Cursos</h1>
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
                <asp:Repeater runat="server" id="courseList">
                    <ItemTemplate>
                        <tr class="align-middle">
                            <td class="text-center"><%#Eval("ID")%></td>
                            <td><%#Eval("Nombre")%></td>
                            <td class="text-center"><%# String.Format(new System.Globalization.CultureInfo("es-AR"), "{0:C0}", Convert.ToInt32(Eval("Precio"))) %></td>
                            <td><img src='<%#ImagenUrl(Eval("ImagenPortada").ToString())%>' class="mx-auto d-block" alt="Avatar" style="width: 100px; height: 50px;"></td>
                            <td class="text-center">
                                <asp:HyperLink ID="HyperLinkPrograma" NavigateUrl='<%#Eval("Programa")%>' runat="server" CssClass="fa fa-file text-primary" Target="_blank"></asp:HyperLink>
                            </td>
                            <td class="text-center">
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="fa fa-edit text-success" PostBackUrl='<%# String.Format("~/AltaCurso.aspx?id={0}", Eval("ID")) %>'></asp:LinkButton>
                            </td>
                            <td class="text-center">
                                <asp:LinkButton ID="LinkButtonRemoveCourse" runat="server" CssClass="fa fa-trash text-danger"></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
