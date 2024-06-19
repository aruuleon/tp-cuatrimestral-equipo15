<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdministratorHome.aspx.cs" Inherits="tp_cuatrimestral_equipo15.AdministratorHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="carouselExampleAutoplaying" class="carousel slide" data-bs-ride="carousel" style="width: 100%; height:500px">
        <img src="https://maxiprograma.com/assets/images/maxi-programa-banner.jpg" style="width: 100%; height:500px" />
    </div>
    <div class="p-3" style="width: 50%; margin-left: 10%; margin-bottom: 10px">
        <div class="p-2 mb-4" style="border-left: 2px solid #7b1fa2">
            <h1>Panel de control</h1>
        </div>
    </div>
    <div class="row row-cols-1 row-cols-md-4 g-4 m-5 mx-auto w-75 d-flex justify-content-center">
        <asp:Repeater runat="server" id="sectionControlPanelList">
            <ItemTemplate>
                <div class="col" style="max-width: 75%">
                    <asp:HyperLink ID="HyperLinkSection" runat="server" NavigateUrl='<%#Eval("WebForm")%>' CssClass="text-decoration-none color-inherit">
                        <div class="card h-100">
                            <div style="min-height: 220px; border-bottom: 1px solid rgba(0, 0, 0, 0.175); display: flex; align-items: center; justify-content: center;">
                                <i class="<%#Eval("Icon")%>" style="font-size: 8em;"></i>
                            </div>
                            <div class="card-body">
                                <h5 class="card-title text-center"><%#Eval("Name")%></h5>
                            </div>
                        </div>
                    </asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
