using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScore : MonoBehaviour
{
    public static GlobalScore Instance = new GlobalScore();
    public int Score1;
    public int Score2;
    public int Score3;
    public int wanmei;
    public int lianghao;
    public int yiban;
    public string username;
    void Awake()
    {
        if (Instance == null)
        {
            this.Score1 = 0;
            this.Score2 = 0;
            this.Score3 = 0;
            this.wanmei = 0;
            this.lianghao = 0;
            this.yiban = 0;
            this.username = "";
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
