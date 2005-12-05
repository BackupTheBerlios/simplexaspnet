using System;

public class Simplex : ISimplex
{
    private SimplexField field;

    public Simplex()
    {
    }

    /// <summary>
    /// Konstruktor
    /// Initialisiert die interne Membervariable field
    /// </summary>
    /// <param name="field">Feld auf das der Simplex angewendet werden soll</param>
    public Simplex(SimplexField field)
    {
        this.Field = field;
    }

    /// <summary>
    /// Property zum lesen und setzen des Feldes
    /// </summary>
    public SimplexField Field
    {
        get { return this.field; }
        set { this.field = value; }
    }

    /// <summary>
    /// Sucht die Pivot-Spalte
    /// </summary>
    /// <returns>Index der Pivot-Spalte</returns>
    public int FindPivotColumn()
    {
        Row _row = this.field.GetRow(0);

        double[] a = _row.Values;
        double biggest = 0;
        int index = 0;

        //größten Wert in der Zielfunktion suchen 
        for (int i = 0; i < (_row.Length - 1); i++)
        {
            if (a[i] >= 0 && a[i] >= biggest)
            {
                biggest = a[i];
                index = i;
            }
        }
        return index;
    }

    /// <summary>
    /// Sucht die Pivot-Zeile
    /// </summary>
    /// <returns>Index der Pivot-Zeile</returns>
    public int FindPivotRow()
    {
        double smallest = Double.PositiveInfinity;
        int index = 0;

        //Sucht die Spalte mit dem kleinsten Quotienten
        for (int i = 1; i < this.field.RowCount; i++)
        {
            double newsmallest = DivideRowForPivot(i);
            if (newsmallest <= smallest && newsmallest > 0)
            {
                smallest = newsmallest;
                index = i;
            }
        }
        return index;
    }

    /// <summary>
    /// Führt einen weiteren Schritt (eine weitere Umformung) durch
    /// </summary>
    public void NextStep()
    {
        this.SetPivotElement();
        this.Transform();
    }

    /// <summary>
    /// Sucht Pivot-Spalte und Pivot-Zeile
    /// </summary>
    public void SetPivotElement()
    {
        this.field.PivotColumn = this.FindPivotColumn();
        this.field.PivotRow = this.FindPivotRow();
    }

    /// <summary>
    /// Überprüft ob der Simplex fertig ist, oder noch weitere Schritte durchgeführt werden müssen
    /// </summary>
    /// <returns>true, falls fertig</returns>
    public bool isComplete()
    {
        bool returnValue = true;
        int rowCount = this.field.RowCount;

        for (int y = 1; y < rowCount; y++)
        {
            for (int x = 0; x < rowCount-1; x++)
            {
                if ((x == (rowCount - y-1) && this.field.GetRow(y).Values[x] != 1) ||
                    (x != (rowCount - y-1) && this.field.GetRow(y).Values[x] != 0))
                {
                    returnValue = false;
                    break;
                }
            }
            if (returnValue == false)
                break;
        }
        return returnValue;
    }

    /// <summary>
    /// Transformiert das Feld
    /// </summary>
    private void Transform()
    {
        //Transformiert die Pivot-Zeile so, dass im Pivotelemt eine 1 steht
        this.TransformPivotRow();
        for (int i = 0; i < this.field.RowCount; i++)
        {
            if (i != this.field.PivotRow)
            {
                //Transformiert eine Zeile so, dass in der Pivot-Spalte eine 0 steht
                this.TransformRow(i);
            }
        }
    }

    /// <summary>
    /// Transformiert eine Zeile so, dass in der Pivot-Spalte eine 0 steht
    /// </summary>
    /// <param name="destRowIndex">Index der zu tranformierenden Zeile</param>
    private void TransformRow(int destRowIndex)
    {
        double valueInPivotRow = this.field.GetRow(this.field.PivotRow).Values[this.field.PivotColumn];
        double valueInDestRow = this.field.GetRow(destRowIndex).Values[this.field.PivotColumn];
        double factor = -(valueInDestRow/valueInPivotRow);

        this.field.SumRow(this.field.PivotRow, destRowIndex, factor);
    }

    /// <summary>
    /// Transformiert die Pivot-Zeile so, dass im Pivotelemt eine 1 steht
    /// </summary>
    private void TransformPivotRow()
    {
        this.field.MultiplyRow(this.field.PivotRow,
                               1/this.field.GetRow(this.field.PivotRow).Values[this.field.PivotColumn]);
    }

    /// <summary>
    /// Berechnet in einer Zeile den Quotienten aus dem Element in der Pivot-Spalte und dem
    /// Element in der letzten Splate
    /// </summary>
    /// <param name="rowIndex"></param>
    /// <returns></returns>
    public double DivideRowForPivot(int rowIndex)
    {
        double n = this.field.GetRow(rowIndex).Values[this.field.PivotColumn];
        double z = this.field.GetRow(rowIndex).Values[this.field.ColumnCount - 1];
        return z/n;
    }
}