namespace DifferentialEquations.Actions
{
    public interface IUiAction
    {
        string Name { get; }
        string Category { get; }
        void Perform();
    }
}