using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stage : MonoBehaviour {
    int CountPlayer = 0;
    int CountStage = 450;
    
    public GameObject[] StagePrefab;  //自動生成するプレファブをセット
    public Transform Player;        //プレイヤーの座標を必要とするためプレイヤーをセット
    public List<GameObject> OldStageList = new List<GameObject>(); //ここには、作られ、破棄されるオブジェクトが自動追加される

    void Update()
    {
        //Vector3 pos = Player.transform.position;
        int CharacterPosition = (int)(Player.position.z);
        if (CharacterPosition == 80+150*CountPlayer)
        {
            Set();
        }
    }

     public void Set() //ステージ生成
    {
        CountPlayer++;
        CountStage += 150;
        int nextStage = Random.Range(0, StagePrefab.Length);
        GameObject Stage = (GameObject)Instantiate(StagePrefab[nextStage], transform.position = new Vector3(0, 0, CountStage), Quaternion.identity);
        OldStageList.Add(Stage);
        DestroyOldStage();
        }

    void DestroyOldStage() //古いステージを破棄
    {
        GameObject oldStage = OldStageList[0];
        OldStageList.RemoveAt(0);
        Destroy(oldStage);
    }
}