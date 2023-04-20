using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTextureRepeat : MonoBehaviour
{
    void Start()
    {
        float textureScale = 1f / transform.parent.GetComponent<BlockManager>().textureScale;

        // Rendererコンポーネントを取得する
        Renderer renderer = GetComponent<Renderer>();
        // テクスチャの繰り返しモードを "Repeat" に設定する
        renderer.material.mainTexture.wrapMode = TextureWrapMode.Repeat;
        // 親オブジェクトのスケールを取得
        Vector3 parentScale = transform.parent.transform.localScale;
        // textureのリピートに使用するスケール
        Vector3 scale = parentScale;
        // 縦方向のスケール
        renderer.material.mainTextureScale = new Vector2(scale.x * textureScale, scale.z * textureScale);
    }
}
