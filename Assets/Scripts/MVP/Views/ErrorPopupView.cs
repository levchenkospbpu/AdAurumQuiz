using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ErrorPopupView : BaseView
{
	[field: SerializeField] public TextMeshProUGUI Description { get; private set; }
	[field: SerializeField] public Button OkButton { get; private set; }
}