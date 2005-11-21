using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

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
        get { return pivotRow; }
        set { pivotRow = value; }
    }

    //-----------------------------------------------------------------------------------

    public int PivotColumn
    {
        get { return pivotColumn; }
        set { pivotColumn = value; }
    }
    
    //-----------------------------------------------------------------------------------

    public int ColumnCount
    {
        get { return columnCount; }
        set { columnCount = value; }
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
        throw new System.NotImplementedException();
    }

    #endregion --------------------------------------------------------------------------
    
}
