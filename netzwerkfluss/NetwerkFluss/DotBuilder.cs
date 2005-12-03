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
    public DotBuilder( IMatrix _matrix, int _number)
    {
        this.matrix = _matrix;
        this.number = _number;
    }

    /// <summary>
    /// Builds the dot.file with the directed graph
    /// </summary>
    public void Build()
    {
        
        double [] nodes = new Double[number];
        Row row = new Row(nodes);
        FILE_NAME = "MyFile.dot";
       
        if (File.Exists(FILE_NAME))
        {
            Console.WriteLine("{0} already exists.", FILE_NAME);
            return;
        }
        StreamWriter sr = File.CreateText(FILE_NAME);
        sr.WriteLine(" digraph G {");
        sr.WriteLine(" size =" +number+","+number+";");
        for (int i = 0; i < number; i++)
        {
            row = matrix.GetRow(i);
            for (int j = 0; j < row.Length; j++)
            {
                if (row.Values[j] != -1)
                {
                    sr.WriteLine(" " + (i+1) + " -> " + (j+1) + " [label=" + row.Values[j] + "];");
                }
                
            }

        }
      
        

        /// Header der Knoten in Matrix auslesen und die dazugehörigen Kosten
      
        //sr.WriteLine("I can write ints {0} or floats {1}, and so on.",
        //    1, 4.2);
        sr.Close();
            
            //row.ToString;
            //row.Values.
        }
        //throw new System.NotImplementedException();
    
}

