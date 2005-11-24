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
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Reset" />
        <asp:Label ID="lblResult" runat="server" Text="Label" Width="154px"></asp:Label>
        <asp:Label ID="lblText" runat="server" Text="Label" Width="260px"></asp:Label>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                Anzahl der Variablen<asp:TextBox ID="VariablesTextBox" runat="server" Width="70px">4</asp:TextBox><br />
                Anzahl der Basisvariablen<asp:TextBox ID="BaseVarsTextBox" runat="server" Width="52px">2</asp:TextBox><br />
                <asp:Button ID="Button2" runat="server" Text="Start" OnClick="GenerateTextboxes" /></asp:View>
            <asp:View ID="View2" runat="server">
                &nbsp;
                <br />
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Feld erstellen" /></asp:View>
            <asp:View ID="View3" runat="server">
            <asp:Button ID="Button1" runat="server"  Text="Button" OnClick="Button1_Click" />
            Pivot Zeile:
            <asp:TextBox ID="PivotRow" runat="server" Width="48px">1</asp:TextBox>Pivot Spalte:<asp:TextBox
                ID="PivotColumn" runat="server" Width="38px">1</asp:TextBox>
                <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Next step" /><br />
            <br />
            <asp:Panel ID="Panel1" runat="server" Height="228px" Width="431px">
            </asp:Panel>
        </asp:View>
        </asp:MultiView></div>
    </form>
</body>
</html>
