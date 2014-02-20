<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="inBloom_2.header" %>

<div id="headerBars" >
    <div id="left" class="headerLabel" style="float:left">
        Hello, <asp:Label ID="userFullName" runat="server" Font-Bold="true"></asp:Label>
    </div>
    <div id="right" class="headerLabel" style="float:right">
        Roles: <asp:Label ID="userRole" runat="server" Text="" Font-Bold="true"></asp:Label>
    </div>
</div>