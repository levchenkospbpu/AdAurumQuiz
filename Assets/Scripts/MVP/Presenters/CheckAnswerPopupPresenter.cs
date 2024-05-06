using System;
using UnityEngine;

public class CheckAnswerPopupPresenter : BasePresenter<CheckAnswerPopupView, CheckAnswerPopupModel>
{
	public Action OnNextButton;

	protected override GameObject Prefab { get; }
	protected override Transform Parent { get; }

	public CheckAnswerPopupPresenter(UICanvasData uiCanvasData, UIProviderConfig uiProviderConfig) : base(uiCanvasData, uiProviderConfig)
	{
		Prefab = uiProviderConfig.CheckAnswerPopup;
		Parent = uiCanvasData.Popups;
	}

	protected override void OnEnable()
	{
		View.Description.text = Model.IsCorrect ? Model.CorrectText : Model.IncorrectText;
		View.NextButton.onClick.AddListener(() => OnNextButton?.Invoke());
	}

	protected override void OnDisable()
	{
		OnNextButton = null;
	}
}