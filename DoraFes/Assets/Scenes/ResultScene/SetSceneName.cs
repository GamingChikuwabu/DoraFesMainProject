using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSceneName : MonoBehaviour
{
    private string nextSceneName;

    public void SetRetrySceneName(string s)
    {
        nextSceneName = s;
    }

    public string GetRetrySceneName()
    {
        return nextSceneName;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
