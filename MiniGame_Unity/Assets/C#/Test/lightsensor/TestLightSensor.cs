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
    private bool flag;
    private bool slideflag;
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
        flag = false;
        slideflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag==false && !GameObject.Find("GameManager").GetComponent<RunManager>().getIsGameOver())
        {
            time += Time.deltaTime;
            popbottle.SetActive(true);
            if (easymode == false)
            {
                text.text = "请将药材置于阴暗处";
            }
            if (time > 2.0f)
            {
                text.text = "试着用手盖住整个屏幕";
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
                    slidetext.SetActive(true);
                    slide.SetActive(true);
                    slideflag = true;
                }           
                if (slide.GetComponent<Slider>().value < slide.GetComponent<Slider>().maxValue)
                {
                    slide.GetComponent<Slider>().value += 1f;
                }
                else
                {
                    flag = true;
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
