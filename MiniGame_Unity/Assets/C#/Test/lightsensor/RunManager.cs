using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RunManager : MonoBehaviour {
    public GameObject herbal_util;
    public GameObject cloth_util;
    public GameObject herbal;
    public GameObject cloth;
    public GameObject clothwet;
    public GameObject isdone;
    public GameObject bottle;
    private bool herbready = false;
    private bool clothready = false;
    private bool bottleready = false;
    private bool isover = false;
    private Camera mainCamera;
	// Use this for initialization
	void Start () {
        mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		
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
