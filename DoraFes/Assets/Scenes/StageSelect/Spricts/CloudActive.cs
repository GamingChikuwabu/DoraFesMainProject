using UnityEngine;

public class CloudActive : MonoBehaviour
{

    [SerializeField] private Transform[] cloud;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform p in cloud)
        {
            p.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // StageSelectスプリクトから取得し代入
        StageSelect.STAGENAME mapNum = StageSelect.MapState;

        switch (mapNum)
        {
            case StageSelect.STAGENAME.MAP1:

                cloud[0].gameObject.SetActive(true);
                cloud[1].gameObject.SetActive(true);
                cloud[2].gameObject.SetActive(true);
                cloud[3].gameObject.SetActive(true);

                break;

            case StageSelect.STAGENAME.MAP2:

                cloud[0].gameObject.SetActive(false);

                cloud[1].gameObject.SetActive(true);
                cloud[2].gameObject.SetActive(true);
                cloud[3].gameObject.SetActive(true);

                break;

            case StageSelect.STAGENAME.MAP3:

                cloud[0].gameObject.SetActive(false);
                cloud[1].gameObject.SetActive(false);

                cloud[2].gameObject.SetActive(true);
                cloud[3].gameObject.SetActive(true);

                break;

            case StageSelect.STAGENAME.MAP4:

                cloud[0].gameObject.SetActive(false);
                cloud[1].gameObject.SetActive(false);
                cloud[2].gameObject.SetActive(false);

                cloud[3].gameObject.SetActive(true);

                break;

            case StageSelect.STAGENAME.MAP5:

                cloud[0].gameObject.SetActive(false);
                cloud[1].gameObject.SetActive(false);
                cloud[2].gameObject.SetActive(false);
                cloud[3].gameObject.SetActive(false);

                break;
        }
    }
}
