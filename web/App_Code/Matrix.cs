using System;
using System.Collections.Generic;

public class Matrix : IMatrix
{
    private Dictionary<int, Row> array = new Dictionary<int, Row>();
    private int index = 0;

    public Matrix()
    {
    }

    public Matrix(int size)
    {
        // throw new System.NotImplementedException();
    }


    public int AddRow(Row row)
    {
        //this.array[index] = row;
        this.array.Add(this.index, row);
        return index++;
    }

    public void SumRow(int sourceIndex, int destIndex)
    {
        throw new NotImplementedException();
    }

    public void SumRow(int sourceIndex, int destIndex, double factor)
    {
        throw new NotImplementedException();
    }

    public void MultiplyRow(int sourceIndex, double factor)
    {
        throw new NotImplementedException();
    }

    public void MultiplyRow(int sourceIndex, int destIndex, double factor)
    {
        throw new NotImplementedException();
    }

    public int RowCount
    {
        get { return this.array.Count; }
    }

    #region IMatrix Members

    public Row GetRow(int index)
    {
        return this.array[index];
    }

    #endregion
}