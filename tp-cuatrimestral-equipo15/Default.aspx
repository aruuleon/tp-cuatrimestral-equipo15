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
    <div class="col" style="max-width: 75%">
        <div class="card h-100">
            <picture style="min-height: 220px; border-bottom: 1px solid rgba(0, 0, 0, 0.175)">
                <img src="https://maxiprograma.com/assets/images/nivel-1.jpg" style="max-width: 100%; height:100%" />
            </picture>
            <div class="card-body">
                <h5 class="card-title">C# Nivel 1</h5>
                <p class="card-text text-success">$ 30.000</p>
                <%--<p class="card-text">Este curso es el comienzo del código. Ideal para arrancar desde cero, complementar con el curso gratis u ordenar los conocimientos que tengas si ya venís intentando aprender. No requiere conocimientos previos.</p>--%>
            </div>
            <button type="button" class="btn btn-success w-50 mx-auto mb-3">
                <a href="" class="w-100 btn btn-success">Obtener</a>
            </button>
        </div>
    </div>
    <div class="col" style="max-width: 75%">
        <div class="card h-100">
            <picture style="min-height: 220px; border-bottom: 1px solid rgba(0, 0, 0, 0.175)">
                <img src="https://maxiprograma.com/assets/images/nivel-2.jpg" style="max-width: 100%; height:100%" />
            </picture>
            <div class="card-body">
                <h5 class="card-title">C# Nivel 2</h5>
                <p class="card-text text-success">$ 30.000</p>
<%--                <p class="card-text">Este curso es la continuación directa del Nivel 1, aunque también podés sumarte si ya contás con los fundamentos de programación en cualquier otro lenguaje. Acá comenzamos a construir apps vendibles.</p>--%>
            </div>
            <button type="button" class="btn btn-success w-50 mx-auto mb-3">
                <a href="Detalles.aspx?id=<%#Eval("Id")%>" class="w-100 btn btn-success">Obtener</a>
            </button>
        </div>
    </div>
    <div class="col" style="max-width: 75%">
        <div class="card h-100">
            <picture style="min-height: 220px; border-bottom: 1px solid rgba(0, 0, 0, 0.175)">
                <img src="https://maxiprograma.com/assets/images/nivel-3.jpg" style="max-width: 100%; height:100%" />
            </picture>
            <div class="card-body">
                <h5 class="card-title">C# Nivel 3</h5>
                <p class="card-text text-success">$ 30.000</p>
<%--                <p class="card-text">Arrancamos con la etapa Web. En este curso tomamos todo el conocimiento que venimos trabajando y lo ponemos al servicio del desarrollo web sumando herramientas como HTML, CSS, JS y Bootstrap.</p>--%>
            </div>
            <button type="button" class="btn btn-success w-50 mx-auto mb-3">
                <a href="Detalles.aspx?id=<%#Eval("Id")%>" class="w-100 btn btn-success">Obtener</a>
            </button>
        </div>
    </div>
</div>
</asp:Content>
