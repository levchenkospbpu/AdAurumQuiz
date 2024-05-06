using System;
using UnityEngine;

public class MenuPresenter : BasePresenter<MenuView, MenuModel>
{
	public Action OnStartGameButton;

	protected override GameObject Prefab { get; }
    protected override Transform Parent { get; }

    public MenuPresenter(UICanvasData uiCanvasData, UIProviderConfig uiProviderConfig) : base(uiCanvasData, uiProviderConfig)
    {
        Prefab = uiProviderConfig.MenuPanel;
        Parent = uiCanvasData.Screens;
    }

    protected override void OnEnable()
    {
        View.StartGameButton.onClick.AddListener(() => OnStartGameButton?.Invoke());
    }

    protected override void OnDisable()
    {
        OnStartGameButton = null;
	}
}