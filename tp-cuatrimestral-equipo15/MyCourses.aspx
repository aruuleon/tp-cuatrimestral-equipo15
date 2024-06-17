﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MyCourses.aspx.cs" Inherits="tp_cuatrimestral_equipo15.MyCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="p-2 mb-4" style="border-left: 2px solid #7b1fa2">
        <h1>Tu lista de Cursos</h1>
    </div>
    <div class="row row-cols-1 row-cols-md-4 g-4 m-5 mx-auto w-75">
        <asp:Repeater runat="server" id="listaCursos">
            <ItemTemplate>
                <div class="col" style="max-width: 75%">
                    <asp:HyperLink ID="HyperLinkCourseDetail" runat="server" NavigateUrl='<%# "DetallesCurso.aspx?id=" + Eval("ID") %>' CssClass="text-decoration-none color-inherit">
                        <div class="card h-100">
                            <picture style="min-height: 220px; border-bottom: 1px solid rgba(0, 0, 0, 0.175)">
                                <asp:Image runat="server" ImageUrl='<%#Eval("ImagenPortada")%>' Style="max-width: 100%; height:100%" />
                            </picture>
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre")%></h5>
                                <p class="card-text" style="font-size: 14px"><%#Eval("Resumen")%></p>
                                <p class="card-text text-success fw-bold">$ <%# String.Format(new System.Globalization.CultureInfo("es-AR"), "{0:N0}", Eval("Precio")) %></p>
                            </div>
                        </div>
                    </asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
