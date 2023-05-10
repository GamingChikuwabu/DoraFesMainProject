using UnityEngine;
using TMPro;

public class MandNum : MonoBehaviour
{
    public TMP_Text textComponent;
    public string newText = "1";

    private void Start()
    {
        textComponent = gameObject.GetComponent<TMP_Text>();
    }

    public void ChangeNumber(int countMand)
    {
        textComponent.text = "Å~ " + countMand.ToString();
    }
}