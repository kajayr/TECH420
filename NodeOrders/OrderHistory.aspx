<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="NodeOrders.OrderHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Order History Form</h3>
    <asp:Label runat="server" Font-Bold="True" Font-Overline="False" ID="lblStatus"></asp:Label>
    <asp:Repeater ID="rptrOrders" runat="server"></asp:Repeater>
    
    <br />
    <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear  Order History" />
</asp:Content>
