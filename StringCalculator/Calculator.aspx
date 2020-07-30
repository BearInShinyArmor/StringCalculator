<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="StringCalculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <p>Введите выражение:
            <asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="906px"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="Рассчитать" OnClick="Button1_Click" />
        </p>
        Результат:<asp:TextBox ID="TextBox2" runat="server" Enabled="False" Width="342px"></asp:TextBox>
    </form>
    
</body>
</html>
