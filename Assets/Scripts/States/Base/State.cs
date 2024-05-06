public abstract class State : IState
{
    public void Enter()
    {
        OnEnter();
    }

    public void Exit()
    {
        OnExit();
    }

    protected abstract void OnEnter();
    protected abstract void OnExit();

}