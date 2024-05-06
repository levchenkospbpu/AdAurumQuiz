public class MenuState : State
{
    private readonly MenuPresenter _menuPresenter;
	private readonly IStateController _stateController;

    public MenuState(UIProviderConfig uiProviderConfig, UICanvasData uiCanvasData, IStateController stateController)
    {
        _menuPresenter = new MenuPresenter(uiCanvasData, uiProviderConfig);
		_stateController = stateController;
	}

    protected override void OnEnter()
    {
        _menuPresenter.Enable();
        BindMenuPresenter();
	}

    protected override void OnExit()
    {
        _menuPresenter.Disable();
    }

    private void BindMenuPresenter()
    {
		_menuPresenter.OnStartGameButton += () =>
		{
			_stateController.ChangeState<GameState>();
		};
	}
}