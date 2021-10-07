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
    private float threshold;
    public GameObject slidetext;
    public Text text;
    public GameObject slide;
    // public Text luxtext;
    private float time;
    private float slidetime; 
    public GameObject popbottle;
    private bool easymode;
    private bool slideflag;
    private bool settextonce = false;
    // Use this for initialization
    void Start()
    {
        activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
        jo = new AndroidJavaObject("com.xxww.minigame_android.MainActivity");
        jo.Call("init", activityContext);
        preluxval = getLux();
        threshold = 1000;
        time = .0f;
        slidetime = .0f;
        slide.GetComponent<Slider>().maxValue = 100f;
        slide.GetComponent<Slider>().minValue = .0f;
        easymode = false;
        slideflag = false;
        popbottle.SetActive(true);
        text.text = "请将药材置于阴暗处";
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("GameManager").GetComponent<RunManager>().getIsGameOver())
        {
            time += Time.deltaTime;
            if (time > 3.0f)
            {
                if (!settextonce)
                {
                    text.text = "试着用手盖住整个屏幕";
                    settextonce = true;
                }
                time=.0f;
                threshold = threshold / 2.0f;
                easymode = true;
            }
           curluxval = getLux();
            //光感计算
            if (slideflag || preluxval - curluxval >= threshold)
            {
                if (slideflag == false)
                {
                    popbottle.SetActive(false);
                    text.text = " ";
                    slidetext.SetActive(true);
                    slide.SetActive(true);
                    slideflag = true;
                }           
                if (slide.GetComponent<Slider>().value < slide.GetComponent<Slider>().maxValue)
                {
                    slide.GetComponent<Slider>().value += 1f;
                }else
                {
                    popbottle.SetActive(true);
                    text.text = "润药成功";
                    GameObject.Find("GameManager").GetComponent<RunManager>().setIsGameOver(true);
                    GameObject.Find("GameManager").GetComponent<RunManager>().Gameover();
                }
            }
            preluxval = curluxval;
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
