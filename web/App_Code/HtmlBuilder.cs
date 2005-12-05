using System;
using System.Drawing;
using System.Web.UI.WebControls;

public class HtmlBuilder : IHtmlBuilder
{
    private SimplexField field;
    private Table table;

    private bool showColumnHeader = false;
    private bool showRowHeader = false;
    private Color foreColor = Color.Red;

    /// <summary>
    /// Legt fest ob der Zeilen-Header angezeigt werden soll
    /// </summary>
    public bool ShowRowHeader
    {
        get { return this.showRowHeader; }
        set { this.showRowHeader = value; }
    }

    /// <summary>
    /// Setzt und liest die Farbe für die Pivot-Spalte und -Reihe
    /// </summary>
    public Color ForeColor
    {
        get { return this.foreColor; }
        set { this.foreColor = value; }
    }
    
    /// <summary>
    /// Legt fest ob der Spalten-Header angezeigt werden soll
    /// </summary>
    public bool ShowColumnHeader
    {
        get { return this.showColumnHeader; }
        set { this.showColumnHeader = value; }
    }

    /// <summary>
    /// Inititalisiert den HtmlBuilder
    /// </summary>
    /// <param name="_matrix">Das SimplexFeld für das HtmlCode erzeugt werden soll</param>
    public HtmlBuilder(SimplexField _matrix)
    {
        this.table = new Table();
        this.table.BorderStyle = BorderStyle.Solid;
        this.table.BorderWidth = 1;
        this.table.GridLines = GridLines.Both;
        this.field = _matrix;
    }

    /// <summary>
    /// Erstellt ein Html-Darstellung für ein SimplexFeld
    /// </summary>
    /// <returns>HTML table</returns>
    public Table GetTable()
    {
        //Spalten-Header anzeigen?
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

        
        //Tabelle aufbauen
        for (int i = 0; i < this.field.RowCount; i++)
        {
            TableRow trow = new TableRow();

            //Zeilenheader anzeigen?
            if (this.ShowRowHeader == true)
            {
                TableCell cell = new TableCell();
                cell.Text = "x" + i.ToString();
                if (i == this.field.PivotRow)
                    cell.BackColor = this.ForeColor;
                trow.Cells.Add(cell);
            }

            //Zeile aus SimplexFeld holen
            Row row = this.field.GetRow(i);
            for (int i2 = 0; i2 < row.Length; i2++)
            {
                //Html-Zelle den Wert aus dem SimplexFeld zuweisen
                TableCell cell = new TableCell();
                cell.Text = (row.Values[i2]).ToString();

                //Falls Pivot-Zeile oder -Splate einfärben
                if (i == this.field.PivotRow || i2 == this.field.PivotColumn)
                    cell.BackColor = this.ForeColor;

                trow.Cells.Add(cell);
            }
            this.table.Rows.Add(trow);
        }
        return this.table;
    }
}