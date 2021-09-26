using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScore : MonoBehaviour {
    public static GlobalScore Instance;
    public int Score;

    void Awake()
    {
        if (Instance == null)
        {
            this.Score = 0;
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }    
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

}
