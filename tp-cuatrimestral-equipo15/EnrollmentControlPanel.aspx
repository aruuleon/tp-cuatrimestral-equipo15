<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EnrollmentControlPanel.aspx.cs" Inherits="tp_cuatrimestral_equipo15.EnrollmentControlPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="p-3" style="width: 50%; margin-left: 10%; margin-bottom: 10px">
        <div class="p-2 mb-4" style="border-left: 2px solid #7b1fa2">
            <h1>Inscripciones</h1>
        </div>
    </div>
    <div class="m-5 mx-auto w-75 d-flex justify-content-center">
        <table class="table table-bordered">
            <thead class="table-dark">
                <tr class="text-center">
                    <asp:Repeater runat="server" id="columnList">
                        <ItemTemplate>
                            <th scope="col"><%# Container.DataItem %></th>
                        </ItemTemplate>
                    </asp:Repeater>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" id="enrollmentList">
                    <ItemTemplate>
                        <tr class="align-middle text-center">
                            <td><%#Eval("EnrollmentID")%></td>
                            <td class="text-start"><%#Eval("Course")%></td>
                            <td class="text-start"><%#Eval("User")%></td>
                            <td><%# Eval("EnrollmentDate", "{0:dd/MM/yyyy}") %></td>
                            <td><%# String.Format(new System.Globalization.CultureInfo("es-AR"), "{0:C0}", Convert.ToInt32(Eval("Price"))) %></td>
                            <td><asp:HyperLink ID="HyperLinkVoucher" NavigateUrl='#' runat="server" CssClass="fa fa-file text-primary" Target="_blank"></asp:HyperLink></td>
                            <td class="text-center d-flex justify-content-around align-items-center">
                                <div>
                                    <asp:LinkButton ID="LinkButtonApproved" runat="server" CommandArgument='<%# Eval("EnrollmentID") + "|" + Eval("UserID") + "|" + Eval("CourseID") %>' CommandName="APPROVED" OnCommand="LinkButton_Command" CssClass="fas fa-check text-success" style="text-decoration: none;"></asp:LinkButton>
                                </div>
                                <div>
                                    <asp:LinkButton ID="LinkButtonRefused" runat="server" CommandArgument='<%# Eval("EnrollmentID") + "|" + Eval("UserID") + "|" + Eval("CourseID") %>'  CommandName="REFUSED" OnCommand="LinkButton_Command" CssClass="fas fa-times text-danger" style="text-decoration: none;"></asp:LinkButton>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
