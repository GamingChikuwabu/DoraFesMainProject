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
    public bool goalfg = false;

    void Start()
    {
        LoadSceneObject = GameObject.Find("LoadScene");
        LS = LoadSceneObject.GetComponent<LoadScene>();

    }
    void Update()
    {
        if (goalfg == true)
        {
            seconds += Time.deltaTime;
            if (seconds >= WaitTime)
            {
                
                LS.SetLoadName("StageSelect");
            }
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
        
    
    

