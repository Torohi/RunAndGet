using UnityEngine;
using System.Collections;

public class EggSound : MonoBehaviour
{
    AudioSource se;
    //public float PitchF = 1.0f;
    private float PitchTemp = 0.01f;
    public float PitchSec = 0.0f;
      
    void Start()
    {
        se = GetComponent<AudioSource>();
    }

    void Update()
    {
        PitchSec += Time.deltaTime;

        if (PitchSec >= 0.3f) //卵に0.3秒以上触れていないと、ピッチが元に戻る
        {
            se.pitch = 1.0f;
        }

    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag=="Item")
        {
            if (se.pitch >= 1.1f) 
            {
                se.pitch = 1.0f;
            }
            else
            {
                se.pitch += PitchTemp;
            }
            
            se.PlayOneShot(se.clip);
            PitchSec = 0.0f;

        }
    }
}
