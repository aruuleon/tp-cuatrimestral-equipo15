<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetallesCurso.aspx.cs" Inherits="tp_cuatrimestral_equipo15.DetallesCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style="height: 600px; background-image: url('https://maxiprograma.com/assets/images/nivel-3.jpg'); background-size: cover; background-position: center;"></div>
    <div class="d-flex p-3 ml-4" style="width: 100%; margin-left: 10%; margin-top: 30px">
        <div style="width: 50%">
            <div class="p-2 mb-4" style="border-left: 2px solid #7b1fa2">
                <h1>C# Nivel 3 (Web ASP)</h1>
            </div>
            <p>
                La programación es una de las disciplinas con la demanda de mayor crecimiento en los
                últimos años. Se encuentra presente en cada vez más aspectos tanto laborales, como
                en la enseñanza, y hasta en la vida cotidiana (internet of things). 
            </p>
            <p>
                En este curso
                aprenderemos a programar completamente desde cero; desde qué es un programa o
                qué es programar en realidad, hasta crear simples y complejos algoritmos con distintas
                herramientas propias de la programación. Que qué es un algoritmo? También lo
                veremos.
            </p>
        </div>
        <div class="col" style="max-width: 20%; position:absolute; right: 10%">
            <div class="card h-100">
                <picture style="min-height: 200px; border-bottom: 1px solid rgba(0, 0, 0, 0.175)">
                    <img src="https://maxiprograma.com/assets/images/nivel-3.jpg" style="max-width: 100%; height:200px" />
                </picture>
                <div class="card-body mb-4">
                    <h5 class="card-title">C# Nivel 3 (Web ASP)</h5>
                    <p class="card-text text-success">$ 30.000</p>
                </div>
                <asp:HyperLink ID="HyperLinkBuy" runat="server" NavigateUrl="#" CssClass="btn btn-success w-50 mx-auto mb-3">Obtener</asp:HyperLink>
            </div>
        </div>
    </div>
    <div class="p-3" style="width: 50%; margin-left: 10%">
        <div class="p-2 mb-4" style="border-left: 2px solid #7b1fa2">
            <h1> Conocimientos requeridos </h1>
        </div>
        <span>Conocimientos básicos de manejo de PC.</span><br />
        <span>Contar con equipo de PC con acceso a Internet.</span><br />
        <span>No se requiere ningún conocimiento previo de programación.</span>
    </div>
    <div class="p-3" style="width: 50%; margin-left: 10%">
        <div class="p-2 mb-4" style="border-left: 2px solid #7b1fa2">
            <h1> Certificación </h1>
        </div>
        <span>Certificado [maxiprograma.com] de aprobación del curso.</span><br />
        <span>El certificado de aprobación del curso estará atado a la entrega y aprobación de las actividades correspondientes.</span>
    </div>
    <div class="p-3" style="width: 50%; margin-left: 10%">
        <div class="p-2 mb-4" style="border-left: 2px solid #7b1fa2">
            <h1> Docente </h1>
        </div>
        <p>
            Maximiliano Sar Fernández. Licenciado en Tecnología Educativa, Universidad Tecnológica
            Nacional Facultad Regional Buenos Aires, UTN FRBA.
            Técnico Superior en Programación y Técnico Superior en Sistemas Informáticos, Universidad
            Tecnológica Nacional Facultad Regional General Pacheco, UTN FRGP.
        </p>
        <p>
            Cuenta con más de diez años de experiencia en docencia universitaria, donde dicta materias
            relacionadas a la programación tanto para iniciantes con el paradigma estructurado como para
            avanzados bajo el paradigma orientado a objetos y diferentes frameworks, tecnologías y
            arquitecturas.
        </p>
        <p>
            Posee más de doce años de experiencia tanto en corporaciones como de manera freelance
            trabajando para empresas de gran envergadura cumpliendo distintos roles tales como
            desarrollador, analista funcional, líder de equipo, capacitador, consultor.
        </p>
        <p>
            Maximiliano es creador de contenido y divulgador de temas relacionados con la programación y
            la tecnología por medio de sus canales en YouTube e Instagram donde lo encuentran como
            “Maxi Programa”.
        </p>
    </div>
</asp:Content>
