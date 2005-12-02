using System;

public class Row : Object, IComparable
{
    private double[] values;

    public Row(double[] init)
    {
        Console.WriteLine("Row Constructor" + init[0]);
        this.values = init;
    }


    public double[] Values
    {
        get { return this.values; }
        set { this.values = value; }
    }

    public int Length
    {
        get { return this.values.Length; }
    }

    public override bool Equals(object obj)
    {
        return this.GetHashCode() == obj.GetHashCode();
    }

    public override int GetHashCode()
    {
        int hashCode = 0;
        if (this.values != null)
        {
            hashCode = 0;
            int i = 0;
            foreach (double value in this.values)
            {
                if (i == 0)
                    hashCode = (int) value*(i + 1);
                else
                    hashCode ^= (int) (value*(i + 1));
                i++;
            }
        }
        return (int) hashCode;
    }


    int IComparable.CompareTo(object obj)
    {
        int returnValue = 0;

        if (this.Values != ((Row) obj).Values)
            returnValue = 1;
        return returnValue;
    }
}