<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tp_cuatrimestral_equipo15.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="carouselExampleAutoplaying" class="carousel slide" data-bs-ride="carousel" style="width: 100%; height:500px">
        <img src="https://maxiprograma.com/assets/images/maxi-programa-banner.jpg" style="width: 100%; height:500px" />
    </div>
    <div class="w-25 mt-5 mx-auto">
        <asp:TextBox runat="server" ID="filter" CssClass="form-control" Style="color: rgba(0, 0, 0, 0.175)" AutoPostBack="true" placeholder="Buscar Cursos">  </asp:TextBox>
    </div>
    <div class="row row-cols-1 row-cols-md-4 g-4 m-5 mx-auto w-75">
        <asp:Repeater runat="server" id="listaCursos">
            <ItemTemplate>
                <div class="col" style="max-width: 75%">
                    <div class="card h-100">
                        <picture style="min-height: 220px; border-bottom: 1px solid rgba(0, 0, 0, 0.175)">
                            <asp:Image runat="server" ImageUrl='<%#Eval("ImagenPortada")%>' Style="max-width: 100%; height:100%" />
                        </picture>
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text text-success">$ <%#Eval("Precio")%></p>
                            <p class="card-text" style="font-size: 14px"><%#Eval("Resumen")%></p>
                        </div>
                        <asp:LinkButton ID="LinkButtonCourseDetail" runat="server" PostBackUrl='<%# "DetallesCurso.aspx?id=" + Eval("ID") %>' CssClass="btn btn-success w-50 mx-auto mb-3 w-75">Ver Detalle</asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>