using System;
using LinearProgramming;

public class SimplexField : Matrix
{
    #region member variables ------------------------------------------------------------

    private int pivotRow = -1;
    private int pivotColumn = -1;
    private int columnCount;

    #endregion --------------------------------------------------------------------------
    
    #region constructors ----------------------------------------------------------------

    /// <summary>
    /// Initialisiert das SimplexFeld
    /// </summary>
    /// <param name="size">Anzahl der Spalten</param>
    public SimplexField(int size)
    {
        this.columnCount = size;
    }

    #endregion --------------------------------------------------------------------------

    #region properties ------------------------------------------------------------------
   
    /// <summary>
    /// Liest und die Pivot-Zeile
    /// </summary>
    public int PivotRow
    {
        get { return this.pivotRow; }
        set { this.pivotRow = value; }
    }

    //-----------------------------------------------------------------------------------

    /// <summary>
    /// Liest und setzt die Pivot-Spalte
    /// </summary>
    public int PivotColumn
    {
        get { return this.pivotColumn; }
        set { this.pivotColumn = value; }
    }

    //-----------------------------------------------------------------------------------

    /// <summary>
    /// Liefert die Anzahl der Spalten
    /// </summary>
    public int ColumnCount
    {
        get { return this.columnCount; }
    }

    #endregion
}