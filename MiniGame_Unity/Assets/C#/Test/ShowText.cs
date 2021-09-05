using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    void Awake()
    {
        gameObject.SetActive(false);
        //EventCenter.AddListener(EventType.ShowText, Show);
        //EventCenter.AddListener<string>(EventType.ShowText, Show);
        EventCenter.AddListener<string, string, float, int, double>(EventType.ShowText, Show);
    }
    void OnDestroy()
    {
        //EventCenter.RemoveListener(EventType.ShowText, Show);
        //EventCenter.RemoveListener<string>(EventType.ShowText, Show);
        EventCenter.RemoveListener<string, string, float, int, double>(EventType.ShowText, Show);
    }
    private void Show(string msg0, string msg1, float msg2, int msg3, double msg4)
    {
        gameObject.SetActive(true);
        GetComponent<Text>().text = msg0 + msg1 + msg2 + msg3 + msg4;
    }

}
