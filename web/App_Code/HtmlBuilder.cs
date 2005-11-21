using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class HtmlBuilder : IHtmlBuilder
{
    IMatrix matrix;
    Table table;

    public  HtmlBuilder(IMatrix _matrix)
    {
        this.table= new Table();
        this.table.BorderStyle = BorderStyle.Solid;
        this.table.BorderWidth = 1;
        this.table.GridLines = GridLines.Both;
        this.matrix = _matrix;
    }

    public void Build(IMatrix _matrix)
    {
        throw new NotImplementedException();
    }

    public string GetHtml()
    {
        string tString = String.Empty;

        tString = "<table>" + Environment.NewLine;

        for (int i = 0; i < this.matrix.RowCount; i++)
        {
            Row row = this.matrix.GetRow(i);
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
        for (int i = 0; i < this.matrix.RowCount; i++)
        {
            TableRow trow = new TableRow();
            Row row = this.matrix.GetRow(i);
            for (int i2 = 0; i2 < row.Length; i2++)
            {
                TableCell cell = new TableCell();
                cell.Text = (row.Values[i2]).ToString();
                trow.Cells.Add(cell);
            }
            this.table.Rows.Add(trow);
        }

        return this.table;

    }

 

}
