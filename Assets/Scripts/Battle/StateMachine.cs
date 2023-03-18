public class StateMachine
{
    private IState _currentState;

    public void ChangeState(IState state)
    {
        _currentState?.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Tick() => _currentState?.Tick();
    public void FixedTick() => _currentState?.FixedTick();
}