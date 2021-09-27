using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dis : MonoBehaviour
{

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "dis")
        {
            Destroy(gameObject);
        }
    }
}
