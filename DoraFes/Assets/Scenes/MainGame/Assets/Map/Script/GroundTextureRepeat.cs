using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTextureRepeat : MonoBehaviour
{
    void Start()
    {
        float textureScale = 1f / transform.parent.GetComponent<BlockManager>().textureScale;

        // Renderer�R���|�[�l���g���擾����
        Renderer renderer = GetComponent<Renderer>();
        // �e�N�X�`���̌J��Ԃ����[�h�� "Repeat" �ɐݒ肷��
        renderer.material.mainTexture.wrapMode = TextureWrapMode.Repeat;
        // �e�I�u�W�F�N�g�̃X�P�[�����擾
        Vector3 parentScale = transform.parent.transform.localScale;
        // texture�̃��s�[�g�Ɏg�p����X�P�[��
        Vector3 scale = parentScale;
        // �c�����̃X�P�[��
        renderer.material.mainTextureScale = new Vector2(scale.x * textureScale, scale.z * textureScale);
    }
}
