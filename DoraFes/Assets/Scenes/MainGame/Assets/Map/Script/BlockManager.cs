using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [Header("基本とするtextureのscale")]
    [SerializeField] public float textureScale = 1f;

    void Start()
    {
        // マイナスの値の場合0を代入
        textureScale = Mathf.Max(textureScale, 0.0f);
    }

    void Update()
    {
        
    }
}
