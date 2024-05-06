using Zenject;

public class SampleSceneStateController : StateControllerBase
{
	public SampleSceneStateController(IInstantiator instantiator) : base(instantiator)
	{
	}

	public override void Initialize()
	{
		ChangeState<MenuState>();
	}
}
