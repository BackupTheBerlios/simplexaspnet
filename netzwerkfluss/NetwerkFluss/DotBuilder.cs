using System;
using System.Collections.Generic;
using System.Text;
using LinearProgramming;
using System.IO;


public class DotBuilder
{
    private IMatrix matrix;
    private int number;
    private string FILE_NAME;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="_matrix">Matrix</param>
    /// <param name="_number">Number of notes</param>
    public DotBuilder(IMatrix _matrix, int _number)
    {
        this.matrix = _matrix;
        this.number = _number;
    }

    /// <summary>
    /// Builds the dot.file with the directed graph (includes: nodes and cots)
    /// </summary>
    public void Build(double[,] _points, IMatrix _matrix, String _fileName)
    {

        double[] nodes = new Double[number];
        Row row = new Row(nodes);
        FILE_NAME = _fileName;

        if (File.Exists(FILE_NAME))
        {
            Console.WriteLine("{0} already exists.", FILE_NAME);
            return;
        }


        StreamWriter sr = File.CreateText(FILE_NAME);
        sr.WriteLine(" digraph G {\n size =\"" + number + "," + number + "\";");
        for (int i = 0; i < number; i++)
        {
            row = _matrix.GetRow(i);
            for (int j = 0; j < row.Length; j++)
            {

                if (row.Values[j] != -1)
                {
                    if (FILE_NAME == "OptimizedGraph.dot")
                    {
                        if ((Double)_points.GetValue(i, j) > 0.0)
                            sr.WriteLine(" " + (i + 1) + " -> " + (j + 1) + " [label=\"" + row.Values[j] + "\",color=red];");
                    }
                    else
                        sr.WriteLine(" " + (i + 1) + " -> " + (j + 1) + " [label=\"" + row.Values[j] + "\"];");
                }

            }
        }

        sr.WriteLine(" }");
        sr.Close();

    }

    // public void Build(double[,] _points, IMatrix _matrix, String _fileName)
    //{
    //    double[] nodes = new Double[number];
    //    Row row = new Row(nodes);
    //     for(int i = 0, i< _points.Length;i++)
    //     {
    //         for(int j = 0, j< _points.Length;j++)
    //        {
    //            if (_points.GetValue(i, j) >0)
    //                _matrix.

    //    _points.GetValue(i);
    //}



    /// <summary>
    /// Rules for Nodes
    /// </summary>
    /// <param name="_transportSize"></param>
    /// <param name="_source"></param>
    /// <param name="_dest"></param>
    /// <returns></returns>
    public string[] createRestrictions(int _transportSize, int _source, int _dest)
    {
        double[] nodes = new Double[number];
        Row row = new Row(nodes);
        String[] restriction = new String[number + 2];

        for (int i = 0; i < number; i++)
        {
            if (i == 0)
                restriction[i] = getAimFunction();
            if (i == _dest - 1)
            {
                if (i == number - 1)
                    restriction[i + 1] = getColumnNodes(_dest - 1) + "=" + _transportSize;
                else
                    restriction[i + 1] = getColumnNodes(_dest - 1) + "=" + _transportSize + ",";
            }
            if (i == _source - 1)
            {
                if (i == number - 1)
                    restriction[i + 1] = getRowNodes(_source - 1, true) + "=" + _transportSize;
                else
                    restriction[i + 1] = getRowNodes(_source - 1, true) + "=" + _transportSize + ",";
            }

            if (i != _dest - 1 && i != _source - 1)
            {
                if (i == number - 1)
                    restriction[i + 1] = getColumnNodes(i) + getRowNodes(i, false) + "= 0";
                else
                    restriction[i + 1] = getColumnNodes(i) + getRowNodes(i, false) + "= 0,";
            }
        }
        restriction[number + 1] = "},NONNEGATIVE);";
        return restriction;

    }


    public string getColumnNodes(int _indexColumn)
    {
        double[] nodes = new Double[number];
        Row row = new Row(nodes);
        string temp = "";
        for (int z = 0; z < number; z++)
        {
            row = matrix.GetRow(z);
            if (row.Values[_indexColumn] != -1 && temp == "")
                temp = temp + "x" + (z + 1) + (_indexColumn + 1);
            else if (row.Values[_indexColumn] != -1)
                temp = temp + "+x" + (z + 1) + (_indexColumn + 1);
        }
        return temp;
    }

    public string getRowNodes(int _indexRow, bool flag)
    {
        double[] nodes = new Double[number];
        Row row1 = new Row(nodes);
        string temp = "";
        row1 = matrix.GetRow(_indexRow);
        for (int j = 0; j < number; j++)
        {
            if (row1.Values[j] != -1 && temp == "" && flag == true)
                temp = temp + "x" + (_indexRow + 1) + (j + 1);

            else if (row1.Values[j] != -1 && flag == false)
                temp = temp + "-x" + (_indexRow + 1) + (j + 1);

            else if (row1.Values[j] != -1 && flag == true)
                temp = temp + "+x" + (_indexRow + 1) + (j + 1);

        }
        return temp;
    }

    public string getAimFunction()
    {
        double[] nodes = new Double[number];
        Row row1 = new Row(nodes);
        string tmp = "with(simplex)minimize(";
        for (int i = 0; i < number; i++)
        {

            row1 = matrix.GetRow(i);
            for (int j = 0; j < number; j++)
            {
                if (row1.Values[j] != -1 && tmp == "with(simplex)minimize(")
                    tmp = tmp + row1.Values[j] + "*x" + (i + 1) + (j + 1);

                else if (row1.Values[j] != -1)
                    tmp = tmp + "+" + row1.Values[j] + "*x" + (i + 1) + (j + 1);


            }
        }
        return tmp + ",{";
    }

    public string getRestrictions(int _transportSize, int _source, int _dest)
    {
        string restriction = String.Empty;
        string[] stringArray = createRestrictions(_transportSize, _source, _dest);
        foreach (string singleRestriction in stringArray)
        {
            restriction += singleRestriction;
        }
        return restriction;
    }
}

