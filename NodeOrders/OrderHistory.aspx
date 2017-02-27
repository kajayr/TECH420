<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="NodeOrders.OrderHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Order History Form</h3>
    <asp:Label runat="server" Font-Bold="True" Font-Overline="False" ID="lblStatus"></asp:Label>
    <br/>
      <br/>
    <asp:Repeater ID="rptrOrders" runat="server">
          <ItemTemplate>
               Id : <strong style="color: black;"><%#Eval("Id") %></strong> &nbsp;&nbsp; &nbsp;&nbsp; Name: <strong style="color: black;"><%#Eval("Name") %></strong>&nbsp;&nbsp; &nbsp;&nbsp; Phone: <strong style="color: black;"><%#Eval("PhoneNumber") %></strong>
              CreditCard: <strong style="color: black;"><%#Eval("CreditCard") %></strong> &nbsp;&nbsp; &nbsp;&nbsp; Price: <strong style="color: black;"><%#Eval("Price", "{0:C}") %></strong>
            </ItemTemplate>
        <SeparatorTemplate>
            <hr/>
        </SeparatorTemplate>
    </asp:Repeater>

    <br />
    <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear  Order History" />
</asp:Content>
