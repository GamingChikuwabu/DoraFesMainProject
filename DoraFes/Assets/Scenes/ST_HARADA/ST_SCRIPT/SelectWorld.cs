using UnityEngine;
using static StageSelectInput;
using UnityEngine.UI;


public class SelectWorld : MonoBehaviour
{
    // =*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=
    // まさよし
    // ロードシーン用のオブジェクトを取ってくる
    private GameObject LoadSceneObject;
    private LoadScene LS;

    // リトライするシーン名を取ってくる
    private GameObject RetrySceneObject;
    //private SetSceneName SNS;
    // =*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=

    [Header("フェード用UIを渡す")]
    public Image fadeUI;
    [Header("音関連")]
    public AudioSource audioSource;
    public AudioClip seClip;    // 移動音
    public AudioClip seClip02;  // 拒否音
    public AudioClip seClip03;  // 決定音
    public AudioClip seClip04;  // ワールド移動音
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
    [Header("ステージアイコンを渡す")]
    [SerializeField] GameObject[] objStage;
    [Header("セーブデータを渡す")]
    public SaveData saveData;

    private StageSelectInput stInput;   // 入力情報を取得する関数
    private StickNaturalMove stickMove; // スティックを揺らすクラス
    
    // 現在選択しているワールドの数字を格納
    [System.NonSerialized] public int nowSelectWorld = 1;
    // 現在選択しているステージの数字を格納
    [System.NonSerialized] public int nowSelectStage = 1;

    int nClearDataW = 0;    // 最後にクリアしたワールドを格納（ステージが4の場合＋１）
    int nClearDataS = 0;    // 最後にクリアしたステージを格納


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
        FADEOUT,        // フェードアウト中
    }
    // 現在の処理状況を格納
    ST_MODE stMode = ST_MODE.WORLDSELECT;
    [Header("フェードスピード")]
    public float fadeSpeed = 1;
    public float fadeSpeed02 = 1;

    enum FADE
    {
        IN,
        OUT,
    }

    FADE fade = FADE.IN;

    // Iconの初期座標を格納
    Vector3[] iconPos = new Vector3[5 * 4]; // ココだけ変更（ステージ数の変更の場合）
    [Header("アイコン関連")]
    public float moveSpeed = 0.5f;
    public float movePow = 2;
    int stageNum = 4;        // ステージ数;

    void Start()
    {
        // =*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=
        // まさよし
        // LoadSceneスクリプトの変数を取ってくる
        //LoadSceneObject = GameObject.Find("LoadScene");
        //LS = LoadSceneObject.GetComponent<LoadScene>();

        //// リトライするシーン名を取ってくる
        //RetrySceneObject = GameObject.Find("RetryScene");
        //SNS = RetrySceneObject.GetComponent<SetSceneName>();
        // =*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=


        // 初期座標を代入
        transform.position = ConstPos[nowSelectWorld - 1];
        // コンポーネント取得
        stInput = gameObject.GetComponent<StageSelectInput>();
        stickMove = gameObject.GetComponent<StickNaturalMove>();

        // stringデータを受け取る
        string　sClearData = saveData.GetString();

        // NULLの場合
        if (sClearData == "")
        {
            nClearDataW = 1;
            nClearDataS = 0;
        }
        else
        {
            // ワールド数を取得
            nClearDataW = int.Parse(sClearData.Substring(0, 1));
            // ステージ数を取得
            nClearDataS = int.Parse(sClearData.Substring(2, 1));
            // ~-4の場合
            if (nClearDataS == stageNum)
            {
                nClearDataW++;
                nClearDataS = 0;
            }
        }

        nClearDataS++;

        // ワールド数分回す
        for (int i = 0; i < 5; i++)
        {
            // ステージ数分回す
            for (int j = 0; j < stageNum; j++)
            {
                if ((nClearDataW - 1) * stageNum + nClearDataS - 1 < i * stageNum + j)
                {
                    Material material = objStage[i * stageNum + j].GetComponent<Renderer>().material;
                    material.DisableKeyword("_EMISSION");// 放射を無効化
                }
            }
        }

        // iconの初期座標を格納
        for (int i = 0; i < 5 * stageNum; i++)
        {
            iconPos[i] = objStage[i].transform.localPosition;
        }
            
    }

    private void Awake()
    {
        startPos = objCamera.transform.position;
        startAngle = objCamera.transform.eulerAngles;
    }

    void Update()
    {
        // 入力情報を更新
        stInput.CheakInput();

        if (stMode == ST_MODE.WORLDSELECT) UpdateWSM();
        else if (stMode == ST_MODE.CAMRAMOVE) UpdateCMM();
        else if (stMode == ST_MODE.STAGESELECT) UpdateSSM();
        else if (stMode == ST_MODE.FADEOUT)
        {
            Color color = fadeUI.color;
            color.a += Time.deltaTime * fadeSpeed02;
            fadeUI.color = color;

            if (color.a > 1)
            {
                // ココに入れる
                string stage = nowSelectWorld + "-" + nowSelectStage;

                // =*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=
                // まさよし
                //LS.SetLoadName(stage);
                //SNS.SetRetrySceneName(stage);
                // =*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=


            }
        }

        UpdateUI(); // ワールドUI更新関数
    }



    // UIを更新する関数
    void UpdateUI()
    {
        // すべてのUIを非アクティブ化
        for (int i = 0;i < objUI.Length; i++) objUI[i].SetActive(false);
        // 選択中のワールドUI 
        objUI[(nowSelectWorld - 1)].SetActive(true);
    }

    // ワールドセレクトモードの更新関数
    void UpdateWSM()
    {
        for (int i = 0; i < 5; i++)
        {
            objCheck[i].SetActive(false);
        }
        

        // プラス方向に入力された
        if (stInput.isBottom == IsInputBottom.STICK_H_P)
        {
            nowSelectWorld += 1;
            // ワールド選択で端っこに行った場合
            if (nowSelectWorld > 5) nowSelectWorld = 1;
            // 選択できないワールドに移動しようとしているなら
            if (nClearDataW < nowSelectWorld)
            {
                nowSelectWorld -= 1;
                audioSource.PlayOneShot(seClip02);
            }
            else audioSource.PlayOneShot(seClip);
        }
        // マイナス方向に入力された
        else if (stInput.isBottom == IsInputBottom.STICK_H_N)
        {
            nowSelectWorld -= 1;
            // ワールド選択で端っこに行った場合
            if (nowSelectWorld < 1) nowSelectWorld = 5;
            // 選択できないワールドに移動しようとしているなら
            if (nClearDataW < nowSelectWorld)
            {
                nowSelectWorld = 1;
                audioSource.PlayOneShot(seClip02);
            }
            else audioSource.PlayOneShot(seClip);
        }
        else if (stInput.isBottom == IsInputBottom.A)
        {
            stMode = ST_MODE.CAMRAMOVE;
            count = Time.time;
            // メッシュレンダラーを無効化する
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            audioSource.PlayOneShot(seClip03);
        }

        objCheck[nowSelectWorld - 1].SetActive(true);

        // 枝の位置を選択位置へ移動
        transform.position = ConstPos[(nowSelectWorld - 1)];
        // スティックを上下に揺らす関数
        stickMove.MoveStick();
    }

    // カメラムーブモードの更新関数
    void UpdateCMM()
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
                // チェックマークをすべて消す
                for (int i = 0; i < objCheck.Length; i++) objCheck[i].SetActive(false);
                objWorldMap.SetActive(false);// ワールドマップを消す

                // 選択ワールドをアクティブ化
                objMAP[(nowSelectWorld - 1)].SetActive(true);
                // ステージアイコンをアクティブ化
                for (int i = 0; i < stageNum; i++) objStage[(nowSelectWorld - 1) * stageNum + i].SetActive(true);
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

    // フェードアウトモードの更新関数
    void UpdateSSM()
    {
        // 選択ワールドを非アクティブ化
        objMAP[(nowSelectWorld - 1)].SetActive(false);
        // ステージアイコンを非アクティブ化
        for (int i = 0; i < stageNum; i++) objStage[(nowSelectWorld - 1) * stageNum + i].SetActive(false);

        // プラス方向に入力された
        if (stInput.isBottom == IsInputBottom.R)
        {
            nowSelectWorld += 1;
            // ワールド選択で端っこに行った場合
            if (nowSelectWorld > 5) nowSelectWorld = 1;
            // 選択できないワールドに移動しようとしているなら
            if (nClearDataW < nowSelectWorld)
            {
                nowSelectWorld -= 1;
                audioSource.PlayOneShot(seClip02);
            }
            else
            {
                nowSelectStage = 1;
                audioSource.PlayOneShot(seClip04);
            }
        }
        // マイナス方向に入力された
        else if (stInput.isBottom == IsInputBottom.L)
        {
            nowSelectWorld -= 1;
            // ワールド選択で端っこに行った場合
            if (nowSelectWorld < 1) nowSelectWorld = 5;
            // 選択できないワールドに移動しようとしているなら
            if (nClearDataW < nowSelectWorld)
            {
                nowSelectWorld = 1;
                audioSource.PlayOneShot(seClip02);
            }
            else
            {
                nowSelectStage = 1;
                audioSource.PlayOneShot(seClip04);
            }
        }
        else if (stInput.isBottom == IsInputBottom.STICK_H_P)
        {
            nowSelectStage++;

            // 進めないステージに移動しようとした
            if ((nClearDataW - 1) * stageNum + nClearDataS - 1 < (nowSelectWorld - 1) * stageNum + nowSelectStage - 1)
            {
                nowSelectStage--;
                audioSource.PlayOneShot(seClip02);
            }
            else
            {
                // ステージがマックスを超えたら
                if (nowSelectStage > stageNum)
                {
                    nowSelectStage = 1;
                    nowSelectWorld++;
                    audioSource.PlayOneShot(seClip04);
                }
                else
                {
                    audioSource.PlayOneShot(seClip);
                }
            }
        }
        else if (stInput.isBottom == IsInputBottom.STICK_H_N)
        {
            nowSelectStage--;

            // 進めないステージに移動しようとした
            if (1 > (nowSelectWorld - 1) * stageNum + nowSelectStage)
            {
                nowSelectStage++;
                audioSource.PlayOneShot(seClip02);
            }
            else
            {
                // ステージがマックスを超えたら
                if (nowSelectStage < 1)
                {
                    nowSelectStage = stageNum;
                    nowSelectWorld--;
                    audioSource.PlayOneShot(seClip04);
                }
                else
                {
                    audioSource.PlayOneShot(seClip);
                }
            }
        }
        else if (stInput.isBottom == IsInputBottom.A)
        {
            stMode = ST_MODE.FADEOUT;
        }

        // 選択ワールドをアクティブ化
        objMAP[(nowSelectWorld - 1)].SetActive(true);
        // ステージアイコンをアクティブ化
        for (int i = 0; i < stageNum; i++) objStage[(nowSelectWorld - 1) * stageNum + i].SetActive(true);

        // 座標位置を元に戻す
        for (int i = 0; i < stageNum; i++)
        {
            objStage[(nowSelectWorld - 1) * stageNum + nowSelectStage - 1].transform.localPosition = new(
                iconPos[(nowSelectWorld - 1) * stageNum + nowSelectStage - 1].x,
                iconPos[(nowSelectWorld - 1) * stageNum + nowSelectStage - 1].y,
                iconPos[(nowSelectWorld - 1) * stageNum + nowSelectStage - 1].z);
        }

        // 選択中のアイコンを揺らす
        objStage[(nowSelectWorld - 1) * stageNum + nowSelectStage - 1].transform.localPosition = new(
                iconPos[(nowSelectWorld - 1) * stageNum + nowSelectStage - 1].x,
                iconPos[(nowSelectWorld - 1) * stageNum + nowSelectStage - 1].y + Mathf.Sin(Time.time * moveSpeed) * movePow,
                iconPos[(nowSelectWorld - 1) * stageNum + nowSelectStage - 1].z);
    }
}