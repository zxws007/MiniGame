using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Washdrop : MonoBehaviour
{

    // Use this for initialization
    private Vector2 startPos;
    public static bool isFinished;

    public Bamai anniu1;
    // Use this for initialization
    private void Start()
    {
        startPos = transform.position;
        Bamai.my_longPressTime = 0.1f;
        anniu1.OnLongPress.AddListener(() =>
        {
            if (isFinished)
            {
                Zhizhen.begin = true;
            }
        });
    }

    private void OnMouseDrag()
    {

    }

    // Update is called once per frame
    private void OnMouseUp()
    {

    }
}
