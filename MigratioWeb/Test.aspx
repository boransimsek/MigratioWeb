<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="MigratioWeb.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />


    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="text" id="txtMessage">
            <button id="btnTest" onclick="getMessage()">Test</button>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>

    <script type="text/javascript">
        function getMessage() {
            var res = AjaxTest.GetMessage();
            $("#txtMessage").val(res.value);
            return false;
        }
    </script>
</body>
</html>
