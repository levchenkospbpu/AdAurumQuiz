using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckAnswerPopupView : BaseView
{
	[field: SerializeField] public Image Background { get; private set; }
	[field: SerializeField] public TextMeshProUGUI Description { get; private set; }
	[field: SerializeField] public Button NextButton { get; private set; }
}