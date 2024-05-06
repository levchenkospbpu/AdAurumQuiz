using System;
using System.Collections.Generic;
using UnityEngine;

public class GameState : State
{
	private readonly IStateController _stateController;
    private readonly TextAsset _jsonText;
	private readonly GamePresenter _gamePresenter;
	private readonly CheckAnswerPopupPresenter _checkAnswerPopupPresenter;
	private readonly ResultPopupPresenter _resultPopupPresenter;
	private readonly ErrorPopupPresenter _errorPopupPresenter;

	private GameManager _gameManager;

    public GameState( UIProviderConfig uiProviderConfig, UICanvasData uiCanvasData, IStateController stateController, TextAsset jsonText)
    {
        _gamePresenter = new GamePresenter(uiCanvasData, uiProviderConfig);
		_checkAnswerPopupPresenter = new CheckAnswerPopupPresenter(uiCanvasData, uiProviderConfig);
		_resultPopupPresenter = new ResultPopupPresenter(uiCanvasData, uiProviderConfig);
		_errorPopupPresenter = new ErrorPopupPresenter(uiCanvasData, uiProviderConfig);
		_stateController = stateController;
		_jsonText = jsonText;
	}

    protected override void OnEnter()
    {
        var questions = TryLoadQuestions();

		if (questions == default(List<Question>))
		{
			return;
		}

		_gameManager = new GameManager(questions);
		var nextQuestion = TryGetRandomQuestion();
		_gamePresenter.Enable(new GameModel(nextQuestion));
		BindGamePresenter();
	}

    protected override void OnExit()
    {
        _gamePresenter.Disable();
		_checkAnswerPopupPresenter.Disable();
		_resultPopupPresenter.Disable();
		_errorPopupPresenter.Disable();
	}

	private void BindGamePresenter()
	{
		_gamePresenter.OnAcceptButton += () =>
		{
			var isCorrect = _gameManager.CheckAnswers();
			_gameManager.Accept();

			_gamePresenter.Disable();
			_checkAnswerPopupPresenter.Enable(new CheckAnswerPopupModel(isCorrect));
			BindCheckAnswerPopupPresenter();
		};

		_gamePresenter.OnAnswerButton += (int answerIndex) =>
		{
			_gamePresenter.ChangeAnswerCheckState(answerIndex, _gameManager.PickedAnswers.ToArray());
			_gameManager.ChangeAnswerPickState(answerIndex);
		};
	}

	private void BindCheckAnswerPopupPresenter()
	{
		_checkAnswerPopupPresenter.OnNextButton += () =>
		{
			_checkAnswerPopupPresenter.Disable();

			if (_gameManager.IsFinished)
			{
				_resultPopupPresenter.Enable(new ResultPopupModel(_gameManager.CorrectAnswers, _gameManager.Questions.Count));
				BindResultPopupPresenter();
			}
			else
			{
				var nextQuestion = TryGetRandomQuestion();
				_gamePresenter.Enable(new GameModel(nextQuestion));
				BindGamePresenter();
			}
		};
	}

	private void BindResultPopupPresenter()
	{
		_resultPopupPresenter.OnTryAgainButton += () =>
		{
			_stateController.ChangeState<MenuState>();
		};
	}

	private void BindErrorPopupPresenter()
	{
		_errorPopupPresenter.OnOkButton += () =>
		{
			_stateController.ChangeState<MenuState>();
		};
	}

	private Question TryGetRandomQuestion()
	{
		try
		{
			var question = _gameManager.GetRandomQuestion();

			if (question == null)
			{
				throw new Exception();
			}

			return question;
		}
		catch (Exception)
		{
			OnExit();
			_errorPopupPresenter.Enable(new ErrorPopupModel("Не удалось загрузить следующий вопрос"));
			BindErrorPopupPresenter();
			return default;
		}
	}

	private List<Question> TryLoadQuestions()
	{
		try
		{
			var questions = QuestionsLoader.FromJSON(_jsonText.text);
			return questions;
		}
		catch (Exception)
		{
			OnExit();
			_errorPopupPresenter.Enable(new ErrorPopupModel("Не удалось загрузить данные"));
			BindErrorPopupPresenter();
			return default;
		}
	}
}