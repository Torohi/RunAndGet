using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OutputScore : MonoBehaviour {

    public Text GameScore;

    void Start()
    {
        GameScore.text = "Score: " + Score.score01;
    }
}
