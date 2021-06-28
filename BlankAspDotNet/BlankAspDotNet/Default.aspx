<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BlankAspDotNet.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnClick" runat="server" OnClick="btnClick_Click" Text="Invoke Service" />
            <asp:Label Text="" ID="lblText" runat="server" ForeColor="Red" Font-Bold="true" />
        </div>
    </form>
</body>
</html>
