﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetallesCurso.aspx.cs" Inherits="tp_cuatrimestral_equipo15.DetallesCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

  <div class="container py-4">
    

    <div class="p-5 mb-4  rounded-3" style="background-color:#7b1fa2;">
      <div class="container-fluid py-5" >
        <h1 class="display-5 fw-bold" style="color:white">C# Nivel 3 (Web ASP)</h1>
        
          <asp:Button ID="btnComprarFinal" runat="server" CssClass="btn btn-primary btn-lg" Text="Comprar $30.000"/>
      </div>
    </div>

    <div class="row align-items-md-stretch">
      <div class="col-md-6">
        <div class="h-100 p-5 rounded-3" style="background-color:#198754;">
          <h2 style="color:white">Descripcion</h2>
          <p style="color:white">
              En este curso nos embarcamos en el desarrollo de aplicaciones Web y claro, lo haremos con C# y el Framework 
              .NET. Pero antes de ello, necesitamos conocer los fundamentos de la Web, su arquitectura y veremos una introducción 
              a los lenguajes que la representan: HTML, CSS y JS. .NET propone varios caminos para la construcción de aplicaciones Web.
              En este curso veremos la primera de ellas que es WebForms: una continuación directa, si se quiere, del esquema de WinForms
              que vemos en el Nivel 2, lo que nos permitirá adaptarnos rápidamente a las formas; aunque tienen sus particularidades,
              de las que ya charlaremos...
          </p>
        </div>

      </div>
      <div class="col-md-6">
        <div class="h-100 p-5 rounded-3" style="border:dashed; border-color:#7b1fa2">
          <h2>Conocimientos requeridos</h2>
          <p>Para poder aprovechar este curso al máximo es necesario que cuentes con una base
                sólida en fundamentos de la programación, que conozcas el paradigma de
                Programación Orientada a Objetos y que al menos tengas nociones sobre .NET (o algún
                otro Framework). Los conocimientos necesarios los vemos en los Niveles 1 y 2, aunque
                vos podés tenerlos de otro lado, claro.
          </p>
          <asp:Button ID="btnPrograma" runat="server" CssClass="btn btn-outline-light" style="background-color:#7b1fa2" Text="Descargar Programa"/> 
        </div>
      </div>
    </div>

    
  </div>

</asp:Content>