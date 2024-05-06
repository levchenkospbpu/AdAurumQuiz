using System.Collections.Generic;
using UnityEngine;

public class Question
{
	public string Text { get; private set; }
	public Sprite Background { get; private set; }
	public Answer[] Answers { get; private set; }
	public AnswerType AnswerType { get; private set; }

	public Question(string text, Sprite sprite, Answer[] answers)
	{
		Text = text;
		Background = sprite;
		Answers = answers;

		if (GetCorrectAnswers().Count is > 1 or 0)
		{
			AnswerType = AnswerType.Multi;
		}
		else
		{
			AnswerType = AnswerType.Single;
		}
	}

	public List<int> GetCorrectAnswers()
	{
		List<int> CorrectAnswers = new List<int>();
		for (int i = 0; i < Answers.Length; i++)
		{
			if (Answers[i].correct)
			{
				CorrectAnswers.Add(i);
			}
		}
		return CorrectAnswers;
	}
}

public struct QuestionData
{
	public string question;
	public Answer[] answers;
	public string background;
}