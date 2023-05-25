using System.Diagnostics;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{

    public GameObject mainCamera;
    public GameObject subCamera;
    public GameObject Target;
    [SerializeField] GameObject Canvas;

    private GameObject LoadSceneObject;
    private LoadScene LS;
    float seconds;
    float elapsedTime;
    public float WaitTime = 5f; // ë“ã@Ç∑ÇÈïbêî
    private float startTime; // äJénéûä‘
    bool goalfg = false;

    void Start()
    {
        LoadSceneObject = GameObject.Find("LoadScene");
        LS = LoadSceneObject.GetComponent<LoadScene>();

    }
    void Update()
    {
        seconds += Time.deltaTime;
     if (seconds >= WaitTime && goalfg==true)
        {
            LS.SetLoadName("ResultScene");
        }
    }
    void OnTriggerExit(Collider other)
        {
                if (other.gameObject == Target)
                {

                    mainCamera.SetActive(!mainCamera.activeSelf);
                    Canvas.SetActive(false);
            goalfg = true;

                }
        
         }
    
}
        
    
    

