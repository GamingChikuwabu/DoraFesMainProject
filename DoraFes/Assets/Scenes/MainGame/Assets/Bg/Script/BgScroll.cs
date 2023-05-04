using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{
    [Header("スクロールスピード")]
    [SerializeField] float scrollSpeed = 5;
    [Header("ランダム配置")]
    [SerializeField] private bool isRandom = true;
    [Header("ランダム表示確率")]
    [SerializeField] private float probability = 0.5f;

    MeshRenderer ren = null;

    private void Start()
    {
        ren = this.GetComponent<MeshRenderer>();
    }

    void LateUpdate()
    {
        Scroll();
        AdjustPos();
    }

    void Scroll()
    {
        // 更新座標
        Vector3 newPos;   
        newPos.x = transform.localPosition.x + Time.deltaTime * -scrollSpeed;
        newPos.y = transform.localPosition.y;
        newPos.z = transform.localPosition.z;
        transform.localPosition = newPos;
    }

    void AdjustPos()
    {
        // カメラの左から見切れた
        if (transform.localPosition.x < -transform.localScale.x)
        {
            transform.localPosition += Vector3.right * (transform.localScale.x * 3);
            RandomRender();
        }
        // カメラの右から見切れた
        else if (transform.localPosition.x > transform.localScale.x)
        {
            transform.localPosition -= Vector3.right * (transform.localScale.x * 3);
            RandomRender();
        }
    }

    void RandomRender()
    {
        if (isRandom)
        {
            float random = Random.Range(0.0f, 1.0f);
            if (random < probability)
            {
                ren.enabled = true;
            }
            else
            {
                ren.enabled = false;
            }
        }
    }
}
