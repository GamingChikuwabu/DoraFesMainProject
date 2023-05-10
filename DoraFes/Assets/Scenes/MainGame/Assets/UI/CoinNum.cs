using UnityEngine;
using TMPro;

public class CoinNum : MonoBehaviour
{
    public TMP_Text textComponent;
    public string newText = "0";

    private void Start()
    {
        textComponent = gameObject.GetComponent<TMP_Text>();
    }

    public void ChangeNumber(int countCoin)
    {
        textComponent.text = "Å~ " + countCoin.ToString();
    }
}