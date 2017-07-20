using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetSea : MonoBehaviour {
    
    int CountPlayer = 0;
    int CountSea = 748;

    public GameObject SeaPrefab;
    public Transform Player;
    public List<GameObject> OldSeaList = new List<GameObject>();
	
	void Update () {
        int CharacterPosition = (int)(Player.position.z);
        if (CharacterPosition == 374+374*CountPlayer) //プレイヤーのz軸,374ごとにSeaをセット
        {
            Set();
        }
	}

    
    void Set() //ステージ生成
    {
        CountPlayer++;
        CountSea += 374;
        GameObject Stage = (GameObject)Instantiate(SeaPrefab, transform.position = new Vector3(0, 0, CountSea), Quaternion.identity);
        OldSeaList.Add(Stage);
        DestroyOldStage();
    }

    void DestroyOldStage() //古いステージを破棄
    {
        GameObject oldStage = OldSeaList[0];
        OldSeaList.RemoveAt(0);
        Destroy(oldStage);
    }
}
