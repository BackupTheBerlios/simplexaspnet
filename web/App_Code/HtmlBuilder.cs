using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

public class HtmlBuilder : IHtmlBuilder
{
    private SimplexField field;
    private Table table;
    private bool showHeader = false;

    public bool ShowHeader
    {
        get { return showHeader; }
        set { showHeader = value; }
    }

    public  HtmlBuilder(SimplexField _matrix)
    {
        this.table= new Table();
        this.table.BorderStyle = BorderStyle.Solid;
        this.table.BorderWidth = 1;
        this.table.GridLines = GridLines.Both;
        this.field = _matrix;
    }



    public void Build(SimplexField _matrix)
    {
        throw new NotImplementedException();
    }

    public string GetHtml()
    {
        string tString = String.Empty;

        tString = "<table>" + Environment.NewLine;

        for (int i = 0; i < this.field.RowCount; i++)
        {
            Row row = this.field.GetRow(i);
            tString += "<tr>" + Environment.NewLine;
            for (int i2 = 0; i2 < row.Length; i2++)
            {
                tString += "<td>" + Environment.NewLine;
                tString += (row.Values[i2]).ToString() + Environment.NewLine;
                tString += "</td>" + Environment.NewLine;
            }
           
            tString += "</tr>" + Environment.NewLine;
        }

        tString += "</table>" + Environment.NewLine;

        return tString;
    }

    public Table GetTable()
    {
        if (this.ShowHeader == true)
        {
            TableRow trow = new TableRow();
            for (int i = 0; i < this.field.ColumnCount; i++)
            {
                TableCell cell = new TableCell();
                cell.Text = "x" + i.ToString();
                trow.Cells.Add(cell);
            }
            this.table.Rows.Add(trow);
        }

        for (int i = 0; i < this.field.RowCount; i++)
        {
            TableRow trow = new TableRow();
            Row row = this.field.GetRow(i);
            for (int i2 = 0; i2 < row.Length; i2++)
            {
                TableCell cell = new TableCell();
                cell.Text = (row.Values[i2]).ToString();

                if (i == this.field.PivotRow || i2 == this.field.PivotColumn)
                    cell.BackColor = Color.Red;

                trow.Cells.Add(cell);
            }
            this.table.Rows.Add(trow);
        }

        return this.table;

    }

 

}
