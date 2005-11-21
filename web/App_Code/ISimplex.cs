public interface ISimplex
{
    SimplexField Field { get; set; }

    /// <summary>
    /// finds the pivot column
    /// </summary>
    /// <returns></returns>
    int FindPivotColumn();

    /// <summary>
    /// finds the pivot row
    /// </summary>
    /// <returns></returns>
    int FindPivotRow();

    /// <summary>
    /// redefines the pivot column to bv
    /// </summary>
    void RedefineField();

    /// <summary>
    /// start the simplex algorythm
    /// </summary>
    void Start();
}