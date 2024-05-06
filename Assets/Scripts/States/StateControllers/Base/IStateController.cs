using Zenject;

public interface IStateController : IInitializable
{
	T ChangeState<T>() where T : IState;
}