using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaoPanding : MonoBehaviour
{
    public static bool success = false;
    public static bool lianghao = false;
    public static bool yiban = false;
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
    }
}
