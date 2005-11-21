using System;
using System.Drawing;
using System.Web.UI.WebControls;

public class HtmlBuilder : IHtmlBuilder
{
    private SimplexField field;
    private Table table;

    private bool showColumnHeader = false;
    private bool showRowHeader = false;

    public bool ShowRowHeader
    {
        get { return this.showRowHeader; }
        set { this.showRowHeader = value; }
    }

    private Color foreColor = Color.Red;

    public Color ForeColor
    {
        get { return this.foreColor; }
        set { this.foreColor = value; }
    }

    public bool ShowColumnHeader
    {
        get { return this.showColumnHeader; }
        set { this.showColumnHeader = value; }
    }

    public HtmlBuilder(SimplexField _matrix)
    {
        this.table = new Table();
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

        //tString = "<table>" + Environment.NewLine;

        //for (int i = 0; i < this.field.RowCount; i++)
        //{
        //    Row row = this.field.GetRow(i);
        //    tString += "<tr>" + Environment.NewLine;
        //    for (int i2 = 0; i2 < row.Length; i2++)
        //    {
        //        tString += "<td>" + Environment.NewLine;
        //        tString += (row.Values[i2]).ToString() + Environment.NewLine;
        //        tString += "</td>" + Environment.NewLine;
        //    }

        //    tString += "</tr>" + Environment.NewLine;
        //}

        //tString += "</table>" + Environment.NewLine;

        return tString;
    }

    /// <summary>
    /// Creates a HTML table from a SimplexField
    /// </summary>
    /// <returns>HTML table</returns>
    public Table GetTable()
    {
        if (this.ShowColumnHeader == true)
        {
            TableRow trow = new TableRow();

            if (this.ShowRowHeader == true)
            {
                TableCell cell = new TableCell();
                cell.Text = "";
                trow.Cells.Add(cell);
            }

            for (int i = 0; i < this.field.ColumnCount; i++)
            {
                TableCell cell = new TableCell();
                cell.Text = "x" + i.ToString();
                if (i == this.field.PivotColumn)
                    cell.BackColor = this.ForeColor;
                trow.Cells.Add(cell);
            }
            this.table.Rows.Add(trow);
        }

        for (int i = 0; i < this.field.RowCount; i++)
        {
            TableRow trow = new TableRow();

            if (this.ShowRowHeader == true)
            {
                TableCell cell = new TableCell();
                cell.Text = "x" + i.ToString();
                if (i == this.field.PivotRow)
                    cell.BackColor = this.ForeColor;
                trow.Cells.Add(cell);
            }

            Row row = this.field.GetRow(i);
            for (int i2 = 0; i2 < row.Length; i2++)
            {
                TableCell cell = new TableCell();
                cell.Text = (row.Values[i2]).ToString();

                if (i == this.field.PivotRow || i2 == this.field.PivotColumn)
                    cell.BackColor = this.ForeColor;

                trow.Cells.Add(cell);
            }
            this.table.Rows.Add(trow);
        }

        return this.table;
    }
}