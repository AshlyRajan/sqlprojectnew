<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminhome.aspx.cs" Inherits="sqlprojectnew.adminhome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 32px;
        }
        .auto-style2 {
            height: 32px;
            width: 384px;
        }
        .auto-style3 {
            width: 384px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style2"></td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td>ADD CATEGORY</td>
            <td>ADD PRODUCT</td>
            <td class="auto-style3">FEEDBACK</td>
            <td>View Bill</td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="121px" ImageUrl="~/category.jpg" PostBackUrl="addcategory.aspx" Width="169px" />
            </td>
            <td>
                <asp:ImageButton ID="ImageButton2" runat="server" Height="149px" ImageUrl="~/order.png" PostBackUrl="~/addorder.aspx" Width="188px" />
            </td>
            <td class="auto-style3">
                <asp:ImageButton ID="ImageButton3" runat="server" Height="136px" ImageUrl="~/feedback.png" Width="121px" PostBackUrl="replyfeedback.aspx" />
            </td>
            <td>
                <asp:ImageButton ID="ImageButton4" runat="server" Height="117px" ImageUrl="~/bill.jpg" Width="122px" PostBackUrl="adminbill.aspx" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        </table>
</asp:Content>
