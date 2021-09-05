using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnClick : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            //EventCenter.BroadCast(EventType.ShowText);
            EventCenter.BroadCast(EventType.ShowText, "xxww success!", "aa", .1f, 1, .2d);
        });
    }
}
