using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScore : MonoBehaviour
{
    public static GlobalScore Instance = new GlobalScore();
    public int Score1;
    public int Score2;
    public int Score3;
    void Awake()
    {
        if (Instance == null)
        {
            this.Score1 = 0;
            this.Score2 = 0;
            this.Score3 = 0;
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
