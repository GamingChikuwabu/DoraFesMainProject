using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CI.QuickSave;

public class SaveData : MonoBehaviour
{
    public void Save(string name,Vector3 position)
    {
        //QuickSaveWriterのインスタンスを作成
        QuickSaveWriter writer = QuickSaveWriter.Create("Player");
        //データを書き込む
        writer.Write("name",name);
        writer.Write("Position",position);
        writer.Write("mandoranum",30);
        //変更を反映
        writer.Commit();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
