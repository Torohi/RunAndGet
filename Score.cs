using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    private int distance;
    private int score=0;
    private int temp=0;
    int i;

    public static int score01=0;

    public Animator anm;

    public Text EggSco;
    public Text Dist;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        Vector3 pos=transform.position;
        int pp = (int)(pos.z);
        distance = pp;
        Dist.text = ""+pp;
        EggSco.text = ""+score;

        score01 = score;

        //score01 = score;
        //Debug.Log(score); //リプレイを押すとscoreは０になる


        /*
        for (i = 0; i < 10; i++)
        {
            if (array[i] == 0 && SaveScript.str!=null)
            {
                array[i] = Score.score01;
                str1[i] = SaveScript.str;
                //Debug.Log(i + " :今の" + str1[i] + "前の: "+str1[0]);

                break;
            }
        }

         */

        
  
    }
    
    void OnTriggerEnter(Collider hit)
    {
        anm.Play("Stay");

        if (hit.CompareTag("Item"))
        {
            score++;
            anm.Play("Big");
        }

    }
}
