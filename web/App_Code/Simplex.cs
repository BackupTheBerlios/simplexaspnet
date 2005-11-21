using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

public class Simplex:ISimplex
{
    private SimplexField field;
    private int pivotColumn;
    private int pivotRow;

    public Simplex()
    {
       
    }

    /// <summary>
    /// Initializes the SimplexField
    /// </summary>
    /// <param name="field"></param>
    public Simplex(SimplexField field)
    {
        this.Field = field;
    }

    public SimplexField Field
    {
        get { return this.field; }
        set { this.field = value; }
    }

    /// <summary>
    /// finds the pivot column
    /// </summary>
    /// <returns></returns>
    public int FindPivotColumn()
    {
        this.pivotColumn = 1;
        return this.pivotColumn;
    }

    /// <summary>
    /// finds the pivot row
    /// </summary>
    /// <returns></returns>
    public int FindPivotRow()
    {
        this.pivotRow = 1;
        return this.pivotRow;
    }

    /// <summary>
    /// redefines the pivot column to bv
    /// </summary>
    public void RedefineField()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// start the simplex algorythm
    /// </summary>
    public void Start()
    {
        throw new NotImplementedException();
    }

    public void NextSetp()
    {
        this.FindPivotColumn();
        this.FindPivotRow();
    }


}
