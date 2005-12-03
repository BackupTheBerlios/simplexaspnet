using System;
using System.Collections.Generic;

namespace LinearProgramming
{
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
            Console.WriteLine("addRow index:" + this.index);
            this.array.Add(this.index, _row);
            Console.WriteLine("return index: " + index);
            return index++;
            // Row a= array[_row];  
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
                        a[i] = (Double) sum1.Values.GetValue(i);
                        b[i] = (Double) sum2.Values.GetValue(i);
                        b[i] += a[i]; // sum rows
                        sum2.Values.SetValue(b[i], i); // stores the result of the addition
                        Console.WriteLine("b[i]:" + b[i]);
                    }
                }

                //AddRow(destIndex, sum2);
            }
            else
                return;
            // throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceIndex">Index of the source row</param>
        /// <param name="destIndex">index of the destination row</param>
        /// <param name="factor">Factor which mult the source row</param>
        public void SumRow(int sourceIndex, int destIndex, double factor)
        {
            Row sum1 = GetRow(sourceIndex);
            Row sum2 = GetRow(destIndex);
            
            double sourceRowValue;
            double destRowValue;

            if (sum1.Length == sum2.Length)
            {
                {
                    for (int i = 0; i <= sum1.Length - 1; i++)
                    {
                        sourceRowValue = (Double) sum1.Values.GetValue(i);
                        destRowValue = (Double) sum2.Values.GetValue(i);
                        sum2.Values.SetValue(destRowValue + sourceRowValue*factor, i); // stores the result of the addition
                    }
                }
            }
            else
                return;
        }

        public void DivideRow(int rowIndex, double factor)
        {
            MultiplyRow(rowIndex, 1 / factor);
        }

        /// <summary>
        /// Multiplies a row with a factor 
        /// </summary>
        /// <param name="_rowIndex"index of the row</param>
        /// <param name="factor"></param>
        public void MultiplyRow(int _rowIndex, double factor)
        {
            Row _row = GetRow(_rowIndex);

            if (_row.Length != 0)
            {
                for (int i = 0; i <= _row.Length - 1; i++)
                {
                    _row.Values.SetValue((Double) _row.Values.GetValue(i)*factor, i);
                    // stores the result of the multiplication
                }
            }
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
}