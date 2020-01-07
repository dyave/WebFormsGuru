<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Guru99Control.ascx.cs" Inherits="WebFormsGuru.Guru99Control" %>

<script runat="server">
    public int MinValue = 5;
</script>

<div style="border: solid pink 1px;">
    <table>
        <tr>
            <td>This is coming from .ascx (user control)</td>
        </tr>
        <tr>
            <td>Passed value: <% Response.Write(MinValue.ToString());%> | <%=MinValue%></td>
        </tr>
    </table>
</div>


