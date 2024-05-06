using UnityEngine;

public class UICanvasData : MonoBehaviour
{
    [field: SerializeField]
    public Transform Screens { get; private set; }

	[field: SerializeField]
    public Transform Popups { get; private set; }
}