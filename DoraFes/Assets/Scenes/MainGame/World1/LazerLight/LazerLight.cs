using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerLight : MonoBehaviour
{
    [Header("‰ñ“]ƒXƒs[ƒh")]
    [SerializeField]private float rotationSpeed = 20f;

    [Header("‰ñ“]ãŒÀ(1`90)")]
    [SerializeField] private float upLimit = 60f;

    [Header("‰ñ“]‰ºŒÀ(1`90)")]
    [SerializeField] private float downLimit = 10f;

    private bool rotateUp = true; //ãŒü‚«‚É‰ñ“]‚·‚é‚©‚Ç‚¤‚©‚Ìƒtƒ‰ƒO

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //–ˆƒtƒŒ[ƒ€‚²‚Æ‚Ì‰ñ“]—Ê‚ðŒvŽZ
        float rotationAmount = rotationSpeed * Time.deltaTime;

        //ãŒü‚«‰ñ“]‚Ìê‡
        if(rotateUp)
        {
            //ƒIƒuƒWƒFƒNƒg‚ð‰ñ“]‚³‚¹‚é
            transform.Rotate(Vector3.forward, rotationAmount); //yŽ²‰ñ“]
            //transform.Rotate(Vector3.up, rotationAmount);      xŽ²‰ñ“]

            

            //ãŒü‚«‰ñ“]‚ª60“xˆÈã‚É‚È‚Á‚½‚çƒtƒ‰ƒO‚ðØ‚è‘Ö‚¦‚é
            if (transform.rotation.eulerAngles.z >= upLimit)
                rotateUp = false;
        }
        //‰ºŒü‚«‰ñ“]‚Ìê‡
        else
        {
            // ƒIƒuƒWƒFƒNƒg‚ð‰ñ“]‚³‚¹‚é
            transform.Rotate(Vector3.forward, -rotationAmount);

            // ‰ºŒü‚«‰ñ“]‚ª60“xˆÈ‰º‚É‚È‚Á‚½‚çƒtƒ‰ƒO‚ðØ‚è‘Ö‚¦‚é
            if (-transform.rotation.eulerAngles.z >= -downLimit)
                rotateUp = true;
        }
        
    }
}
