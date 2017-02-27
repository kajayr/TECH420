<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="BuyCD.aspx.cs" Inherits="NodeOrders.BuyCD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h2 style="margin-left: 40px"> There are the CDs that we are currently offering.</h2>

    <div class="movieInfo">

        <asp:DataList ID="CdDataList" runat="server" OnItemCommand="CdDataList_ItemCommand" OnSelectedIndexChanged="CdDataList_SelectedIndexChanged">
            <ItemTemplate>
                Part Number: <strong style="color: black;"><%#Eval("CdID") %></strong> &nbsp;&nbsp; &nbsp;&nbsp; Title: <strong style="color: black;"><%#Eval("CDname") %></strong><br/>
                Artist: <strong style="color: black;"><%#Eval("artist") %></strong> &nbsp;&nbsp; &nbsp;&nbsp; Price: <strong style="color: black;"><%#Eval("ListPrice", "{0:C}") %></strong>&nbsp;&nbsp;
                <asp:LinkButton ID="detailsButton" runat="server" Text="Buy"
                                CssClass="LinkButton" CommandName="Buy"
                                CommandArgument=<%# Eval("CdID") + " " + Eval("ListPrice") %>/>
            </ItemTemplate>
            <SeparatorTemplate>
                <hr/>
            </SeparatorTemplate>

        </asp:DataList>
    </div>

    <p>
        Name <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        &nbsp;&nbsp; Credit Card #
        <asp:TextBox ID="TextBoxCC" runat="server" Width="175px">1234 5678 1234 5678</asp:TextBox>
        &nbsp;&nbsp;
        Phone # <asp:TextBox ID="TextBoxPhone" runat="server">555 555 5555</asp:TextBox>
    </p>
    <p>
        <asp:Label ID="LabelResults" runat="server" Text="Status" ForeColor="#CC00CC" Font-Size="X-Large"></asp:Label>
    </p>
</asp:Content>