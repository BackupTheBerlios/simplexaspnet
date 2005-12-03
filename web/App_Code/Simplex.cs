using System;

public class Simplex : ISimplex
{
    private SimplexField field;

    public Simplex()
    {
    }

    /// <summary>
    /// Initializes the SimplexField
    /// </summary>
    /// <param name="field"></param>
    public Simplex(SimplexField field)
    {
        this.Field = field;
    }

    public SimplexField Field
    {
        get { return this.field; }
        set { this.field = value; }
    }

    /// <summary>
    /// finds the pivot column
    /// </summary>
    /// <returns>the index of the column</returns>
    public int FindPivotColumn()
    {
        Row _row = this.field.GetRow(0);

        double[] a = _row.Values;
        double biggest = 0;
        int index = 0;

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
    /// finds the pivot row
    /// </summary>
    /// <returns></returns>
    public int FindPivotRow()
    {
        double smallest = Double.PositiveInfinity;
        int index = 0;
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
    /// redefines the pivot column to bv
    /// </summary>
    public void RedefineField()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// start the simplex algorithm
    /// </summary>
    public void Start()
    {
        throw new NotImplementedException();
    }


    public void NextSetp()
    {
        this.SetPivotElement();
        this.Transform();
    }

    public void SetPivotElement()
    {
        this.field.PivotColumn = this.FindPivotColumn();
        this.field.PivotRow = this.FindPivotRow();
    }

    /// <summary>
    /// transforms the simplex field
    /// </summary>
    private void Transform()
    {
        this.TransformPivotRow();
        for (int i = 0; i < this.field.RowCount; i++)
        {
            if (i != this.field.PivotRow)
            {
                this.TransformRow(i);
            }
        }
    }

    private void TransformRow(int destRowIndex)
    {
        double valueInPivotRow = this.field.GetRow(this.field.PivotRow).Values[this.field.PivotColumn];
        double valueInDestRow = this.field.GetRow(destRowIndex).Values[this.field.PivotColumn];
        double factor = -(valueInDestRow/valueInPivotRow);

        this.field.SumRow(this.field.PivotRow, destRowIndex, factor);
    }

    private void TransformPivotRow()
    {
        this.field.MultiplyRow(this.field.PivotRow,
                               1/this.field.GetRow(this.field.PivotRow).Values[this.field.PivotColumn]);
    }

    public double DivideRowForPivot(int rowIndex)
    {
        double n = this.field.GetRow(rowIndex).Values[this.field.PivotColumn];
        double z = this.field.GetRow(rowIndex).Values[this.field.ColumnCount - 1];
        return z/n;
    }

    #region ISimplex Members

    int ISimplex.FindPivotColumn()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    #endregion
}