<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CourseControlPanel.aspx.cs" Inherits="tp_cuatrimestral_equipo15.CourseControlPanel" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
     .validacion {
         color: red;
         font-size: 20px;
     }
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="p-3" style="width: 50%; margin-left: 10%; margin-bottom: 10px">
        <div class="p-2 mb-4" style="border-left: 2px solid #7b1fa2">
            <h1>Cursos</h1>
        </div>
    </div>
    <div class="d-flex justify-content-center">
        <asp:LinkButton ID="LinkButtonPlatformCourse" runat="server" OnClick="LinkButtonPlatformCourse_Click" CssClass="btn m-2">En Plataforma</asp:LinkButton>
        <asp:LinkButton ID="LinkButtonMoodleCourse" runat="server" OnCommand="LinkButtonMoodleCourse_Click" CssClass="btn m-2">En Moodle</asp:LinkButton>
    </div>
    <asp:Panel ID="PanelPlatformCourse" runat="server" CssClass="tabcontent">
        <div class="m-5 mx-auto w-75 d-flex justify-content-center">
            <table class="table table-bordered">
                <thead class="table-dark">
                    <tr class="text-center">
                        <asp:Repeater runat="server" ID="columnListPlatform">
                            <ItemTemplate>
                                <th scope="col"><%# Container.DataItem %></th>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="courseListPlatform">
                        <ItemTemplate>
                            <tr class="align-middle">
                                <td class="text-center"><%#Eval("ID")%></td>
                                <td><%#Eval("Nombre")%></td>
                                <td class="text-center"><%# String.Format(new System.Globalization.CultureInfo("es-AR"), "{0:C0}", Convert.ToInt32(Eval("Precio"))) %></td>
                                <td>
                                    <img src='<%#Eval("ImagenPortada")%>' class="mx-auto d-block" alt="Avatar" style="width: 100px; height: 50px;"></td>
                                <td class="text-center">
                                    <asp:HyperLink ID="HyperLinkPrograma" NavigateUrl='<%#Eval("Programa")%>' runat="server" CssClass="fa fa-file text-primary" Target="_blank"></asp:HyperLink>
                                </td>
                                <td class="text-center">
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="fa fa-edit text-danger" PostBackUrl='<%# String.Format("~/AltaCurso.aspx?id={0}", Eval("ID")) %>'></asp:LinkButton>
                                </td>
                                <td class="text-center">
                                    <%--<asp:LinkButton ID="LinkButtonRemoveCourse" runat="server" CssClass="fa fa-trash text-danger" OnCommand="LinkButtonRemoveCourse_Command" CommandArgument="><%#Eval("ID")%>"> </asp:LinkButton>--%>
                                    <%--<asp:CheckBox Text="" runat="server" ID="checkBoxActivo" OnCheckedChanged="checkBoxActivo_CheckedChanged" AutoPostBack="true"/>--%>
                                     <asp:LinkButton ID="LinkButtonActivate" runat="server" OnCommand="LinkButtonActivate_Command" CommandArgument='<%# Eval("ID") %>' CssClass='<%# activeBotton((bool)Eval("Visible")) %>'></asp:LinkButton>
                                </td>
                                <td class="text-center">
                                    <asp:LinkButton ID="LinkButtonStudents" runat="server" OnCommand="LinkButtonStudents_Command" CommandArgument='<%#Eval("ID") %>' CssClass="fas fa-users text-warning"></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel ID="PanelMoodleCourse" runat="server" CssClass="tabcontent">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="m-5 mx-auto w-75 d-flex justify-content-center">
            <table class="table table-bordered">
                <thead class="table-dark">
                    <tr class="text-center">
                        <asp:Repeater runat="server" ID="columnListMoodle">
                            <ItemTemplate>
                                <th scope="col"><%# Container.DataItem %></th>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="courseListMoodle">
                        <ItemTemplate>
                            <tr class="align-middle">
                                <td class="text-center"><%#Eval("IdMoodle")%></td>
                                <td><%#Eval("Nombre")%></td>
                                <td>
                                    <img src='<%#Eval("ImagenPortada")%>' class="mx-auto d-block" alt="Avatar" style="width: 100px; height: 50px;">
                                </td>
                                <td class="text-center">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="LinkButtonEnable" runat="server" CssClass="fas fa-power-off text-success" CommandArgument='<%#Eval("IdMoodle") %>' OnCommand="LinkButtonEnable_Command" Style="display: block; margin-left: auto; margin-right: auto;"></asp:LinkButton>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            </td>
                     </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <asp:UpdatePanel ID="UpdatePanelModal" runat="server">
                <ContentTemplate>
                    <div id="ModalFormCourse" class="modal fade" role="dialog">
                        <div class="modal-dialog modal-dialog-centered">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <asp:Label ID="lblNameFormCourse" runat="server" CssClass="modal-title fw-semibold" Style="font-size: 20px"></asp:Label>
                                    
                                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                                </div>
                                <div class="modal-body">
                                    <asp:Label ID="lblIdMoodle" runat="server" Visible="false"></asp:Label>
                                    <picture class="d-flex justify-content-center align-items-center" style="min-height: 150px; margin-bottom: 20px">
                                        <asp:Image ID="imagenPortadaFormCourse" runat="server" Style="max-width: 100%; height: 150px" />
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
                                        <asp:LinkButton ID="LinkButtonConfirm" runat="server" CssClass="btn btn-success w-25" OnClick="LinkButtonConfirm_Click">Habilitar</asp:LinkButton>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                         <ContentTemplate>
                                            <div class="align-items-center text-center" style="margin:10px">
                                                <asp:Label ID="lblValidacion" runat="server" CssClass="validacion" Style="font-size:16px" ></asp:Label>
                                            </div>
                                         </ContentTemplate>
                                 </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>
    <div class="justify-content-center" style="text-align:center; align-content:center; margin:50px" >
        <asp:HyperLink ID="btnCancelar" CssClass="btn btn-danger btn-lg px-4 gap-3" runat="server" href="AdministratorHome.aspx" Visible="true">Volver</asp:HyperLink>
    </div>
</asp:Content>
