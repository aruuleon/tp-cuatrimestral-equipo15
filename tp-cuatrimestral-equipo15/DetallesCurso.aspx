<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetallesCurso.aspx.cs" Inherits="tp_cuatrimestral_equipo15.DetallesCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style="height: 600px; background-image: url('<%= curso.ImagenPortada.ToString() %>'); background-size: cover; background-position: center;"></div>
    <div class="d-flex p-3 ml-4" style="width: 100%; margin-left: 10%; margin-top: 30px; margin-bottom: 10px">
        <div style="width: 50%">
            <div class="p-2 mb-4" style="border-left: 2px solid #7b1fa2">
                <h1><%= curso.Nombre.ToString() %></h1>
            </div>
            <p style="font-size: 15px"><%= curso.Descripcion.ToString() %></p>
        </div>
        <div class="col" style="max-width: 20%; position:absolute; right: 10%">
            <div class="card h-100">
                <picture style="min-height: 200px; border-bottom: 1px solid rgba(0, 0, 0, 0.175)">
                    <img src="<%= curso.ImagenPortada.ToString() %>" style="max-width: 100%; height:200px" />
                </picture>
                <div class="card-body mb-4">
                    <h5 class="card-title"><%= curso.Nombre.ToString() %></h5>
                    <p class="card-text text-success"><%= curso.Precio.ToString("C0", new System.Globalization.CultureInfo("es-AR")) %></p>
                </div>
                <asp:HyperLink ID="HyperLinkBuy" runat="server" NavigateUrl="#" CssClass="btn btn-success w-50 mx-auto mb-3">Obtener Curso</asp:HyperLink>
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
