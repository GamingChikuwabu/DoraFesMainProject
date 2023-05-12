using UnityEngine;
using TMPro;

public class StageNum : MonoBehaviour
{
    public TMP_Text textComponent;
    public string newText = "1";

    private void Start()
    {
        textComponent = gameObject.GetComponent<TMP_Text>();
    }

    public void ChangeNumber(int stageNum)
    {
        textComponent.text = stageNum.ToString();
    }

    public void ChangeWorld(int worldNum)
    {
        textComponent.text = worldNum.ToString() + "   -";
    }
}