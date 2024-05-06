using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultPopupView : BaseView
{
	[field: SerializeField] public TextMeshProUGUI Description { get; private set; }
	[field: SerializeField] public Button TryAgainButton { get; private set; }
}