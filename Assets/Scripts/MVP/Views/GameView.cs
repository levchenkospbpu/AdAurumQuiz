using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameView : BaseView
{
	[field: SerializeField] public TextMeshProUGUI QuestionText { get; private set; }
	[field: SerializeField] public Button AcceptButton { get; private set; }
	[field: SerializeField] public Transform AnswersHolder { get; private set; }
	[field: SerializeField] public Image Background { get; set; }
	[field: SerializeField] public List<Button> AnswerButtons { get; set; }
}