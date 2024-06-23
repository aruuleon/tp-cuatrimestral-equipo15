<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetallesCurso.aspx.cs" Inherits="tp_cuatrimestral_equipo15.DetallesCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style="height: 600px; background-image: url('<%=ResolveUrl(ImagenPortada).ToString()%>'); background-size: cover; background-position: center;"></div>
    
    <div class="d-flex p-3 ml-4" style="width: 100%; margin-left: 10%; margin-top: 30px; margin-bottom: 10px">
        <div style="width: 50%">
            <div class="p-2 mb-4" style="border-left: 2px solid #7b1fa2">
                <h1><%= course.Nombre.ToString() %></h1>
            </div>
            <p style="font-size: 15px"><%= course.Descripcion.ToString() %></p>
        </div>
        <div class="col" style="max-width: 20%; position:absolute; right: 10%">
            <div class="card h-100">
                <picture style="min-height: 200px; border-bottom: 1px solid rgba(0, 0, 0, 0.175)">
                    <img src="<%= ResolveUrl(ImagenPortada).ToString() %>" style="max-width: 100%; height:200px" />
                </picture>
                <div class="card-body mb-4">
                    <h5 class="card-title"><%= course.Nombre.ToString() %></h5>
                    <asp:Label ID="LabelPrice" runat="server" CssClass="card-text text-success"></asp:Label>
                </div>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="LinkButtonGetOrView" runat="server" CssClass="w-50 mx-auto mb-3" style="display: block; margin-left: auto; margin-right: auto;" OnClick="LinkButtonGetOrView_Click"></asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="ModalFormBuy" class="modal fade" role="dialog">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title"><%= course.Nombre.ToString() %></h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                        </div>
                        <div class="modal-body">
                        <picture class="d-flex justify-content-center align-items-center" style="min-height: 150px; margin-bottom: 20px">
                            <img src="<%= ResolveUrl(ImagenPortada).ToString() %>" style="max-width: 100%; height:150px" />
                        </picture>
                        <div class="d-flex justify-content-between">
                            <div class="form-floating mb-4" style="width: 49%">
                                <asp:TextBox ID="txtNombreFormBuy" Cssclass="form-control" runat="server" placeholder="Nombre"></asp:TextBox>
                                <label for="floatingInput">Nombre</label>
                            </div>
                            <div class="form-floating mb-4" style="width: 49%">
                                <asp:TextBox ID="txtApellidoFormBuy" Cssclass="form-control" runat="server" placeholder="Apellido"></asp:TextBox>
                                <label for="floatingInput">Apellido</label>
                            </div>
                        </div>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtEmailFormBuy" runat="server" CssClass="form-control" TextMode="Email" placeholder="Correo Electrónico"></asp:TextBox>
                            <label for="floatingInput">Correo Electrónico></label>
                        </div>
                        </div>
                        <div class="modal-footer d-flex justify-content-between align-items-center">
                            <asp:Label ID="LabelPriceFormBuy" runat="server" CssClass="card-text fw-semibold"></asp:Label>
                            <asp:LinkButton ID="LinkButtonBuy" runat="server" CssClass="btn btn-success w-25" OnClick="LinkButtonBuy_Click">Pagar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HyperLink ID="HyperLinkProgram" runat="server" Target="_blank" CssClass="btn w-100 mt-5" style="color: #fff; background-color: #7b1fa2;">Ver Programa Completo</asp:HyperLink>
        </div>
    </div>
    <div class="p-3" style="width: 50%; margin-left: 10%; margin-bottom: 10px">
        <div class="p-2 mb-4" style="border-left: 2px solid #7b1fa2">
            <h1> Conocimientos requeridos </h1>
        </div>
        <asp:Literal ID="LiteralConocimientosRequeridos" runat="server"></asp:Literal>
    </div>
    <div class="p-3" style="width: 50%; margin-left: 10%; margin-bottom: 10px">
        <div class="p-2 mb-4" style="border-left: 2px solid #7b1fa2">
            <h1> Certificación </h1>
        </div>
        <span style="font-size: 15px">Certificado [maxiprograma.com] de aprobación del curso.</span><br />
        <span style="font-size: 15px">El certificado de aprobación del curso estará atado a la entrega y aprobación de las actividades correspondientes.</span><br />
    </div>
    <div class="p-3" style="width: 50%; margin-left: 10%; margin-bottom: 10px">
        <div class="p-2 mb-4" style="border-left: 2px solid #7b1fa2">
            <h1> Docente </h1>
        </div>
        <asp:Repeater ID="informacionDocente" runat="server">
            <ItemTemplate>
                <p style="font-size: 15px"><%# Container.DataItem %></p>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
