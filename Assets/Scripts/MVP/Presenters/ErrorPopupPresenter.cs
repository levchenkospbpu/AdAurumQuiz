using System;
using UnityEngine;

public class ErrorPopupPresenter : BasePresenter<ErrorPopupView, ErrorPopupModel>
{
	public Action OnOkButton;

	protected override GameObject Prefab { get; }
	protected override Transform Parent { get; }

	public ErrorPopupPresenter(UICanvasData uiCanvasData, UIProviderConfig uiProviderConfig) : base(uiCanvasData, uiProviderConfig)
	{
		Prefab = uiProviderConfig.ErrorPopup;
		Parent = uiCanvasData.Popups;
	}

	protected override void OnEnable()
	{
		View.Description.text = Model.Descriptopn;
		View.OkButton.onClick.AddListener(() => OnOkButton?.Invoke());
	}

	protected override void OnDisable()
	{
		OnOkButton = null;
	}
}