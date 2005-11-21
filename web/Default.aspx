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
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                Anzahl der Variablen<asp:TextBox ID="VariablesTextBox" runat="server" Width="70px">5</asp:TextBox><br />
                Anzahl der Basisvariablen<asp:TextBox ID="BaseVarsTextBox" runat="server" Width="52px">3</asp:TextBox><br />
                <asp:Button ID="Button2" runat="server" Text="Start" OnClick="Button2_Click" /></asp:View>
            <asp:View ID="View2" runat="server">
                <br />
            </asp:View>
            <asp:View ID="View3" runat="server">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            Pivot Zeile:
            <asp:TextBox ID="PivotRow" runat="server" Width="48px">1</asp:TextBox>Pivot Spalte:<asp:TextBox
                ID="PivotColumn" runat="server" Width="38px">1</asp:TextBox><br />
            <br />
            <asp:Panel ID="Panel1" runat="server" Height="228px" Width="431px">
            </asp:Panel>
        </asp:View>
        </asp:MultiView></div>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem Value="1">View 1</asp:ListItem>
            <asp:ListItem Value="2">View 2</asp:ListItem>
            <asp:ListItem Value="3">View 3</asp:ListItem>
        </asp:RadioButtonList>
    </form>
</body>
</html>
