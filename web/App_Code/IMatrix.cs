using System;
public interface IMatrix
{
    int RowCount
    {
        get;
    }

    int AddRow(Row row);

    void SumRow(int sourceIndex, int destIndex);

    void SumRow(int sourceIndex, int destIndex, double factor);

    void MultiplyRow(int sourceIndex, double factor);

    void MultiplyRow(int sourceIndex, int destIndex, double factor);

    Row GetRow(int index);
    
    
}
