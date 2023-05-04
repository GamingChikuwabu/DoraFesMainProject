using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{
    [Header("�X�N���[���X�s�[�h")]
    [SerializeField] float scrollSpeed = 5;
    [Header("�����_���z�u")]
    [SerializeField] private bool isRandom = true;
    [Header("�����_���\���m��")]
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
        // �X�V���W
        Vector3 newPos;   
        newPos.x = transform.localPosition.x + Time.deltaTime * -scrollSpeed;
        newPos.y = transform.localPosition.y;
        newPos.z = transform.localPosition.z;
        transform.localPosition = newPos;
    }

    void AdjustPos()
    {
        // �J�����̍����猩�؂ꂽ
        if (transform.localPosition.x < -transform.localScale.x)
        {
            transform.localPosition += Vector3.right * (transform.localScale.x * 3);
            RandomRender();
        }
        // �J�����̉E���猩�؂ꂽ
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
