using UnityEngine.UI;
using UnityEngine;

public class ScorePanelView : MonoBehaviour
{
    public Text scoreValue;
    public void UpdateValue(int value)
    {
        scoreValue.text = value.ToString();
    }
}