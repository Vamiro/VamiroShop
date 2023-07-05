using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp3;

public class StateMachine : IStateMachine
{
    private readonly IServiceProvider _provider;
    public IState Root;

    private Dictionary<Type, IState> _states;
    private readonly Stack<IState> _stack = new();

    public StateMachine(IServiceProvider provider)
    {
        _provider = provider;
    }

    public IState Top => _stack.Peek();

    public bool IsTop(IState state)
    {
        return _stack.Peek() == state;
    }

    public void ChangeState(IState state)
    {
        if (_stack.Contains(state))
            while (!IsTop(state))
                PopState();
        else PushState(state);
    }

    public void ChangeState<T>() where T : IState
    {
        var state = (IState)_provider.GetRequiredService(typeof(T));
        if (_stack.Contains(state))
            while (!IsTop(state))
                PopState();
        else PushState(state);
    }

    private void PopState()
    {
        var state = _stack.Pop();
        state.Exit();
        Top.Enter();
    }

    private void PushState(IState state)
    {
        if (_stack.Count > 0) Top.Exit();
        _stack.Push(state);
        state.Enter();
    }
}