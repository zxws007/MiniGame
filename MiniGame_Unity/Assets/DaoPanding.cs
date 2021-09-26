using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaoPanding : MonoBehaviour
{
    public static bool success = false;
    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            success = true;
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            success = false;
        }
    }
    void Update()
    {

    }
}
