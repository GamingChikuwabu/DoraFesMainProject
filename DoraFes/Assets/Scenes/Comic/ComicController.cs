using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComicController : MonoBehaviour
{
    [Header("アクティブ変更するImage")]
    [SerializeField]private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Comic"))
        {
            ActiveComic();
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            ActiveComic();
        }
    }
    
    private void ActiveComic()
    {
        image.gameObject.SetActive(true);

    }
}
