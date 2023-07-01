namespace ConsoleApp3;

public interface IState
{
    void Enter();
    void Exit();
    void InputHandler();
}