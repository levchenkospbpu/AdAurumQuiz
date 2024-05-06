using UnityEngine;

[CreateAssetMenu(fileName = "NewUIProviderConfig", menuName = "Data/UIProviderConfig")]
public class UIProviderConfig : ScriptableObject
{
    public GameObject MenuPanel;
    public GameObject GamePanel;
    public GameObject AnswerButton;
    public GameObject CheckAnswerPopup;
    public GameObject ResultPopup;
    public GameObject ErrorPopup;
}