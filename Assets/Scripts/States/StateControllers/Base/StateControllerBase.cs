using Zenject;

public abstract class StateControllerBase : IStateController
{
	private IState _previousState;
	private readonly IInstantiator _instantiator;

	protected StateControllerBase(IInstantiator instantiator)
	{
		_instantiator = instantiator;
	}

	public abstract void Initialize();

	public T ChangeState<T>() where T : IState
	{
		_previousState?.Exit();
		var state = _instantiator.Instantiate<T>();
		_previousState = state;
		state.Enter();
		return state;
	}
}