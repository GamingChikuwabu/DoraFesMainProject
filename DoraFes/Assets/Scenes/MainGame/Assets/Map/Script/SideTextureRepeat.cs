using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *=*=*=*=*=*=*=*=*
// 作成者：原田
// *=*=*=*=*=*=*=*=*

public class SideTextureRepeat : MonoBehaviour
{
    [Header("(x, z)どちらのスケールを参照しリピートさせるか")]
    [SerializeField] private bool xRepeat = true;
    [SerializeField] private bool zRepeat = false;
    [Header("地中のマテリアル")]
    [SerializeField] private Material subMaterial;

    void Start()
    {
        float textureScale = transform.parent.GetComponent<BlockManager>().textureScale;
        float trueTextureScale = 1f / textureScale;

        // Rendererコンポーネントを取得する
        Renderer renderer = GetComponent<Renderer>();
        // テクスチャの繰り返しモードをRepeatに設定する
        renderer.material.mainTexture.wrapMode = TextureWrapMode.Repeat;

        // 親オブジェクトのスケールを取得
        Vector3 parentScale = transform.parent.transform.localScale;
        // textureのリピートに使用するスケール
        Vector3 repeatScale = parentScale;
        // 横方向のリピートを代入
        if (xRepeat) repeatScale.x = parentScale.x;
        else if (zRepeat) repeatScale.x = parentScale.z;
        repeatScale.y = textureScale;

        // 親オブジェクトのscaleががtextureScaleを超えている
        if (parentScale.y > textureScale)
        {
            // *=*=*=*=*=*=*=*=*=*=*=*=*=*=*
            // 縦方向のscaleをtextureScaleに変更
            gameObject.transform.localScale = new(transform.localScale.x, textureScale / parentScale.y, transform.localScale.z);
            transform.localPosition = new(transform.localPosition.x,
                1f - (transform.localScale.y / 2f),
                transform.localPosition.z);

            // *=*=*=*=*=*=*=*=*=*=*=*=*=*=*
            // 自身を複製
            GameObject cloneGameObject = Instantiate(gameObject);
            // 無限に複製しないようにスクリプトを取り除く
            Destroy(cloneGameObject.GetComponent<SideTextureRepeat>());
            // 親オブジェクトを設定
            GameObject parentGameObject = gameObject.transform.parent.gameObject;
            cloneGameObject.transform.SetParent(parentGameObject.transform, true);

            // *=*=*=*=*=*=*=*=*=*=*=*=*=*=*
            // 複製体のscaleを調整
            cloneGameObject.transform.localScale = new(transform.localScale.x, 1f - textureScale / parentScale.y, transform.localScale.z);
            // 複製体のpositionを調整
            cloneGameObject.transform.localPosition = new(transform.localPosition.x,
                 cloneGameObject.transform.localScale.y / 2f,
                transform.localPosition.z);

            // *=*=*=*=*=*=*=*=*=*=*=*=*=*=*
            // 複製体のRendererを取得
            Renderer cloneRenderer = cloneGameObject.GetComponent<Renderer>();
            cloneRenderer.material = subMaterial;
            cloneRenderer.material.mainTexture.wrapMode = TextureWrapMode.Repeat;

            // *=*=*=*=*=*=*=*=*=*=*=*=*=*=*
            // 複製体のtextureのリピート回数調整
            float repeatTextureC = parentScale.y - textureScale;
            cloneRenderer.material.mainTextureScale = new Vector2(repeatScale.x * trueTextureScale, repeatTextureC * trueTextureScale);
            // テクスチャの開始位置を左上に設定する処理
            // 縦方向の繰り返し回数が整数でない場合に、テクスチャが切り取られないようにする
            cloneRenderer.material.mainTextureOffset = new Vector2(0f, 1f - (repeatTextureC * textureScale % 1f));
        }

        // *=*=*=*=*=*=*=*=*=*=*=*=*=*=*
        // 自身のtextureのリピート設定
        {
            // テクスチャの繰り返し回数を調整する
            renderer.material.mainTextureScale = new Vector2(repeatScale.x * trueTextureScale, repeatScale.y * trueTextureScale);
            // テクスチャの開始位置を左上に設定する処理
            // 縦方向の繰り返し回数が整数でない場合に、テクスチャが切り取られないようにする
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
