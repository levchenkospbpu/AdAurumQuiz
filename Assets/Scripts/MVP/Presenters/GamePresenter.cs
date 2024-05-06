using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GamePresenter : BasePresenter<GameView, GameModel>
{
	public Action<int> OnAnswerButton;
	public Action OnAcceptButton;

	protected override GameObject Prefab { get; }
	protected override Transform Parent { get; }

	private GameObject AnswerButtonPrefab { get; }

	public GamePresenter(UICanvasData uiCanvasData, UIProviderConfig uiProviderConfig) : base(uiCanvasData, uiProviderConfig)
    {
        Prefab = uiProviderConfig.GamePanel;
        Parent = uiCanvasData.Screens;
        AnswerButtonPrefab = uiProviderConfig.AnswerButton;
	}

	public void ChangeAnswerCheckState(int answerIndex, int[] pickedAnswers)
	{
		var button = View.AnswerButtons[answerIndex];
		var checkBoxImage = button.gameObject.GetComponentsInChildren<Image>()
			.Where(x => x.gameObject.transform != button.gameObject.transform).FirstOrDefault();

		if (Model.Question.AnswerType == AnswerType.Single)
		{
			foreach (var element in pickedAnswers)
			{
				var pickedButton = View.AnswerButtons[element];
				var pickedCheckBoxImage = pickedButton.gameObject.GetComponentsInChildren<Image>()
					.Where(x => x.gameObject.transform != pickedButton.gameObject.transform).FirstOrDefault();

				pickedCheckBoxImage.enabled = false;
			}
			checkBoxImage.enabled = true;
		}
		else
		{
			if (checkBoxImage.enabled)
			{
				checkBoxImage.enabled = false;
			}
			else
			{
				checkBoxImage.enabled = true;
			}
		}
	}

	protected override void OnEnable()
    {
		View.Background.sprite = Model.Question.Background;
		View.QuestionText.text = Model.Question.Text;
		for (int i = 0; i < Model.Question.Answers.Length; i++)
		{
			var answerButtonObject = UnityEngine.Object.Instantiate(AnswerButtonPrefab, View.AnswersHolder);

			var answerButtonText = answerButtonObject.GetComponentInChildren<TextMeshProUGUI>();
			answerButtonText.text = Model.Question.Answers[i].text;

			var answerButtonComponent = answerButtonObject.GetComponent<Button>();
			answerButtonComponent.onClick.AddListener(() => OnAnswerButton?.Invoke(answerButtonObject.transform.GetSiblingIndex()));

			View.AnswerButtons.Add(answerButtonComponent);
		}
		View.AcceptButton.onClick.AddListener(() => OnAcceptButton?.Invoke());
    }

    protected override void OnDisable()
    {
		OnAnswerButton = null;
		OnAcceptButton = null;
	}
}