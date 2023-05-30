using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StageSelectInput;
using UnityEngine.UI;


public class SelectWorld : MonoBehaviour
{
    [Header("フェード用UIを渡す")]
    public Image fadeUI;
    [Header("音関連")]
    public AudioSource audioSource;
    public AudioClip seClip;
    [Header("カーソルの移動座標")]
    [SerializeField] Vector3[] ConstPos = new Vector3[5];
    [Header("ワールドマップを渡す")]
    public GameObject objWorldMap;
    [Header("カメラを渡す")]
    public GameObject objCamera;
    [Header("UIを渡す")]
    [SerializeField]　GameObject[] objUI;
    [Header("マップのチェックを渡す")]
    [SerializeField] GameObject[] objCheck;
    [Header("マップを渡す")]
    [SerializeField] GameObject[] objMAP;
    [Header("セーブデータを渡す")]
    public SaveData saveData;

    private StageSelectInput stInput;   // 入力情報を取得する関数
    private StickNaturalMove stickMove; // スティックを揺らすクラス
    
    // 現在選択しているワールドの数字を格納
    [System.NonSerialized] public int nowSelectWorld = 5;
    // 現在選択しているステージの数字を格納
    [System.NonSerialized] public int nowSelectStage = 0;

    int nClearDataW;    // 最後にクリアしたワールドを格納（ステージが5の場合＋１）
    int nClearDataS;    // 最後にクリアしたステージを格納


    [Header("カメラの移動で使う変数")]
    public float duration = 1f;     // 移動時間（秒）
    float count;                    // 経過時間を格納
    Vector3 startPos;               // カメラの初期座標を格納
    public Vector3 endPos;          // 移動先の座標
    Vector3 startAngle;             // カメラの初期角度を格納
    public Vector3 endAngle;        // 移動後の角度

    enum ST_MODE
    {
        WORLDSELECT,    // ワールドセレクト中
        CAMRAMOVE,      // カメラ移動中
        STAGESELECT,    // ステージセレクト中
    }
    // 現在の処理状況を格納
    ST_MODE stMode = ST_MODE.WORLDSELECT;
    [Header("フェードスピード")]
    public float fadeSpeed = 1;

    enum FADE
    {
        IN,
        OUT,
    }

    FADE fade = FADE.IN;

    void Start()
    {
        // 初期座標を代入
        transform.position = ConstPos[nowSelectWorld];
        // コンポーネント取得
        stInput = gameObject.GetComponent<StageSelectInput>();
        stickMove = gameObject.GetComponent<StickNaturalMove>();

        //stringデータを受け取る
        string　sClearData = saveData.GetString();

        // NULLの場合
        if (sClearData == null) nClearDataW = 1;
        else
        {
            // ワールド数を取得
            nClearDataW = int.Parse(sClearData.Substring(0, 1));
            // ステージ数を取得
            int nClearDataS = int.Parse(sClearData.Substring(2, 1));
            // 2-5の場合
            if (nClearDataS == 5) nClearDataW++;
        }

        nClearDataW--;
        nClearDataS--;
    }

    private void Awake()
    {
        nowSelectWorld = 0;
        startPos = objCamera.transform.position;
        startAngle = objCamera.transform.eulerAngles;
    }

    void Update()
    {
        // 入力情報を更新
        stInput.CheakInput();

        if (stMode == ST_MODE.WORLDSELECT) UpdateWSM();
        else if (stMode == ST_MODE.CAMRAMOVE)
        {
            // 現在の経過時間
            float elapsedTime = Time.time - count;

            // 経過時間を遷移時間で割り、0から1までの割合に変換
            float t = Mathf.Clamp01(elapsedTime / duration);

            // カメラを移動
            objCamera.transform.position = new(objCamera.transform.position.x,
                Mathf.Lerp(startPos.y, endPos.y, t),
                Mathf.Lerp(startPos.z, endPos.z, t));
            // カメラの回転
            objCamera.transform.eulerAngles = new(Mathf.Lerp(startAngle.x, endAngle.x, t),
                Mathf.Lerp(startAngle.y, endAngle.y, t),
                Mathf.Lerp(startAngle.z, endAngle.z, t));

            if (fade == FADE.IN)
            {
                Color color = fadeUI.color;
                color.a += Time.deltaTime * fadeSpeed;
                fadeUI.color = color;

                if (color.a > 1)
                {
                    color.a = 1;
                    fade = FADE.OUT;
                    // *=*=*=*=*=**=*=*=***=***=*=*==*=**=*=*===*=**=*==*==*=*
                    // 画像を切り替え
                    // チェックマークをすべて消す
                    for (int i = 0; i < objCheck.Length; i++) objCheck[i].SetActive(false);
                    objWorldMap.SetActive(false);   // ワールドマップを消す
                    // 選択ワールドをアクティブ化
                    objMAP[nowSelectWorld].SetActive(true);
                }
            }
            else if (fade == FADE.OUT)
            {
                Color color = fadeUI.color;
                color.a -= Time.deltaTime * fadeSpeed;
                fadeUI.color = color;

                if (color.a < 0) color.a = 0;
            }

            // カメラの遷移終了
            if (t == 1) stMode = ST_MODE.STAGESELECT;
        }
        else if (stMode == ST_MODE.STAGESELECT)
        {

        }

        




        UpdateUI(); // ワールドUI更新関数
    }

    // UIを更新する関数
    void UpdateUI()
    {
        // すべてのUIを非アクティブ化
        for (int i = 0;i < objUI.Length; i++) objUI[i].SetActive(false);
        // 選択中のワールドUI 
        objUI[nowSelectWorld].SetActive(true);
    }

    void UpdateWSM()
    {
        // プラス方向に入力された
        if (stInput.isBottom == IsInputBottom.STICK_H_P)
        {
            nowSelectWorld += 1;
            // ワールド選択で端っこに行った場合
            if (nowSelectWorld > 4) nowSelectWorld = 0;
            // 選択できないワールドに移動しようとしているなら
            if (nClearDataW < nowSelectWorld) nowSelectWorld -= 1;
            else audioSource.PlayOneShot(seClip);
        }
        // マイナス方向に入力された
        else if (stInput.isBottom == IsInputBottom.STICK_H_N)
        {
            nowSelectWorld -= 1;
            // ワールド選択で端っこに行った場合
            if (nowSelectWorld < 0) nowSelectWorld = 4;
            // 選択できないワールドに移動しようとしているなら
            if (nClearDataW < nowSelectWorld) nowSelectWorld = 0;
            else audioSource.PlayOneShot(seClip);
        }
        else if (stInput.isBottom == IsInputBottom.A)
        {
            stMode = ST_MODE.CAMRAMOVE;
            count = Time.time;
            // *=*=*=*=*=*=*=*=*=***=*=**=*=*=*=*=*=*=*=**=*
            // ココに選択SEを鳴らす関数を追加する
            // *=*=*=*=**=*=**=*=**==****=****=**=*****=***=
        }

        // 枝の位置を選択位置へ移動
        transform.position = ConstPos[nowSelectWorld];
        // スティックを上下に揺らす関数
        stickMove.MoveStick();
    }
}