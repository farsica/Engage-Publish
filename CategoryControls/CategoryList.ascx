<%@ Control Language="c#" AutoEventWireup="false" Inherits="Engage.Dnn.Publish.CategoryControls.CategoryList" Codebehind="CategoryList.ascx.cs" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/labelControl.ascx" %>

<table border="0" class="normal">
    <tr valign="top">
        <td><dnn:Label ID="Label1" ResourceKey="lblItemType" Runat="server" CssClass="Normal" ControlName="cboItemType"></dnn:Label></td>
        <td><asp:DropDownList ID="cboItemType" Runat="server" AutoPostBack="True" CssClass="Normal"></asp:DropDownList></td>
        <td><dnn:Label ID="lblWorkflow" ResourceKey="lblWorkFlow" Runat="server" CssClass="Normal" ControlName="cboWorkFlow"></dnn:Label></td>
        <td><asp:DropDownList ID="cboWorkflow" Runat="server" AutoPostBack="True" CssClass="Normal"></asp:DropDownList></td>
    </tr>
</table>
<asp:label id="lblMessage" runat="server" CssClass="Subhead"></asp:label>
<br />
<div>
    <asp:placeholder id="phList" runat="server"></asp:placeholder>
</div>
<asp:hyperlink id="lnkAddNewCategory" Runat="server" ResourceKey="lnkAddNewCategory" CssClass="CommandButton"></asp:hyperlink>

