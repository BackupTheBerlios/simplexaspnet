using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

public abstract class SimplexField : Matrix
{
    public  void AddOptimize(int[] indexes)
    {
    }

    /// <summary>
    /// Adds a restriction to the matrix
    /// </summary>
    public  void AddRestriction(int[] restFkt)
    {
    }

    public  void AddSingleOptimize(int index)
    {
    }

    /// <summary>
    /// sets the function for the matrix
    /// </summary>
    public  void SetAimFkt(int[] aimFkt)
    {
    }

    /// <summary>
    /// defines the base variables in the first column of the matrix
    /// </summary>
    public  void SetBaseVariable(int index)
    {
    }
}
