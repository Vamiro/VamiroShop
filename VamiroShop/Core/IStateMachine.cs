namespace ConsoleApp3;

public interface IStateMachine
{
    IState Top { get; }
    bool IsTop(IState state);
    void ChangeState(IState state);

    public void ChangeState<T>() where T : IState;
}