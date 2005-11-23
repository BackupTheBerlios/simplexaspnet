using System;
using System.Collections.Generic;

public class Matrix : IMatrix
{
    private Dictionary<int, Row> array;
    private int index = 0;

   /// <summary>
   /// Constructor
   /// </summary>
    public Matrix()
    {
        array = new Dictionary<int, Row>();
            
    }

    /// <summary>
    /// Creates a new Row
    /// </summary>
    /// <param name="row"></param>
    /// <returns></returns>
    /*public int AddRow(Row row)
    {
        //this.array[index] = row;
     //   this._array.Add(this.index, row);
        return index++;
    }*/
    /*public int AddRow()
    {
        //this.array.Add(index, row);
        //return index++;
    }
    */
    public int AddRow(Row _row)
    {
        this.array.Add(this.index, _row);       
        return index++;
       // Row a= array[_row];  
       
    }
    public void AddRow(int _index, Row _row)
    {
        this.array.Add(_index, _row);
    }
    
    /// <summary>
    /// Add two rows
    /// </summary>
    /// <param name="sourceIndex">Index of the pivotrow, which is added to </param>
    /// <param name="destIndex">Index of the added row</param>
    public void SumRow(int sourceIndex, int destIndex)
    {

        Row sum1 = GetRow(sourceIndex);
        Row sum2 = GetRow(destIndex);
        double[] a = new double[sum1.Length];
        double[] b = new double[sum2.Length];
        if (sum1.Length == sum2.Length)
        {
            {
                for (int i = 0; i <= sum1.Length - 1; i++)
                {
                    // b[i] += a[i]; 
                    a[i] = (Double)sum1.Values.GetValue(i);
                    b[i] = (Double)sum2.Values.GetValue(i);
                    b[i] += a[i]; // sum rows
                    sum2.Values.SetValue(b[i], i); // stores the result of the addition
                    Console.WriteLine("b[i]:" + b[i]);
                }
            }

            AddRow(destIndex, sum2);
        }
        else
            return;
       // throw new NotImplementedException();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sourceIndex">Index of the pivotrow, which is added to</param>
    /// <param name="destIndex">Index of the added row</param>
    /// <param name="factor">Factor which mult the pivotrow</param>
    public void SumRow(int sourceIndex, int destIndex, double factor)
    {
        
        Row sum1 = GetRow(sourceIndex);
        Row sum2 = GetRow(destIndex);
        double[] a = new double[sum1.Length];
        double[] b = new double[sum2.Length];
        if (sum1.Length == sum2.Length)
        {
            {
                for (int i = 0; i <= sum1.Length - 1; i++)
                {
                    // b[i] += a[i]; 
                    a[i] = (Double)sum1.Values.GetValue(i);
                    b[i] = (Double)sum2.Values.GetValue(i);
                    b[i] *= factor;//mult pivotrow with factor
                    b[i] += a[i]; // sum rows
                    sum2.Values.SetValue(b[i], i); // stores the result of the addition
                }
            }

            AddRow(destIndex, sum2);
        }
        else
            return;
    }
    /// <summary>
    /// Multiplies a pivotrow with an factor 
    /// </summary>
    /// <param name="pivotIndex">Index of the pivotrow</param>
    /// <param name="factor"></param>
    public void MultiplyRow(int pivotIndex, double factor)
    {

        Row pivot = GetRow(pivotIndex);
        double[] a = new double[pivot.Length];
       
        if (pivot.Length != 0)
        {
            {
                for (int i = 0; i <= pivot.Length - 1; i++)
                {
                    a[i] = (Double)pivot.Values.GetValue(i);
                    a[i] *= factor; //mult the row with the factor
                    pivot.Values.SetValue(a[i], i);// stores the result of the multiplication
                }
            }

            AddRow(pivotIndex, pivot);
        }
    }

    public double DivideRowForPivot(int index, int pivoZaehler, int pivoNenner)
    {    
        Row sum = GetRow(index);
        double[] a = new double[sum.Length];
        double[] b = new double[sum.Length];

        if (sum.Length != 0)
        {
            {
                for (int i = 0; i <= sum.Length - 1; i++)
                {
                    a[pivoZaehler] = (Double)sum.Values.GetValue(pivoZaehler);
                    b[pivoNenner] = (Double)sum.Values.GetValue(pivoNenner);

                    a[pivoZaehler] /= b[pivoNenner]; // divides
                    //possible
                    sum.Values.SetValue(a[pivoZaehler], i + 1);// stores the result of the division
                }
            }

            return a[pivoZaehler]; // returns the result
        }
        else return 0;
    }


    //???? per que?
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
        if (!(this.array == null || this.array.Count == 0))
            return this.array[index];
        else
            return null;
    }

    #endregion
}