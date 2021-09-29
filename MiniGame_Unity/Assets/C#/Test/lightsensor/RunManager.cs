﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RunManager : MonoBehaviour
{
    private bool herbready = false;
    private bool clothready = false;
    private bool bottleready = false;
    private bool isover = false;
    private bool isGameOver = false;
    private bool qteactive = false;
    public GameObject ClothEnd;
    public GameObject QTEslice;
    public GameObject QTE;
    public Text txt;
    private Camera mainCamera;
    public GameObject lux;
    // Use this for initialization
    float time = .0f;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);

        if (bottleready == true&&qteactive==false&&mousePos.x>1700&&mousePos.y<700)
        {
            if (Input.GetMouseButton(0))
            {
                time += Time.deltaTime;
                if (time > 1.0f)
                {
                    txt.text = " ";
                    QTE.SetActive(true);
                    QTEslice.SetActive(true);
                    qteactive = true;
                }
            }
        }
        //if (Input.GetMouseButton(0))
        //{
        //    time += Time.deltaTime;
        //    Debug.Log(time);
        //}

        if (isover == true)
        {
            lux.SetActive(true);
        }
         //   Debug.Log(mousePos);

    }
    public bool getHerbready()
    {
        return herbready;
    }
    public void setHerbready(bool b)
    {
        herbready = b;
    }
    public bool getClothready()
    {
        return clothready;
    }
    public void setClothready(bool b)
    {
        clothready = b;
    }
    public bool getBottleready()
    {
        return bottleready;
    }
    public void setBottleready(bool b)
    {
        bottleready = b;
    }
    public bool getIsover()
    {
        return isover;
    }
    public void setIsover(bool b)
    {
        isover = b;
    }
    public bool getIsGameOver()
    {
        return isGameOver;
    }
    public void setIsGameOver(bool b)
    {
        isGameOver = b;
    }
    public void Gameover()
    {
        StartCoroutine(GameOverAnimation());
    }
    IEnumerator GameOverAnimation()
    {
        while (true)
        {
            mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, Color.black, 3 * Time.deltaTime);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, 4, 3 * Time.deltaTime);
            if (Mathf.Abs(mainCamera.orthographicSize - 4) < 0.01f)
            {
                break;
            }
            yield return 0;
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}