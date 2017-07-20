using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//----------------------------------ステージセット参考用（ネジ子よりコピペ P224,225）---------------------------------------------------------

public class SetStage : MonoBehaviour {

    const int StageTipsize = 30;
    int currentTipIndex;

    public Transform character;
    public GameObject[] stageTips;
    public int startTipIndex;
    public int preInstantiate;
    public List<GameObject> generatedStageList = new List<GameObject>();

    void Start()
    {
        currentTipIndex =startTipIndex-1;
        UpdateStage(preInstantiate);
    }

    void Update()
    {
        //キャラクターの位置から現在のステージチップのインデックスを計算
        int charaPositionIndex = (int)(character.position.z / StageTipsize);
        //次のステージチップに入ったらステージの更新処理を行う
        if (charaPositionIndex + preInstantiate < currentTipIndex)
        {
            UpdateStage(charaPositionIndex + preInstantiate);
        }
    }
    //指定のIndexまでのステージチップを生成して、管理下に置く
    void UpdateStage(int toTipIndex)
    {
        if (toTipIndex <= currentTipIndex) return;
        //指定のステージチップまでを作成
        for(int i = currentTipIndex + 1; i <= toTipIndex; i++)
        {
            GameObject stageObject = GenerateStege(i);
            //生成したステージチップを管理リストに追加し
            generatedStageList.Add(stageObject);
            //ステージ保持上上限になるまで古いステージを削除
            while (generatedStageList.Count > preInstantiate + 2) DestroyOldStage();

            currentTipIndex = toTipIndex;
        }
    }
    //指定のインデックス位置にStageオブジェクトをランダムに生成
    GameObject GenerateStege(int tipIndex)
    {
        int nextStageTip = Random.Range(0, stageTips.Length);

        GameObject stageObject = (GameObject)Instantiate(stageTips[nextStageTip], new Vector3(0, 0, tipIndex * StageTipsize), Quaternion.identity);
        return stageObject;
    }
   //一番古いステージを削除
   void DestroyOldStage()
    {
        GameObject oldstage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldstage);
    }

}
