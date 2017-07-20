using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RankScore : MonoBehaviour {

    public Text[] scText;
    static int[] array = new int[10];
    static string[] str1 = new string[10];
    static int i;

    void Start()
    {
        /*
        if(SaveScript.str == null)
        {
            Debug.Log("文字列は空");
        }else
        {
            Debug.Log("文字列は空ではない");
        }*/
        
     
     for (i = 0; i < 10; i++)
     {
         if (array[i] == 0 && SaveScript.str!=null)
         {
             array[i] = Score.score01;
             str1[i] = SaveScript.str;
             SaveScript.str = null;
             Debug.Log(i + " :今の" + str1[i] + "前の: "+str1[0]);

             break;
         }
     }

        for (i = 0; i < 10; i++)
        {
            //scText[i].text = (i+1)+"人目:" + str1[i] +"  "+ array[i];
            scText[i].text = (i+1)+"人目: " +str1[i]+"  "+ array[i];

        }
    }
}


