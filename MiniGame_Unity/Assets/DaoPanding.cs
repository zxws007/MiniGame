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
    public Animator yaocai;
    public Animator tiao;
    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            success = true;
        }
        if (coll.gameObject.tag == "Finish")
        {
            lianghao = true;
        }
        if (coll.gameObject.tag == "Respawn")
        {
            yiban = true;
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
            }
            else if (MoveY.totleScore >= 32 && MoveY.totleScore < 40)
            {
                dengji = "A";
            }
            else if (MoveY.totleScore >= 20 && MoveY.totleScore < 32)
            {
                dengji = "C";
            }
            pingji.text = "评级：" + dengji;
            jiesuan.SetActive(true);
            yaocai.speed = 0;
            tiao.speed = 0;
        }
    }
}
