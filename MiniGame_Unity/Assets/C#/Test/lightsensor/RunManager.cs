using System;
using System.Collections;
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
    public GameObject setacccommon;
    public GameObject setaccexcellent;
    public GameObject setaccgood;
    public AudioSource water;
    public AudioSource op_right;
    //public Text settleaccountstext;
    public Text txt;
    private Camera mainCamera;
    public GameObject lux;
    public GameObject popbottle;
    public GameObject isdoneimage;
    public GameObject cloth;
    private bool setonce = false;
    private bool flag1 = false;
    // Use this for initialization
    float time = .0f;
    private int cnt = 0;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (qteactive==false) {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);

            if (bottleready == true && qteactive == false && mousePos.x > 1700 && mousePos.y < 700)
            {
                if (Input.GetMouseButton(0))
                {
                    time += Time.deltaTime;
                    if (time > 1.0f)
                    {
                        txt.text = " ";
                        popbottle.SetActive(false);
                        QTE.SetActive(true);
                        QTEslice.SetActive(true);
                        qteactive = true;
                        water.Play();
                    }
                }
            }
        }
        if (isover == true&&setonce==false)
        {
            op_right.Play();
            lux.SetActive(true);
            setonce = true;
        }
        if (flag1 == true)
        {
            cnt++;
            if (cnt>400||Input.GetMouseButtonDown(0))
            {
                int s = GameObject.Find("QTE滑块").GetComponent<qtemove>().stage;
                if (s == 1 || s == 5)
                {
                    setacccommon.SetActive(true);
                }
                else if (s == 2 || s == 4)
                {
                    setaccgood.SetActive(true);
                }
                else if (s == 3)
                {
                    setaccexcellent.SetActive(true);
                }
                flag1 = false;
            }
        }
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
        op_right.Play();
        isdoneimage.transform.position = cloth.transform.position;
        isdoneimage.SetActive(true);
        flag1 = true;
    }
    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    public void PlayNext()
    {
        int s = GameObject.Find("QTE滑块").GetComponent<qtemove>().stage;
        if (s == 1 || s == 5)
        {
            GlobalScore.Instance.Score2 += 5;
        }
        else if (s == 2 || s == 4)
        {
            GlobalScore.Instance.Score2 += 8;
        }
        else if (s == 3)
        {
            GlobalScore.Instance.Score2 += 10;
        }
        SceneManager.LoadSceneAsync("16");
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
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}