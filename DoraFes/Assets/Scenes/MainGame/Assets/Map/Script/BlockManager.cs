using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [Header("��{�Ƃ���texture��scale")]
    [SerializeField] public float textureScale = 1f;

    void Start()
    {
        // �}�C�i�X�̒l�̏ꍇ0����
        textureScale = Mathf.Max(textureScale, 0.0f);
    }

    void Update()
    {
        
    }
}
