using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *=*=*=*=*=*=*=*=*
// �쐬�ҁF���c
// *=*=*=*=*=*=*=*=*

public class SideTextureRepeat : MonoBehaviour
{
    [Header("(x, z)�ǂ���̃X�P�[�����Q�Ƃ����s�[�g�����邩")]
    [SerializeField] private bool xRepeat = true;
    [SerializeField] private bool zRepeat = false;
    [Header("�n���̃}�e���A��")]
    [SerializeField] private Material subMaterial;

    void Start()
    {
        float textureScale = transform.parent.GetComponent<BlockManager>().textureScale;
        float trueTextureScale = 1f / textureScale;

        // Renderer�R���|�[�l���g���擾����
        Renderer renderer = GetComponent<Renderer>();
        // �e�N�X�`���̌J��Ԃ����[�h��Repeat�ɐݒ肷��
        renderer.material.mainTexture.wrapMode = TextureWrapMode.Repeat;

        // �e�I�u�W�F�N�g�̃X�P�[�����擾
        Vector3 parentScale = transform.parent.transform.localScale;
        // texture�̃��s�[�g�Ɏg�p����X�P�[��
        Vector3 repeatScale = parentScale;
        // �������̃��s�[�g����
        if (xRepeat) repeatScale.x = parentScale.x;
        else if (zRepeat) repeatScale.x = parentScale.z;
        repeatScale.y = textureScale;

        // �e�I�u�W�F�N�g��scale����textureScale�𒴂��Ă���
        if (parentScale.y > textureScale)
        {
            // *=*=*=*=*=*=*=*=*=*=*=*=*=*=*
            // �c������scale��textureScale�ɕύX
            gameObject.transform.localScale = new(transform.localScale.x, textureScale / parentScale.y, transform.localScale.z);
            transform.localPosition = new(transform.localPosition.x,
                1f - (transform.localScale.y / 2f),
                transform.localPosition.z);

            // *=*=*=*=*=*=*=*=*=*=*=*=*=*=*
            // ���g�𕡐�
            GameObject cloneGameObject = Instantiate(gameObject);
            // �����ɕ������Ȃ��悤�ɃX�N���v�g����菜��
            Destroy(cloneGameObject.GetComponent<SideTextureRepeat>());
            // �e�I�u�W�F�N�g��ݒ�
            GameObject parentGameObject = gameObject.transform.parent.gameObject;
            cloneGameObject.transform.SetParent(parentGameObject.transform, true);

            // *=*=*=*=*=*=*=*=*=*=*=*=*=*=*
            // �����̂�scale�𒲐�
            cloneGameObject.transform.localScale = new(transform.localScale.x, 1f - textureScale / parentScale.y, transform.localScale.z);
            // �����̂�position�𒲐�
            cloneGameObject.transform.localPosition = new(transform.localPosition.x,
                 cloneGameObject.transform.localScale.y / 2f,
                transform.localPosition.z);

            // *=*=*=*=*=*=*=*=*=*=*=*=*=*=*
            // �����̂�Renderer���擾
            Renderer cloneRenderer = cloneGameObject.GetComponent<Renderer>();
            cloneRenderer.material = subMaterial;
            cloneRenderer.material.mainTexture.wrapMode = TextureWrapMode.Repeat;

            // *=*=*=*=*=*=*=*=*=*=*=*=*=*=*
            // �����̂�texture�̃��s�[�g�񐔒���
            float repeatTextureC = parentScale.y - textureScale;
            cloneRenderer.material.mainTextureScale = new Vector2(repeatScale.x * trueTextureScale, repeatTextureC * trueTextureScale);
            // �e�N�X�`���̊J�n�ʒu������ɐݒ肷�鏈��
            // �c�����̌J��Ԃ��񐔂������łȂ��ꍇ�ɁA�e�N�X�`�����؂����Ȃ��悤�ɂ���
            cloneRenderer.material.mainTextureOffset = new Vector2(0f, 1f - (repeatTextureC * textureScale % 1f));
        }

        // *=*=*=*=*=*=*=*=*=*=*=*=*=*=*
        // ���g��texture�̃��s�[�g�ݒ�
        {
            // �e�N�X�`���̌J��Ԃ��񐔂𒲐�����
            renderer.material.mainTextureScale = new Vector2(repeatScale.x * trueTextureScale, repeatScale.y * trueTextureScale);
            // �e�N�X�`���̊J�n�ʒu������ɐݒ肷�鏈��
            // �c�����̌J��Ԃ��񐔂������łȂ��ꍇ�ɁA�e�N�X�`�����؂����Ȃ��悤�ɂ���
            renderer.material.mainTextureOffset = new Vector2(0f, 1f - (repeatScale.y * trueTextureScale % 1f));
        }
    }
    //[ContextMenu("Test")]
    //void TestMethod()
    //{
    //    Debug.Log("testLog");       
    //}
    //void OnValidate()
    //{
    //    Debug.Log("OnValidateLog");
    //    textureScale = Mathf.Max(textureScale, 0.0f);
    //}
}
