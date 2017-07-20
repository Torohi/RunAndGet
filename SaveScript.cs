using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveScript : MonoBehaviour {

    public static string str;
    public InputField InputField;

    public void SaveText()
    {
        str = InputField.text;
    }

}
