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
        double biggest = a[0];
        int index = 0;
        for (int i = 0; i <= _row.Length - 1; i++)
        {
            if (biggest < a[i + 1])
            {
                biggest = a[i + 1];
                index = i + 1;
                i++;
            }
            else
                i++;
        }
        return index;
    }

    /// <summary>
    /// finds the pivot row
    /// </summary>
    /// <returns></returns>
    public int FindPivotRow()
    {
        double smallest = 0;
        int index = 0; ;
        for (int i=1;i<this.field.RowCount;i++)
        {
            if (smallest == 0)
            {
                smallest = DivideRowForPivot(i);
                index = i;
            }
            else
            {
                double newsmallest = DivideRowForPivot(i);
                if (newsmallest < smallest)
                {
                    smallest = newsmallest;
                }
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
        this.FindPivotColumn();
        this.FindPivotRow();
        this.Transform();
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

    private void TransformRow(int i)
    {
        this.field.SumRow(this.field.PivotRow,i,1/this.field.GetRow(i).Values[this.field.PivotColumn]);
    }

    private void TransformPivotRow()
    {
        this.field.MultiplyRow(this.field.PivotRow, this.field.GetRow(this.field.PivotRow).Values[this.field.PivotColumn]);       
    }

    public double DivideRowForPivot(int rowIndex)
    {
        double z=this.field.GetRow(rowIndex).Values[this.field.PivotColumn];
        double n=this.field.GetRow(rowIndex).Values[this.field.ColumnCount-1];
        return z/n;
    }

    #region ISimplex Members


    int ISimplex.FindPivotColumn()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    #endregion
}