public interface ISimplex
{
    SimplexField Field { get; set; }

    int FindPivotColumn();

    int FindPivotRow();

    double DivideRowForPivot(int rowIndex); 
    
    void NextStep();
    
    void SetPivotElement();

    bool isComplete();
}