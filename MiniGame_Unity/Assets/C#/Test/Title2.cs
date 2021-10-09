using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title2 : MonoBehaviour
{
    public GameObject show1;
    public GameObject hide1;
    public AudioSource chaoAudio;
    public GameObject show11;
    public GameObject show12;

    // Use this for initialization
    void Start()
    {
        
        StartCoroutine(MyMethod());
    }
    void Update()
    {
       
    }
    
    IEnumerator MyMethod()
    {
        chaoAudio.Play();
        show1.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        show11.SetActive(true);
        hide1.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        show12.SetActive(true);

    }

    // Update is called once per frame

}
