using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestLightSensor : MonoBehaviour
{
    private AndroidJavaObject activityContext = null;
    private AndroidJavaObject jo = null;
    AndroidJavaClass activityClass = null;
    private float preluxval;
    private float curluxval;
    private float threshold = 100.0f;
    public Text text;
    // public Text luxtext;
    private int cnt = 400;
    private bool easymode = false;
    // Use this for initialization
    void Start()
    {
        activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
        jo = new AndroidJavaObject("com.xxww.minigame_android.MainActivity");
        jo.Call("init", activityContext);
        preluxval = getLux();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("GameManager").GetComponent<RunManager>().getIsGameOver())
        {
            text.text = "请将药材置于阴暗处";
            if (cnt <= 0)
            {
                text.text = "可以试着用手盖住整个屏幕";
                if (easymode == false)
                {
                    threshold = threshold / 2.0f;
                    easymode = true;
                }
            }
            curluxval = getLux();
            if (preluxval - curluxval >= threshold)
            {
                GameObject.Find("GameManager").GetComponent<RunManager>().setIsGameOver(true);
                GameObject.Find("GameManager").GetComponent<RunManager>().Gameover();
            }
            preluxval = curluxval;
            cnt--;
        }
    }
    public float getLux()
    {
        return jo.Call<float>("getLux");
    }
    public void setThreshold(float f)
    {
        threshold = f;
    }
}
