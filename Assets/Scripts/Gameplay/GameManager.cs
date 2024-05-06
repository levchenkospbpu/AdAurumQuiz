using System.Collections.Generic;
using System.Linq;
public class GameManager
{
	public List<Question> Questions => _questions;
	public List<Question> FinishedQuestions => _finishedQuestions;
	public List<int> PickedAnswers => _pickedAnswers;
	public int CorrectAnswers => _correctAnswers;
	public bool IsFinished => _finishedQuestions.Count >= Questions.Count;

	private readonly List<Question> _questions;
	private readonly List<Question> _finishedQuestions;
	private readonly List<int> _pickedAnswers;

	private int _correctAnswers;
	private int _currentQuestion = 0;

	public GameManager(List<Question> questions)
	{
		_questions = questions;
		_finishedQuestions = new List<Question>();
		_pickedAnswers = new List<int>();
	}

	public void ChangeAnswerPickState(int answerIndex)
	{
		if (_questions[_currentQuestion].AnswerType == AnswerType.Single)
		{
			_pickedAnswers.Clear();
			_pickedAnswers.Add(answerIndex);
		}
		else
		{
			if (_pickedAnswers.Contains(answerIndex))
			{
				_pickedAnswers.Remove(answerIndex);
			}
			else
			{
				_pickedAnswers.Add(answerIndex);
			}
		}
	}

	public void Accept()
	{
		_finishedQuestions.Add(_questions[_currentQuestion]);
		PickedAnswers.Clear();
	}


	public bool CheckAnswers()
	{
		var correctAnswers = _questions[_currentQuestion].GetCorrectAnswers();
		var allCorrectPicked = !correctAnswers.Except(_pickedAnswers).ToList().Any();
		var notExtraPicked = !_pickedAnswers.Except(correctAnswers).ToList().Any();

		if (allCorrectPicked && notExtraPicked)
		{
			_correctAnswers++;
		}

		return allCorrectPicked && notExtraPicked;
	}

	public Question GetRandomQuestion()
	{
		_currentQuestion = GetRandomQuestionIndex();

		if (_currentQuestion == -1)
		{
			return null;
		}

		return _questions[_currentQuestion];
	}

	private int GetRandomQuestionIndex()
	{
		var questionIndex = -1;

		if (_finishedQuestions.Count < _questions.Count)
		{
			var remainingQuestions = _questions.Except(_finishedQuestions).ToList();
			var random = UnityEngine.Random.Range(0, remainingQuestions.Count);
			questionIndex = Questions.IndexOf(remainingQuestions[random]);
		}

		return questionIndex;
	}
}
