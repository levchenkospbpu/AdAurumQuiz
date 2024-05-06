using System;
using UnityEngine;

public class ResultPopupPresenter : BasePresenter<ResultPopupView, ResultPopupModel>
{
	public Action OnTryAgainButton;

	protected override GameObject Prefab { get; }
	protected override Transform Parent { get; }

	public ResultPopupPresenter(UICanvasData uiCanvasData, UIProviderConfig uiProviderConfig) : base(uiCanvasData, uiProviderConfig)
	{
		Prefab = uiProviderConfig.ResultPopup;
		Parent = uiCanvasData.Popups;
	}

	protected override void OnEnable()
	{
		View.Description.text = View.Description.text + $"\n{Model.CorrectAnswers} / {Model.QuestionsCount}";
		View.TryAgainButton.onClick.AddListener(() => OnTryAgainButton?.Invoke());
	}

	protected override void OnDisable()
	{
		OnTryAgainButton = null;
	}
}