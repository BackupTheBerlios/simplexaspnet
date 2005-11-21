<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="javascript" type="text/javascript">
<!--

function DIV1_onclick() {

}

// -->
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;
        <div id="DIV1" style="z-index: 101; left: 107px; width: 485px; position: absolute;
            top: 90px; height: 269px" language="javascript" onclick="return DIV1_onclick()">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" Height="228px" Width="431px">
            </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>
