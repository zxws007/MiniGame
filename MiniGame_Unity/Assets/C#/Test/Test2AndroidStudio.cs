using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2AndroidStudio : MonoBehaviour
{
    private AndroidJavaObject javaObject;

    void Start()
    {
        AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        if (null != androidJavaClass)
        {
            javaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
        }
    }
    public void OnClick()
    {
        if (null != javaObject)
        {
            javaObject.Call("Unity2Android", "xxww success!");
        }
    }
}
