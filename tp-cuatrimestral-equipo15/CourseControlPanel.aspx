<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CourseControlPanel.aspx.cs" Inherits="tp_cuatrimestral_equipo15.CourseControlPanel" async="true"%>

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
                    <asp:Repeater runat="server" ID="columnList">
                        <ItemTemplate>
                            <th scope="col"><%# Container.DataItem %></th>
                        </ItemTemplate>
                    </asp:Repeater>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="courseList">
                    <ItemTemplate>
                        <%if ((bool)Session["Moodle"] == true)
                            { %>
                        <tr class="align-middle">
                            <td class="text-center"><%#Eval("IdMoodle")%></td>
                            <td><%#Eval("Nombre")%></td>
                            <%--<td class="text-center"><%# String.Format(new System.Globalization.CultureInfo("es-AR"), "{0:C0}", Convert.ToInt32(Eval("Precio"))) %></td>--%>
                            <td>
                                <img src=<%#Eval("ImagenPortada")%> class="mx-auto d-block" alt="Avatar" style="width: 100px; height: 50px;">
                            </td>
                            <%--<td class="text-center">
                                <asp:HyperLink ID="HyperLinkPrograma" NavigateUrl='<%#Eval("Programa")%>' runat="server" CssClass="fa fa-file text-primary" Target="_blank"></asp:HyperLink>
                            </td>
                            <td class="text-center">
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="fa fa-edit text-success" PostBackUrl='<%# String.Format("~/AltaCurso.aspx?id={0}", Eval("ID")) %>'></asp:LinkButton>
                            </td>--%>
                            <td class="text-center">
                                <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
                                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>--%>
                                <asp:LinkButton ID="LinkButtonEnable" runat="server" CssClass="fas fa-power-off text-success" OnClick="LinkButtonEnable_Click" Style="display: block; margin-left: auto; margin-right: auto;"></asp:LinkButton>
                                <%-- </ContentTemplate>
                                </asp:UpdatePanel>--%>
                           
                            </td>
                        </tr>
                        <%}%>
                         <%if ((bool)Session["Moodle"] == false)
                         { %>
                         <tr class="align-middle">
                             <td class="text-center"><%#Eval("IdMoodle")%></td>
                             <td><%#Eval("Nombre")%></td>
                             <td class="text-center"><%# String.Format(new System.Globalization.CultureInfo("es-AR"), "{0:C0}", Convert.ToInt32(Eval("Precio"))) %></td>
                             <td>
                                 <img src=<%#Eval("ImagenPortada")%> class="mx-auto d-block" alt="Avatar" style="width: 100px; height: 50px;">
                             </td>
                             <td class="text-center">
                                 <asp:HyperLink ID="HyperLinkPrograma" NavigateUrl='<%#Eval("Programa")%>' runat="server" CssClass="fa fa-file text-primary" Target="_blank"></asp:HyperLink>
                             </td>
                             <td class="text-center">
                                 <asp:LinkButton ID="LinkButton1" runat="server" CssClass="fa fa-edit text-success" PostBackUrl='<%# String.Format("~/AltaCurso.aspx?id={0}", Eval("ID")) %>'></asp:LinkButton>
                             </td>
                             <%--<td class="text-center">
                                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                     <ContentTemplate>
                                  </ContentTemplate>
                                 </asp:UpdatePanel>--%>
    
                             </td>
                         </tr>
                     <%}%>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div id="ModalFormCourse" class="modal fade" role="dialog">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Registro de curso C# Nivel 1</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                    </div>
                    <div class="modal-body">
                        <picture class="d-flex justify-content-center align-items-center" style="min-height: 150px; margin-bottom: 20px">
                            <img src="https://maxiprograma.com/assets/images/nivel-1.jpg" style="max-width: 100%; height: 150px" />
                        </picture>
                        <div class="d-flex justify-content-between">
                            <div class="form-floating mb-4 w-100">
                                <asp:TextBox ID="txtResumeFormCourse" CssClass="form-control" runat="server" placeholder="Resumen" TextMode="MultiLine"></asp:TextBox>
                                <label for="floatingInput">Resumen</label>
                            </div>
                        </div>
                        <div class="d-flex justify-content-between">
                            <div class="form-floating mb-4 w-100">
                                <asp:TextBox ID="txtDescriptionFormCourse" CssClass="form-control" runat="server" placeholder="Descripción" TextMode="MultiLine"></asp:TextBox>
                                <label for="floatingInput">Descripción</label>
                            </div>
                        </div>
                        <div class="d-flex justify-content-between">
                            <div class="form-floating mb-4 w-100">
                                <asp:TextBox ID="txtRequiredKnowledgeFormCourse" CssClass="form-control" runat="server" placeholder="Conocimientos Requeridos" TextMode="MultiLine"></asp:TextBox>
                                <label for="floatingInput">Conocimientos requeridos</label>
                            </div>
                        </div>
                        <div class="d-flex justify-content-between">
                            <div class="form-floating mb-4 w-100">
                                <asp:TextBox ID="txtProgramFormCourse" CssClass="form-control" runat="server" placeholder="Programa"></asp:TextBox>
                                <label for="floatingInput">Programa</label>
                            </div>
                        </div>
                        <div class="d-flex justify-content-between align-items-center">
                            <div class="form-floating w-50">
                                <asp:TextBox ID="txtPriceFormCourse" CssClass="form-control" runat="server" placeholder="Precio" Type="number" min="0"></asp:TextBox>
                                <label for="floatingInput">Precio</label>
                            </div>
                            <asp:LinkButton ID="LinkButtonConfirm" runat="server" CssClass="btn btn-success w-25">Habilitar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
  <div class="justify-content-center" style="text-align:center;align-content:center; margin:50px" >
     <asp:Button ID="btnCursosDB" runat="server" CssClass="btn btn-dark btn-lg px-4 gap-3" Text="Cargados" Onclick="btnCursosDB_Click"/>
     <asp:Button ID="btnCursosMoodle" runat="server" CssClass="btn btn-primary btn-lg px-4 gap-3" Text="Nuevos" Onclick="btnCursosMoodle_Click"/>
 </div>
</asp:Content>
