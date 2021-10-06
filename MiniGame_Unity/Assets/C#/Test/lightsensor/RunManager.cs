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
    public GameObject settleaccounts;
    public Text settleaccountstext;
    public Text txt;
    private Camera mainCamera;
    public GameObject lux;
    public GameObject popbottle;
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
        settleaccounts.SetActive(true);
        int s = GameObject.Find("QTE滑块").GetComponent<qtemove>().stage;
        if (s == 1 || s == 5)
        {
            settleaccountstext.text = "普通";
        }
        else if (s == 2 || s == 4)
        {
            settleaccountstext.text = "良好";
        }
        else if (s == 3)
        {
            settleaccountstext.text = "优秀";
        }
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