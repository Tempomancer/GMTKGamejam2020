using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlidesController : MonoBehaviour
{

    public GameObject slide1;
    public GameObject slide2;
    public GameObject slide3;
    public GameObject slide4;


    void Start()
    {
        slide1.SetActive(true);
        slide2.SetActive(false);
        slide3.SetActive(false);
        slide4.SetActive(false);
        StartCoroutine(Slide2Active());
        StartCoroutine(Slide3Active());
        StartCoroutine(Slide4Active());
        StartCoroutine(Level1());
        
    }
    IEnumerator Slide2Active(){
        yield return new WaitForSeconds(5);
        slide1.SetActive(false);
        slide2.SetActive(true);
        slide3.SetActive(false);
        slide4.SetActive(false);
    }
    IEnumerator Slide3Active(){
        yield return new WaitForSeconds(10);
        slide1.SetActive(false);
        slide2.SetActive(false);
        slide3.SetActive(true);
        slide4.SetActive(false);
    }
    IEnumerator Slide4Active(){
        yield return new WaitForSeconds(15);
        slide1.SetActive(false);
        slide2.SetActive(false);
        slide3.SetActive(false);
        slide4.SetActive(true);
    }
    IEnumerator Level1(){
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
