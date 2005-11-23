using System;

public class SimplexField : Matrix
{
    #region -----------------------------------------------------------------------------

    private int pivotRow = -1;
    private int pivotColumn = -1;
    private int columnCount;

    #endregion --------------------------------------------------------------------------

    #region constructors ----------------------------------------------------------------

    public SimplexField(int size)
    {
        this.ColumnCount = size;
    }

    #endregion --------------------------------------------------------------------------

    #region properties ------------------------------------------------------------------

    public int PivotRow
    {
        get { return this.pivotRow; }
        set { this.pivotRow = value; }
    }

    //-----------------------------------------------------------------------------------

    public int PivotColumn
    {
        get { return this.pivotColumn; }
        set { this.pivotColumn = value; }
    }

    //-----------------------------------------------------------------------------------

    public int ColumnCount
    {
        get { return this.columnCount; }
        set { this.columnCount = value; }
    }

    #endregion

    #region methods ---------------------------------------------------------------------

    public void AddOptimize(int[] indexes)
    {
    }

    //-----------------------------------------------------------------------------------

    /// <summary>
    /// Adds a restriction to the matrix
    /// </summary>
    public void AddRestriction(int[] restFkt)
    {
    }

    //-----------------------------------------------------------------------------------

    public void AddSingleOptimize(int index)
    {
    }

    //-----------------------------------------------------------------------------------

    /// <summary>
    /// sets the function for the matrix
    /// </summary>
    public void SetAimFkt(int[] aimFkt)
    {
    }

    //-----------------------------------------------------------------------------------

    /// <summary>
    /// defines the base variables in the first column of the matrix
    /// </summary>
    public void SetBaseVariable(int index)
    {
    }

    //-----------------------------------------------------------------------------------

    public void Method()
    {
        throw new NotImplementedException();
    }

    #endregion --------------------------------------------------------------------------
}