using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaoPanding : MonoBehaviour
{
    public static bool success = false;
    public static bool lianghao = false;
    public static bool yiban = false;
    public Text pingji;
    string dengji = "";
    public GameObject jiesuan;
    public GameObject jiesuan1;
    public GameObject jiesuan2;
    public Animator yaocai;
    public Animator tiao;
    void Start()
    {
        MoveY.qiesidao = 0;
        MoveY.totleScore = 0;
        success = false;
        lianghao = false;
        yiban = false;
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            success = true;
            lianghao = false;
            yiban = false;
        }
        if (coll.gameObject.tag == "Finish")
        {
            lianghao = true;
            success = false;
            yiban = false;
        }
        if (coll.gameObject.tag == "Respawn")
        {
            yiban = true;
            success = false;
            lianghao = false;
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            success = false;
        }
        if (coll.gameObject.tag == "Finish")
        {
            lianghao = false;
        }
        if (coll.gameObject.tag == "Respawn")
        {
            yiban = false;
        }
    }
    void Update()
    {
        if (MoveY.qiesidao == 4)
        {
            if (MoveY.totleScore == 40)
            {
                dengji = "S";
                jiesuan.SetActive(true);
            }
            else if (MoveY.totleScore >= 32 && MoveY.totleScore < 40)
            {
                dengji = "A";
                jiesuan1.SetActive(true);
            }
            else if (MoveY.totleScore >= 20 && MoveY.totleScore < 32)
            {
                dengji = "C";
                jiesuan2.SetActive(true);
            }
            pingji.text = "评级：" + dengji;
            yaocai.speed = 0;
            tiao.speed = 0;
        }
    }
}
