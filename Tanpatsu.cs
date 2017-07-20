using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//フリックゲームのプレイヤーコントロールスクリプト

public class Tanpatsu : MonoBehaviour
{
    public float speed;  
    public int right;
    public float left;
    public float jump;

    public float tim02;
    public float tt;
    public float gameoverTime;

    private Rigidbody rb;
    private Animator ani;

    public GameObject GameOverLavel;
    public GameObject BGM;


    void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        
    }
   
    void Update()
    {
        tim02 += Time.deltaTime;
        if (tim02 >= 3.5)
        {
            transform.Translate(0, 0, speed); //なにもしなくてもｚ座標向きに進み続ける

            //Vector3 pos = transform.position;
            //if (pos.x >= 0.1f || pos.x <= 0.1f) pos.x = 0;

            if (Input.GetKeyDown(KeyCode.RightArrow)) Right();  //左キーを押すとRight()関数を呼び出す

            if (Input.GetKeyDown(KeyCode.LeftArrow)) Left(); //右キーを押すとLeft()関数を呼び出す 

            if (Input.GetKeyDown(KeyCode.UpArrow)) //上キーを押すと
            {
                ani.SetBool("Jump", true);
                rb.AddForce(Vector3.up * jump);
            }
            else
            {
                ani.SetBool("Jump", false);
            }
            if (speed == 0)
            {
                gameoverTime += Time.deltaTime;
                Debug.Log(gameoverTime);
                if (gameoverTime > 2.0f)
                {
                    GameOverLavel.SetActive(true);

                }
            }
            /*
            if (jump == 0) //jump=0つまり、Enemyにぶつかったら
            {
                tt += Time.deltaTime;
                if (tt >= 2.0) 
                {
                    GameOverLavel.SetActive(true);
                }
            }*/
        }
    }

    void Right()
    {
        Vector3 pos = transform.position; //transform.positionを変数として扱えるようにする?

        if (pos.x ==0 || pos.x == -1)  //右キーを押したとき、x座標が0,または-1の時はx座標を＋1する
        {
            transform.Translate(right, 0, 0);
        }
        else { }                       //そうでなければ（x座標が1だったら）処理は行わない
    }

    void Left()
    {
        Vector3 pos = transform.position; //transform.positionを変数として扱えるようにする?

        if (pos.x == 0 || pos.x == 1) //左キーを押したとき、ｘ座標が0,または1の時はｘ座標を-1する
        {
            transform.Translate(left, 0, 0);
        }
        else { }                     //そうでなければ（x座標が-1だったら）処理は行わない
    }

    //トリガーとの接触時に呼ばれるコールバック
    void OnTriggerEnter(Collider hit) //ぶつかる対象物のIsTriggerをオンにすると効果を発揮
    {                 
        if (hit.CompareTag("Enemy"))        //接触対象はEnemyタグですか？
        {

            speed = 0;         //ぶつかった場所でプレイヤーを止める
            jump = 0;
            right = 0;
            left = 0;
            
            ani.SetBool("Down", true);     //倒れるアニメーションをオンにする
            ani.SetBool("Run", false);
            BGM.SetActive(false);          //BGMを止める

            




        }

        if (hit.CompareTag("BigJump"))
        {
            rb.AddForce(Vector3.up*jump*3);
        }

    }



    void OnCollisionStay() //地面に付いているとき
    {
        if (tim02 >= 3.5)
        {
            if (ani.GetCurrentAnimatorStateInfo(0).IsName("Down") == true) //Downアニメーションが再生されているとき
            {
                jump = 0;
            }
            else
            {
                ani.Play("Run"); //Runアニメーションを再生

                jump = 300;
            }
        }else
        {
            ani.Play("Stand");
        }
    }

    void OnCollisionExit() //地面から離れたとき
    {
        jump = 0;
    }


}