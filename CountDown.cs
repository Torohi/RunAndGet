using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDown : MonoBehaviour {

    public Text Count;
    public  float tim01;

	void Update () {
        tim01 +=Time.deltaTime;

        if (tim01 <= 1.5)
        {
            Count.text = "" + 3;
        }else if (tim01 <=2.5)
        {
            Count.text = "" + 2;
        }else if (tim01 <= 3.5)
        {
            Count.text = "" + 1;
        }else if (tim01 <=4.5)
        {
            Count.text = "";
        }
        
        
	}
}
