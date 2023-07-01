namespace ConsoleApp3
{
    public class StateMachine
    {
        public IState Root;

        private Dictionary<Type, IState> _states;
        private Stack<IState> _stack = new();
        private IState Top => _stack.Peek();
        public bool IsTop(IState state) => _stack.Peek() == state;

        public void ChangeState(IState state)
        {
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
}